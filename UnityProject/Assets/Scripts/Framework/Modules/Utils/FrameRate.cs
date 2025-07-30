using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    public float logPerRound = 60;
    private float lateTimer = 0;

    public static FrameRate Instance;
    private float lastTime = 0;
    private float deltaTime = 0;
    private float currentTime = 0;

    private int updateFrameCount = 0;
    private float totalFrameRate = 0;
    private float averageFrameRate = 0;
    private void Awake()
    {
        if(Instance != null)
        {
            GameObject.DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Instance.updateFrameCount = Instance.updateFrameCount + 1;
        if(Instance.lastTime == 0)
        {
            Instance.lastTime = Time.time;
            return;
        }

        Instance.currentTime = Time.time;
        Instance.deltaTime = Instance.currentTime - Instance.lastTime;

        if(Instance.deltaTime == 0)
        {
            Instance.updateFrameCount = Instance.updateFrameCount - 1;
            return;
        }
        Instance.totalFrameRate = Instance.totalFrameRate + 1 / Instance.deltaTime;
        Instance.averageFrameRate = Instance.totalFrameRate / (Instance.updateFrameCount - 1);
        if(text != null)
        {
            text.text = (1 / Instance.deltaTime).ToString();
        }
        //Debug.Log(Instance.averageFrameRate + "  " + Instance.totalFrameRate + "   " + Instance.updateFrameCount + "     " + Instance.deltaTime);
        lastTime = Time.time;
    }

    private void LateUpdate()
    {
        lateTimer = lateTimer + Time.fixedDeltaTime;
        if(lateTimer > logPerRound)
        {
            lateTimer = lateTimer - logPerRound;
            Instance.Clear();
        }
    }

    public void Clear()
    {
        Instance.lastTime = 0;
        Instance.deltaTime = 0;
        Instance.currentTime = 0;

        Instance.updateFrameCount = 0;
        Instance.totalFrameRate = 0;
        Instance.averageFrameRate = 0;
    }
}
