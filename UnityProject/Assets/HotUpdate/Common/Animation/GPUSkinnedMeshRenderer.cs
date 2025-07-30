using UnityEngine;

[ExecuteInEditMode]
[DefaultExecutionOrder(99999)]
public class GPUSkinnedMeshRenderer : MonoBehaviour 
{
    public GPUSkinnedMeshInfo info;

    public Animator animator;

    public MeshRenderer meshRenderer;

    private GPUSkinnedMeshInfo.ClipData _lastClipData;
    
    private GPUSkinnedMeshInfo.ClipData _nextClipData;

    private static Vector4 _animationParams;

    private static MaterialPropertyBlock _mpb;

    private static int _animParamsId;
    
    // Use this for initialization
    void Start () {
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _animParamsId = Shader.PropertyToID("_AnimParams");
        }
	}
	
	//// Update is called once per frame
	void LateUpdate ()
	{
		if (!animator.IsInTransition(0))
		{
			var asi = animator.GetCurrentAnimatorStateInfo(0);
			var clipMap = info.clipMap;
			if (_lastClipData == null || asi.shortNameHash != _lastClipData.nameHash)
			{
				clipMap.TryGetValue(asi.shortNameHash, out _lastClipData);
			}

			if (_lastClipData != null && _mpb != null)
			{
				float normalizedTime = asi.normalizedTime;
				int frameIndex = asi.loop || normalizedTime < 1f
					? Mathf.Clamp((int) ((normalizedTime - (int) normalizedTime) * _lastClipData.totalFrame), 0,
						_lastClipData.totalFrame - 1)
					: _lastClipData.totalFrame - 1;
				meshRenderer.GetPropertyBlock(_mpb);
				_animationParams.x = frameIndex * info.bonePixelOffset + _lastClipData.offset;
				_animationParams.w = 0;
				_mpb.SetVector(_animParamsId, _animationParams);
				meshRenderer.SetPropertyBlock(_mpb);
			}
		}
		else
		{
			AnimatorTransitionInfo transitionInfo = animator.GetAnimatorTransitionInfo(0);
			
			var lastAsi = animator.GetCurrentAnimatorStateInfo(0);
			var clipMap = info.clipMap;
			if (_lastClipData == null || lastAsi.shortNameHash != _lastClipData.nameHash)
			{
				clipMap.TryGetValue(lastAsi.shortNameHash, out _lastClipData);
			}

			var nextAsi = animator.GetNextAnimatorStateInfo(0);
			if (_nextClipData == null || nextAsi.shortNameHash != _nextClipData.nameHash)
			{
				clipMap.TryGetValue(nextAsi.shortNameHash, out _nextClipData);
			}

			
			if (_lastClipData != null && _nextClipData != null)
			{
				float normalizedTime = lastAsi.normalizedTime;
				int lastFrameIndex = normalizedTime < 1f ? Mathf.Clamp((int) ((normalizedTime - (int) normalizedTime) * _lastClipData.totalFrame),
					0,
					_lastClipData.totalFrame - 1) : _lastClipData.totalFrame - 1;
				normalizedTime = nextAsi.normalizedTime;
				int nextFrameIndex = Mathf.Clamp((int) ((normalizedTime - (int) normalizedTime) * _nextClipData.totalFrame),
					0,
					_nextClipData.totalFrame - 1);
				meshRenderer.GetPropertyBlock(_mpb);
				_animationParams.x = lastFrameIndex * info.bonePixelOffset + _lastClipData.offset;
				_animationParams.y = nextFrameIndex * info.bonePixelOffset + _nextClipData.offset;
				_animationParams.z = transitionInfo.normalizedTime;
				_animationParams.w = 1;
				_mpb.SetVector(_animParamsId, _animationParams);
				meshRenderer.SetPropertyBlock(_mpb);
			}
		}
	}

    // void UpdateBoneTransformMatrix(Transform bone, Matrix4x4 parentMat, int index)
    // {
    //     Matrix4x4 mat = parentMat * Matrix4x4.TRS(bone.localPosition, bone.localRotation, Vector3.one);
    //     _matrices[index] = mat * _bindPoses[index];
    //     int childCount = bone.childCount;
    //     for (int i = 0; i < childCount; ++i)
    //     {
    //         Transform child = bone.GetChild(i);
    //         int childIndex = -1;
    //         if (_boneIndexMap.TryGetValue(child.GetInstanceID(), out childIndex))
    //         {
    //             UpdateBoneTransformMatrix(child, mat, childIndex);
    //         }
    //     }
    // }
}
