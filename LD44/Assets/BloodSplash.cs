using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    ParticleSystem PS;
    ParticleSystem.Particle[] particles;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[PS.main.maxParticles];
    }

    void Awake()
    {
        PS = GetComponent<ParticleSystem>();
        Destroy(this.gameObject, PS.startLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = PS.GetParticles(particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            if(particles[i].remainingLifetime < (particles[i].startLifetime - 0.1))
            {
                particles[i].velocity = Vector3.zero;
                
            }
        }
        PS.SetParticles(particles, numParticlesAlive);
    }
}
