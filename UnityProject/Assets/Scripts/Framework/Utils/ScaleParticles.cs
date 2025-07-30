using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScaleParticles : MonoBehaviour
{
    public float ScaleSize = 1.0f;
    private List<float> initialSizes = new List<float>();

    void Awake()
    {
        ParticleSystem[] particles = gameObject.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            initialSizes.Add(particle.main.startSizeMultiplier);
            ParticleSystemRenderer renderer = particle.GetComponent<ParticleSystemRenderer>();
            if (renderer)
            {
                initialSizes.Add(renderer.lengthScale);
                initialSizes.Add(renderer.velocityScale);
            }
        }
    }

    void Start()
    {
        gameObject.transform.localScale = new Vector3(ScaleSize, ScaleSize, ScaleSize);

        int arrayIndex = 0;
        ParticleSystem[] particles = gameObject.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            ParticleSystem.MainModule mainModule = particle.main;
            mainModule.startSizeMultiplier = initialSizes[arrayIndex++] * gameObject.transform.localScale.magnitude;
            ParticleSystemRenderer renderer = particle.GetComponent<ParticleSystemRenderer>();
            if (renderer)
            {
                renderer.lengthScale = initialSizes[arrayIndex++] *
                    gameObject.transform.localScale.magnitude;
                renderer.velocityScale = initialSizes[arrayIndex++] *
                    gameObject.transform.localScale.magnitude;
            }
        }
    }

}