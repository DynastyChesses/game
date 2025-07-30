using Spine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using UnityEngine;

public class TestSP : MonoBehaviour
{
    private static readonly int FillPhase = Shader.PropertyToID("_FillPhase");
    public SkeletonGraphic skeletonGraphic;
    
    
    [SpineAnimation] public string animation;

    [SpineSlot] public string slot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var t = skeletonGraphic.AnimationState.SetAnimation(0, "attack", false);
            t.MixDuration = 0f;
            t.Complete += entry =>
            {
                var ta = skeletonGraphic.AnimationState.SetAnimation(entry.TrackIndex, "idle", true);
            };
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<CanvasRenderer>().GetMaterial().SetColor("_Black",new Color(0.5f, 0.5f, 0.5f, 1f));
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<CanvasRenderer>().GetMaterial().SetColor("_Black",Color.black);
        }
       
    }
}
