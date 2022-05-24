using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextParticles : MonoBehaviour
{
    public ParticleSystem particles;
    private ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        em = particles.emission;
        StartCoroutine(playParticles());
    }

    // Update is called once per frame
    IEnumerator playParticles()
    {
        em.enabled = true;
        particles.Play();
        yield return new WaitForSeconds(2f);
        em.enabled = false;
        Destroy(gameObject);
    }
}
