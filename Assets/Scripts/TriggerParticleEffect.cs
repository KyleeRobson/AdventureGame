using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particleSystem; //Reference to the Particle System


    public int firstEmissionAmount = 10; // Exposed variable for first emission
    public int secondEmissionAmount = 20; //Exposed variable for second emission
    public int thirdEmissionAmount = 30; //Exposed variable for third emission
    public float delayBetweenEmissions = 0.5f; //Delay time between emissions


    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>()) // Check if the player triggered the event
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    //Coroutine to emit particles multiple times with delays
    private IEnumerator EmitParticlesCoroutine()
    {
        // First emission
        particleSystem.Emit(firstEmissionAmount); // Emit based on exposed variable
        yield return new WaitForSeconds(delayBetweenEmissions); // Wait for specified time

        // Second emission
        particleSystem.Emit(secondEmissionAmount); // Emit based on exposed variable
        yield return new WaitForSeconds(delayBetweenEmissions); // Wait for specified time

        // Third emission
        particleSystem.Emit(thirdEmissionAmount); // Emit based on exposed variable
    }
}
