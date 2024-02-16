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

    [SerializeField] private float dropSpeed;

    [SerializeField] private float smoothTime;

    [Header("Debug")]

    [SerializeField] private GameObject instancedShadow;

    [SerializeField] private Vector3 currentVelocity;

    [SerializeField] private float startHeight;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        instancedShadow = Instantiate(shadow, player.transform.position, Quaternion.identity);

        shadow.transform.localScale = Vector3.zero;

        startHeight = transform.position.y;
    }


    
    void Update()
    {
        // Track
        Vector3 trackedPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref currentVelocity, smoothTime);
        transform.position = new Vector3(trackedPosition.x, transform.position.y, trackedPosition.z);
        instancedShadow.transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        // Drop
        transform.Translate(Vector3.down * dropSpeed * Time.deltaTime);
        shadow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, transform.position.y / startHeight);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            URUKManager.EndGame();
        }
    }
}