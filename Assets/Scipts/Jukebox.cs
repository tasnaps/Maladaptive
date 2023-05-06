using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Mikko Turunen @ 2023/03/10
/// 
/// Jukebox for playing music. Each track consist of SongSection that will flow to eachother smoothly. 
/// The Jukebox is controlled with StateMachineTransition-script. 
/// When a player collides with a trigger, the trigger will send message to this object that next section should start after the current has been played.
/// </summary>
public class Jukebox : MonoBehaviour
{
    [SerializeField] private Track _currentTrack;
    private SongSection _currentSection;
    private AudioSource _audioSource;
    private Queue<SongSection> _sectionQueue = new Queue<SongSection>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;

        _currentSection = _currentTrack.initialSection;
        _audioSource.clip = _currentSection.section;
        _audioSource.Play();
    }


    private void Update()
    {
        ChangeSection();
    }


    /// <summary>
    /// Change song's section. The section is changed if the player is not looping.
    /// The song can tell if there will be transition without colliding with StateMachineTransition.
    /// </summary>
    private void ChangeSection()
    {
        if (_currentSection.autoQueueNext && !_sectionQueue.Contains(_currentSection.nextSection[0]))
        {
            QueueNextSection(0);
        }

        if (_sectionQueue.Count > 0)
        {
            // If there's a section queued --> start playing the next section
            if (!_audioSource.isPlaying)
            {
                // Take the next section and dequeue it
                _currentSection = _sectionQueue.Peek();
                _sectionQueue.Dequeue();

                _audioSource.clip = _currentSection.section;
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
    }


    /// <summary>
    /// Qeueue next section according to given index. 
    /// This can happen while colliding with StateMachineTransition or if the song section has bool autoQueueNext as true.
    /// </summary>
    /// <param name="ns">Index of transition.</param>
    public void QueueNextSection(int ns)
    {
        Debug.Log("Queued section " + ns);
        SongSection nextSongSection = _currentSection.nextSection[ns];
        if (!_sectionQueue.Contains(nextSongSection))
            _sectionQueue.Enqueue(nextSongSection);
        _audioSource.loop = false;
    }
}
