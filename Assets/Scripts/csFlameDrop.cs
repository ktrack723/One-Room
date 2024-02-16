using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class csFlameDrop : MonoBehaviour
{
    [Header("Fetch on start")]

    [SerializeField] private GameObject player;

    [SerializeField] private csURUKManager URUKManager;

    [Header("Assigned")]

    [SerializeField] private GameObject shadow;

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

        URUKManager = GameObject.FindGameObjectWithTag("URUKManager").GetComponent<csURUKManager>();

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
        transform.Translate(Vector3.up * dropSpeed * Time.deltaTime);
        instancedShadow.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, transform.position.y / startHeight);

        if (transform.position.y < 2f)
        {
            Destroy(gameObject);

            Destroy(instancedShadow);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            Destroy(other.gameObject);

            Destroy(gameObject);

            Destroy(instancedShadow);
        }

        if (other.tag == "Player")
        {
            URUKManager.EndGame();

            Destroy(gameObject);

            Destroy(instancedShadow);
        }
    }
}