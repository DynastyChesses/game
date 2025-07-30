using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu]
public class GameConfig : ScriptableObject
{
    public string GameName = "GameProj";
    public string LocalServerHost = "127.0.0.1:8181";
    public int  GameType = 0;
}

public struct PhysicConfig
{
    //3D物理设置
    public int defaultSolverVelocityIterations;
    public int defaultSolverVelocityIterationsC;
    public int defaultSolverIterations;
    float bounceThreshold;
    bool queriesHitBackfaces;
    float defaultContactOffset;
    float sleepThreshold;
    float bounceTreshold;
    Vector3 gravity;
    float minPenetrationForPenalty;
    bool queriesHitTriggers;
    float sleepVelocity;
    int solverIterationCount;
    float maxAngularVelocity;
    int solverVelocityIterationCount;
    float penetrationPenaltyForce;
    float defaultMaxAngularSpeed;
    PhysicsScene defaultPhysicsScene;
    bool autoSimulation;
    bool autoSyncTransforms;
    bool reuseCollisionCallbacks;
    float interCollisionDistance;
    float interCollisionStiffness;
    float sleepAngularVelocity;
    bool interCollisionSettingsToggle;
    Vector3 clothGravity;
    public void Init()
    {
        defaultSolverVelocityIterations = Physics.defaultSolverVelocityIterations;
        defaultSolverIterations = Physics.defaultSolverIterations;
        bounceThreshold = Physics.bounceThreshold;
        queriesHitBackfaces = Physics.queriesHitBackfaces;
        defaultContactOffset = Physics.defaultContactOffset;
        sleepThreshold = Physics.sleepThreshold;
        gravity = Physics.gravity;
        queriesHitTriggers = Physics.queriesHitTriggers;
        defaultMaxAngularSpeed = Physics.defaultMaxAngularSpeed;
        autoSimulation = Physics.autoSimulation;
        autoSyncTransforms = Physics.autoSyncTransforms;
        reuseCollisionCallbacks = Physics.reuseCollisionCallbacks; ;
        interCollisionDistance = Physics.interCollisionDistance; ; ;
        interCollisionStiffness = Physics.interCollisionStiffness; ;
        interCollisionSettingsToggle= Physics.interCollisionSettingsToggle; 
        clothGravity = Physics.clothGravity; 
    }
    public void Restore()
    {
        Physics.defaultSolverVelocityIterations = defaultSolverVelocityIterations;
        Physics.defaultSolverIterations = defaultSolverIterations;
        Physics.bounceThreshold = bounceThreshold;
        Physics.queriesHitBackfaces = queriesHitBackfaces;
        Physics.defaultContactOffset = defaultContactOffset;
        Physics.sleepThreshold = sleepThreshold;
        Physics.gravity = gravity;
        Physics.queriesHitTriggers = queriesHitTriggers;

        Physics.defaultMaxAngularSpeed = defaultMaxAngularSpeed;
 
        Physics.autoSimulation = autoSimulation;
        Physics.autoSyncTransforms = autoSyncTransforms;
        Physics.reuseCollisionCallbacks = reuseCollisionCallbacks; ;
        Physics.interCollisionDistance = interCollisionDistance; ; ;
        Physics.interCollisionStiffness = interCollisionStiffness; ;
        //3D物理设置重置
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                Physics.IgnoreLayerCollision(j, i, false);
            }
        }
    }
};
// 2D物理设置
public struct Physic2DConfig
{   
    public int velocityIterations;
    public  int positionIterations;
    public  Vector2 gravity;
    public  bool queriesHitTriggers;
    public  bool queriesStartInColliders;
    public  float maxRotationSpeed;
    public  bool reuseCollisionCallbacks;
    public  bool autoSyncTransforms;
    public  bool autoSimulation;
    public  PhysicsJobOptions2D jobOptions;
    public  float velocityThreshold;
    public  float maxLinearCorrection;
    public  float maxAngularCorrection;
    public  float maxTranslationSpeed;
    public  bool callbacksOnDisable;
    public  float baumgarteScale;
    public  float baumgarteTOIScale;
    public  Color colliderAABBColor;
    public  Color colliderContactColor;
    public  Color colliderAsleepColor;
    public  Color colliderAwakeColor;
    public  float contactArrowScale;
    public  bool showColliderAABB;
    public  bool showColliderContacts;
    public  bool showColliderSleep;
    public  bool alwaysShowColliders;
    public  float angularSleepTolerance;
    public  float linearSleepTolerance;
    public  float timeToSleep;
    
