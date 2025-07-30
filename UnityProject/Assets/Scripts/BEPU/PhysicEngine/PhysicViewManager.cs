using System.Collections.Generic;
using BEPUphysics.Entities;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;
using Quaternion = BEPUutilities.Quaternion;
using UVector3 = UnityEngine.Vector3;
using UQuaternion = UnityEngine.Quaternion;

namespace Simulation
{
    /// <summary>
    /// 物理View层控制。
    /// 控制物体的坐标和旋转
    /// 用于解决lua层每帧控制上百物体更新的GC消耗
    /// </summary>
    public class PhysicViewManager
    {
        public static Dictionary<int, Transform> ViewObjects = new Dictionary<int, Transform>();
        public static Dictionary<long, int> EntityViewMap = new Dictionary<long, int>();
        public static Dictionary<long, Entity> EntityList = new Dictionary<long, Entity>();
        
        public static Dictionary<long, int> OfflineEntityViewMap = new Dictionary<long, int>();
        public static Dictionary<long, Entity> OfflineEntityList = new Dictionary<long, Entity>();

        public static List<Entity> PlayerList = new List<Entity>();

        public static bool IsOnline = true;
        
        #region ViewUpdate


        private static float _lastTime = 0;
        private static Dictionary<long, UVector3> _beforePosition = new Dictionary<long, UVector3>();
        private static Dictionary<long, UQuaternion> _beforeRotation = new Dictionary<long, UQuaternion>();
        private static Dictionary<long, Vector3> _afterPosition = new Dictionary<long, Vector3>();
        private static Dictionary<long, Quaternion> _afterRotation = new Dictionary<long, Quaternion>();


        public static void UpdateViewBefore()
        {
            _beforePosition.Clear();
            _beforeRotation.Clear();
            Dictionary<long, Entity> entityList;
            if (IsOnline)
                entityList = EntityList;
            else
                entityList = OfflineEntityList;
            Dictionary<long, int> entityViewMap;
            if (IsOnline)
                entityViewMap = EntityViewMap;
            else
                entityViewMap = OfflineEntityViewMap;
            foreach (var entity in entityList)
            {
                if (!entityViewMap.ContainsKey(entity.Key))
                    continue;
                int viewId = entityViewMap[entity.Key];
                if (!ViewObjects.ContainsKey(viewId))
                    continue;
                
                _beforePosition.Add(entity.Key,ViewObjects[viewId].position);
                _beforeRotation.Add(entity.Key,ViewObjects[viewId].rotation);
            }
        }
        public static void UpdateViewAfter()
        {
            _lastTime = Time.time;
            
            _afterPosition.Clear();
            _afterRotation.Clear();
            Dictionary<long, Entity> entityList = null;
            if (IsOnline)
                entityList = EntityList;
            else
                entityList = OfflineEntityList;
            foreach (var entity in entityList)
            {
                _afterPosition.Add(entity.Key,entity.Value.Position);
                _afterRotation.Add(entity.Key,entity.Value.Orientation);
            }
        }

        public static void Update()
        {
            var deltaTime = (Time.time - _lastTime) / GameSimulation.Inst.UpdateStepTimeFloat;
            Dictionary<long, int> entityViewMap;
            if (IsOnline)
                entityViewMap = EntityViewMap;
            else
                entityViewMap = OfflineEntityViewMap;
            foreach (var position in _beforePosition)
            {
                if (!_afterPosition.ContainsKey(position.Key))
                    continue;
                if (!entityViewMap.ContainsKey(position.Key))
                    continue;
                int viewId = entityViewMap[position.Key];
                if (!ViewObjects.ContainsKey(viewId))
                    continue;
                ViewObjects[viewId].position = UVector3.Lerp(position.Value, (UVector3) _afterPosition[position.Key], deltaTime); 
            }
            foreach (var rotation in _beforeRotation)
            {
                if (!_afterRotation.ContainsKey(rotation.Key))
                    continue;
                if (!entityViewMap.ContainsKey(rotation.Key))
                    continue;
                int viewId = entityViewMap[rotation.Key];
                if (!ViewObjects.ContainsKey(viewId))
                    continue;
                ViewObjects[viewId].rotation = UQuaternion.Lerp(rotation.Value, (UQuaternion) _afterRotation[rotation.Key], deltaTime); 
            }
        }
        
        

        #endregion


        public static long GetAllHash()
        {
            long hash = 0;
            foreach (var entity in EntityList)
                hash += entity.Value.Position.GetHash() + entity.Value.Orientation.GetHash();
            return hash;
        }
        public static long GetPlayerHash()
        {
            long hash = 0;
            foreach (var entity in PlayerList)
                hash += entity.Position.GetHash() + entity.Orientation.GetHash();
            return hash;
        }


        public static void AddPlayerEntity(Entity entity)
        {
            PlayerList.Add(entity);
        }

