using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;



public class csHeaven : MonoBehaviour
{
    [Header("Assigned")]

    [SerializeField] private TransitionSettings transitionSettings;



    void Start()
    {
        
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransitionManager.Instance().Transition("Stage_01", transitionSettings, 0);
        }
    }
}
