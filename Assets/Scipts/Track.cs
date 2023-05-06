using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Mikko Turunen @ 2023/03/10
/// 
/// A song that will be played with the Jukebox. Object just contains the initial section.
/// Made for easier management.
/// </summary>
[CreateAssetMenu(fileName = "Track", menuName = "ScriptableObjects/Track")]
public class Track : ScriptableObject
{
    public SongSection initialSection;
}
