using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cow : MonoBehaviour
{
    public AudioSource audioSource; 
    public List<AudioClip> clips; 
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DoMoo());
        audioSource.GetComponent<AudioSource>();
    }

    private IEnumerator DoMoo()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, 8);
            AudioClip clip = clips[randomIndex];
            audioSource.PlayOneShot(clip, 0.05f);
            yield return new WaitForSeconds(Random.Range(8, 15));
        }
    }
}