    public void Init()
    {
        velocityIterations = Physics2D.velocityIterations;
        positionIterations = Physics2D.positionIterations;
        gravity= Physics2D.gravity;
        queriesHitTriggers = Physics2D.queriesHitTriggers ;
        queriesStartInColliders = Physics2D.queriesStartInColliders; ;
        maxRotationSpeed = Physics2D.maxRotationSpeed;
        reuseCollisionCallbacks= Physics2D.reuseCollisionCallbacks;
        autoSyncTransforms = Physics2D.autoSyncTransforms; ;
        autoSimulation = Physics2D.autoSimulation;
        jobOptions = Physics2D.jobOptions;
        velocityThreshold = Physics2D.velocityThreshold;
        maxLinearCorrection = Physics2D.maxLinearCorrection;
        maxAngularCorrection = Physics2D.maxAngularCorrection;
        maxTranslationSpeed = Physics2D.maxTranslationSpeed;
        callbacksOnDisable = Physics2D.callbacksOnDisable;
        baumgarteScale = Physics2D.baumgarteScale;
        baumgarteTOIScale = Physics2D.baumgarteTOIScale;
        angularSleepTolerance = Physics2D.angularSleepTolerance;
        linearSleepTolerance = Physics2D.linearSleepTolerance;
        timeToSleep = Physics2D.timeToSleep;
    }
    public void Restore()
    {
        Physics2D.velocityIterations = velocityIterations;
        Physics2D.positionIterations = positionIterations;
        Physics2D.gravity = gravity;
        Physics2D.queriesHitTriggers = queriesHitTriggers;
        Physics2D.queriesStartInColliders = queriesStartInColliders; ;
        Physics2D.maxRotationSpeed = maxRotationSpeed;
        Physics2D.reuseCollisionCallbacks =reuseCollisionCallbacks;
        Physics2D.autoSyncTransforms = autoSyncTransforms; ;
        Physics2D.autoSimulation = autoSimulation;
        Physics2D.jobOptions = jobOptions;
        Physics2D.velocityThreshold = velocityThreshold;
        Physics2D.maxLinearCorrection = maxLinearCorrection;
        Physics2D.maxAngularCorrection = maxAngularCorrection;
        Physics2D.maxTranslationSpeed = maxTranslationSpeed;
        Physics2D.callbacksOnDisable = callbacksOnDisable;
        Physics2D.baumgarteScale = baumgarteScale;
        Physics2D.baumgarteTOIScale = baumgarteTOIScale;
        Physics2D.angularSleepTolerance = angularSleepTolerance;
        Physics2D.linearSleepTolerance = linearSleepTolerance;
        Physics2D.timeToSleep = timeToSleep;
        // 3D物理设置重置
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                Physics2D.IgnoreLayerCollision(j, i, false);
            }
        }
    }
}

// 音频设置
public struct AudioConfig
{
    AudioConfiguration audioConfiguration;
    public void Init()
    {
        audioConfiguration = AudioSettings.GetConfiguration();
    }
    public void Restore()
    {
        AudioSettings.Reset(audioConfiguration);
    }
}

public class EngineConfig
{
    public PhysicConfig physicConfig;
    public Physic2DConfig physic2DConfig;
    public AudioConfig  audioConfig;
    public int qualityLevel;
    public void Init()
    {
        physicConfig.Init();
        physic2DConfig.Init();
        audioConfig.Init();
        qualityLevel = QualitySettings.GetQualityLevel();
    }
    public void Restore()
    {
        physicConfig.Restore();
        physic2DConfig.Restore();
        audioConfig.Restore();
        //渲染管线恢复默认渲染管线
        GraphicsSettings.renderPipelineAsset = GraphicsSettings.defaultRenderPipeline;
        //渲染质量等级
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}