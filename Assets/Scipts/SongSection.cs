using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Mikko Turunen @ 2023/03/10
/// 
/// SongSection scriptable object. One object holds an audioclip that will be played through a jukebox.
/// One clip can be followed by multiple different clips.
/// </summary>
[CreateAssetMenu(fileName = "SongSection", menuName = "ScriptableObjects/SongSection")]
public class SongSection : ScriptableObject
{
    public AudioClip section;
    public SongSection[] nextSection;
    public bool autoQueueNext;
}
