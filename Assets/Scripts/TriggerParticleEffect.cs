using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particleSystem; //Reference to the Particle System
    public int particleAmount = 10; //Expose variable for particle amount


    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>()) // Check if the player triggered the event
        {
            particleSystem.Emit(particleAmount); // Emit the specified amount of particles
        }
    }
}
