using System;
using System.Collections.Generic;
using System.Threading;
using BEPUphysics;
using BEPUphysics.BroadPhaseEntries;
using BEPUphysics.Materials;
using BEPUutilities;
using FixMath.NET;
using Unity.Profiling;
using UnityEngine;
using Material = UnityEngine.Material;
using Quaternion = UnityEngine.Quaternion;
using Ray = BEPUutilities.Ray;
using Space = BEPUphysics.Space;
using Vector3 = BEPUutilities.Vector3;
using Vector2 = BEPUutilities.Vector2;

namespace Simulation
{
    
    public class GameSimulation
    {
        public static GameSimulation OnlineSimulation;
        public static GameSimulation OfflineSimulation;
        
        public static GameSimulation Inst => OnlineSimulation;
        
        public static void NewSimulation()
        {
            OnlineSimulation = new GameSimulation();
            OfflineSimulation = new GameSimulation();
        }
        /// <summary>
        /// 3D物理空间
        /// </summary>
        public Space PhysicsWorld { get; private set; }
        /// <summary>
        /// 更新步长
        /// </summary>
        public Fix64 UpdateStepTime { get; private set; }
        //View层专用
        public float UpdateStepTimeFloat { get; private set; }
        /// <summary>
        /// 当前物理帧数
        /// </summary>
        public int CurrentTick { get; set; } = 0;
        /// <summary>
        /// 当前游戏世界总时间
        /// </summary>
        public Fix64 CurrentTime => UpdateStepTime * CurrentTick;

        public GameSimulation()
        {
            PhysicsWorld = new Space
            {
                ForceUpdater =
                {
                    Gravity =  new Vector3(0, -9.81m * 2m, 0)
                }
            };
            SetUpdateTime(0.05m);
            CurrentTick = 0;
            
            MaterialManager.MaterialBlender = delegate(BEPUphysics.Materials.Material a, BEPUphysics.Materials.Material b, out InteractionProperties properties)
            {
                properties.KineticFriction = MathHelper.Min(a.KineticFriction, b.KineticFriction);
                properties.StaticFriction = MathHelper.Min(a.StaticFriction, b.StaticFriction);
                properties.Bounciness = MathHelper.Max(a.Bounciness, b.Bounciness);
            };
            
        }
        
        /// <summary>
        /// 设置物理更新步长
        /// </summary>
        /// <param name="time">步长时间</param>
        public void SetUpdateTime(Fix64 time)
        {
            UpdateStepTimeFloat = (float)time;
            UpdateStepTime = time;
            PhysicsWorld.TimeStepSettings = new TimeStepSettings(){TimeStepDuration = UpdateStepTime};
        }


        private List<IUpdate> _allUpdate = new List<IUpdate>();

        /// <summary>
        /// 更新一帧物理
        /// </summary>
        public void Update()
        {
            PhysicsWorld.Update();
            CurrentTick++;
        }

        private int objCount = 0;
        /// <summary>
        /// 添加一个受物理空间管理的Object
        /// </summary>
        public void Add(object obj)
        {
            if(obj is ISpaceObject spaceObject)//其他类型
            {
                PhysicsWorld.Add(spaceObject);
            }
        }
    
        /// <summary>
        /// 移除一个受物理空间管理的Object TODO.... 暂时不管 没空。。
        /// </summary>
        public void Remove(object obj)
        {
            if(obj is ISpaceObject spaceObject)//其他类型
            {
                PhysicsWorld.Remove(spaceObject);
            }
        }

        #region 射线RayCast

        public bool RayCast(Ray ray, Fix64 maximumLength, out RayCastResult result)
        {
            return PhysicsWorld.RayCast(ray, maximumLength, out result);
        }
        public bool RayCast(Ray ray, Fix64 maximumLength,Func<BroadPhaseEntry, bool> filter, out RayCastResult result)
        {
            return PhysicsWorld.RayCast(ray, maximumLength,filter, out result);
        }
        public bool RayCastAll(Ray ray, Fix64 maximumLength,out List<RayCastResult> resultList)
        {
            resultList = new List<RayCastResult>();
            return PhysicsWorld.RayCast(ray, maximumLength, resultList);
        }        
        public bool RayCastAll(Ray ray, Fix64 maximumLength,Func<BroadPhaseEntry, bool> filter,out List<RayCastResult> resultList)
        {
            resultList = new List<RayCastResult>();
            return PhysicsWorld.RayCast(ray, maximumLength,filter, resultList);
        }

        #endregion


        public static void GetInput(out long x,out long y)
        {
            var inputx = (int)UnityEngine.Input.GetAxisRaw("Horizontal");
            var inputy = (int)UnityEngine.Input.GetAxisRaw("Vertical");
            GetCameraDirInput(inputx,inputy,out x,out y);
        }

        public static void GetCameraDirInput(float inputX,float inputY,out long outX,out long outY)
        {
            outX = 0;
            outY = 0;
            if (Camera.main == null)
                return;
            UnityEngine.Vector3 targetDir = new UnityEngine.Vector3(inputX, 0, inputY);
            float cameraY = Camera.main.transform.rotation.eulerAngles.y;
            targetDir = UnityEngine.Quaternion.Euler(0,cameraY, 0) * targetDir;
            Vector2 dir = new Vector2((Fix64)targetDir.x, (Fix64)targetDir.z);
            outX = dir.X.RawValue;
            outY = dir.Y.RawValue;
        }
    }
    
}
