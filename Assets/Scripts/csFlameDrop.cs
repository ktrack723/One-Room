using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class csFlameDrop : MonoBehaviour
{
    [Header("Fetch on start")]

    [SerializeField] private GameObject player;
    
    [Header("Assigned")]

    [SerializeField] private GameObject shadow;

    [Header("DI")]

    [SerializeField] private csURUKManager URUKManager;

    [Header("Parameters")]

    [SerializeField] private float smoothTime;

    [Header("Debug")]

    [SerializeField] private GameObject instancedShadow;

    [SerializeField] private Vector3 currentVelocity;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        instancedShadow = Instantiate(shadow, player.transform.position, Quaternion.identity);

        shadow.transform.localScale = Vector3.zero;
    }


    
    void Update()
    {
        Vector3 trackedPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref currentVelocity, smoothTime);

        transform.position = new Vector3(trackedPosition.x, 0, trackedPosition.z);

        instancedShadow.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }



    private void OnTriggerEnter(Collider other)
    {
        
    }
}