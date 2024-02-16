using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBGMRandomizer : MonoBehaviour
{
    [Header("Fetch on start")]

    [SerializeField] private AudioSource audioSource;

    [Header("Parameters")]

    [SerializeField] private List<AudioClip> BGMs;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = BGMs[Random.Range(0, BGMs.Count)];

        audioSource.Play();
    }



    void Update()
    {
        
    }
}
