using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;



public class csHeaven : MonoBehaviour
{
    [Header("Assigned")]

    [SerializeField] private TransitionSettings transitionSettings;

    [SerializeField] private bool isRealHeaven;



    void Start()
    {
        
    }



    void Update()
    {
        if (isRealHeaven)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TransitionManager.Instance().Transition("Stage_01", transitionSettings, 0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                TransitionManager.Instance().Transition("Heaven", transitionSettings, 0);
            }
        }
    }
}
