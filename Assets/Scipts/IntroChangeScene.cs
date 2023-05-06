using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Mikko Turunen @ 2023/04/07
/// 
/// For intro only. Load the next scene after the track has been played.
/// </summary>
public class IntroChangeScene : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] string _nextScene;

    // Update is called once per frame
    void Update()
    {
        _audioSource.loop = false; // For some reason the jukebox turns on the loop, we don't like that here
        if (!_audioSource.isPlaying)
        {
            SceneManager.LoadScene(_nextScene, LoadSceneMode.Single);
        }
    }
}