        public static void ClearView()
        {
            foreach (var transform in ViewObjects)
                if (transform.Value.gameObject != null)
                    Object.Destroy(transform.Value.gameObject);
            ViewObjects.Clear();
            EntityViewMap.Clear();
            EntityList.Clear();
            PlayerList.Clear();
            OfflineEntityViewMap.Clear();
            OfflineEntityList.Clear();
        }
        
        public static void BindEntityView(Entity entity,Transform transform)
        {
            EntityList.Add(entity.InstanceId,entity);
            EntityViewMap.Add(entity.InstanceId,AddViewObject(transform));

            transform.position = (UVector3)entity.Position;
            transform.rotation = (UQuaternion)entity.Orientation;
        }
        
        public static void BindOfflineEntityView(Entity entity,Transform transform)
        {
            OfflineEntityList.Add(entity.InstanceId,entity);
            OfflineEntityViewMap.Add(entity.InstanceId,AddViewObject(transform));
        }
        public static void RemoveEntityView(Entity entity)
        {
            if (EntityList.ContainsKey(entity.InstanceId))
                EntityList.Remove(entity.InstanceId);
            if (EntityViewMap.ContainsKey(entity.InstanceId))
            {
                int viewId = EntityViewMap[entity.InstanceId];
                if (ViewObjects.ContainsKey(viewId))
                {
                    Object.Destroy(ViewObjects[viewId].gameObject);
                    ViewObjects.Remove(viewId);
                }
                EntityViewMap.Remove(entity.InstanceId);
            }
        }
        public static void RemoveOfflineEntityView(Entity entity)
        {
            if (OfflineEntityList.ContainsKey(entity.InstanceId))
                OfflineEntityList.Remove(entity.InstanceId);
            if (OfflineEntityViewMap.ContainsKey(entity.InstanceId))
                OfflineEntityViewMap.Remove(entity.InstanceId);
        }
        
        public static int AddViewObject(Transform transform)
        {
            int id = transform.GetInstanceID();
            if (ViewObjects.ContainsKey(id))
                return id;
            ViewObjects.Add(id,transform);
            return id;
        }
        public static bool RemoveViewObject(Transform transform)
        {
            int id = transform.GetInstanceID();
            if (!ViewObjects.ContainsKey(id))
                return false;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return false;
            }
            ViewObjects.Remove(id);
            return true;
        }
        
        //---------------------Set_Scale--------------------------------------------
        public static void ObjectSetScaleBV(int id,BEPUutilities.Vector3 scale)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return ;
            }
            ViewObjects[id].transform.localScale = (UnityEngine.Vector3)scale;
        }
        public static void ObjectSetScaleUV(int id,UnityEngine.Vector3 scale)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return ;
            }
            ViewObjects[id].transform.localScale = scale;
        }
        //---------------------Set_Position--------------------------------------------
        public static void ObjectSetPositionBV(int id,BEPUutilities.Vector3 pos)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return ;
            }
            ViewObjects[id].transform.position = (UnityEngine.Vector3)pos;
        }
        public static void ObjectSetPositionUV(int id,UnityEngine.Vector3 pos)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.position = pos;
        }
        public static void ObjectSetPositionFloat(int id,float x,float y,float z)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.position = new UnityEngine.Vector3(x,y,z);
        }
        
        //---------------------Set_Rotation--------------------------------------------
        public static void ObjectSetRotationBQ(int id,BEPUutilities.Quaternion qua)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.rotation = (UnityEngine.Quaternion)qua;
        }        
        public static void ObjectSetRotationUQ(int id,UnityEngine.Quaternion qua)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.rotation = qua;
        }
        public static void ObjectSetRotationBEuler(int id,BEPUutilities.Vector3 euler)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.rotation = UQuaternion.Euler((UnityEngine.Vector3)euler);
        }
        public static void ObjectSetRotationUEuler(int id,UnityEngine.Vector3 euler)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.rotation = UQuaternion.Euler(euler);
        }
        public static void ObjectSetRotationFloat(int id,float x,float y,float z,float w)
        {
            if (!ViewObjects.ContainsKey(id))
                return;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return;
            }
            ViewObjects[id].transform.rotation = new UQuaternion(x,y,z,w);
        }
        
        
        public static Transform GetViewTransform(int id)
        {
            if (!ViewObjects.ContainsKey(id))
                return null;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return null;
            }
            return ViewObjects[id];
        }
        public static UnityEngine.Vector3 GetViewObjectPosition(int id)
        {
            if (!ViewObjects.ContainsKey(id))
                return UnityEngine.Vector3.zero;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return UnityEngine.Vector3.zero;
            }
            return ViewObjects[id].transform.position;
        }
        public static UnityEngine.Quaternion GetViewObjectRotation(int id)
        {
            if (!ViewObjects.ContainsKey(id))
                return UnityEngine.Quaternion.identity;
            if (ViewObjects[id] == null)
            {
                ViewObjects.Remove(id);
                return UnityEngine.Quaternion.identity;
            }
            return ViewObjects[id].transform.rotation;
        }
        
    }
}