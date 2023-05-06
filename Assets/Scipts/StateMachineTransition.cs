using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Mikko Turunen @ 2023/04/11
/// 
/// Simple script used for controlling the jukebox.
/// Variable '_transition' is used for going to different state in the state machine.
/// 
/// 2023/04/11:
/// Added new variable to activate the next trigger if one is specified.
/// </summary>
public class StateMachineTransition : MonoBehaviour
{
    [SerializeField] private int _transition;
    [SerializeField] private GameObject _nextTrigger;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Jukebox").GetComponent<Jukebox>().QueueNextSection(_transition);

        if (_nextTrigger != null)
            _nextTrigger.SetActive(true);

        gameObject.SetActive(false);
    }
}
