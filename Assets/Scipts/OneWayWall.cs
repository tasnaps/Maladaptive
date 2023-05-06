using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Autohor: Mikko Turunen @ 2023/02/25
/// 
/// One way wall. The player can only walk backwards through the wall, other wise it appears solid.
/// Works in any orientation along the y-axis.
/// The entrance angle can be adjusted.
/// 
/// The object consists of two objects: the facade and extra wall. 
/// The facade is the face that the player will see and is a plane, which means that only one side is visible.
/// The extra wall is used to prevent the player from clipping through the plane, as it was noted that otherwise player can go through it.
/// 
/// One only has to drag and drop the wall to the scene and it will work just fine.
/// </summary>
public class OneWayWall : MonoBehaviour
{
    [SerializeField] private float _tolerance = 20.0f; // In degrees

    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private GameObject _wallGameObject;
    [SerializeField] private GameObject _extraWall; // Collsion box to prevent the player to clip through the facade.


    // Start is called before the first frame update
    void Start()
    {
        _playerGameObject = GameObject.FindGameObjectsWithTag("Player")[0]; // Get the player object which we will use to activate and deactivate the wall.
    }


    // Update is called once per frame
    void Update()
    {
        GrantAccess();
    }


    /// <summary>
    /// Author: Mikko Turunen @ 2023/02/25
    /// 
    /// If the relative rotations are ok, then disable collision and the model, othwerise enable.
    /// </summary>
    private void GrantAccess()
    {
        if ( GetRelativeRotation() )
        {
            _wallGameObject.GetComponent<MeshCollider>().enabled = false;
            _wallGameObject.GetComponent<MeshRenderer>().enabled = false;

            _extraWall.GetComponentInChildren<BoxCollider>().enabled = false;
        }
        else
        {
            _wallGameObject.GetComponent<MeshCollider>().enabled = true;
            _wallGameObject.GetComponent<MeshRenderer>().enabled = true;

            _extraWall.GetComponent<BoxCollider>().enabled = true;
        }
    }


    /// <summary>
    /// Author: Mikko Turunen @ 2023/02/25
    /// 
    /// Check if the player and the wall's facade are facing in the same direction.
    /// This accepts some tolerance for entrance, otherwise it would be impossible to enter because of the float inaccucary.
    /// </summary>
    /// <returns>Player's and wall's rotation is +-180 +-tolerance</returns>
    public bool GetRelativeRotation()
    {
        // Debug.Log(_playerGameObject.transform.rotation.eulerAngles.y - _wallGameObject.transform.eulerAngles.y);

        // Only allow entrance if the relative y-rotation is +-180+- tolerance.
        return (_playerGameObject.transform.rotation.eulerAngles.y - _wallGameObject.transform.eulerAngles.y > 180 - _tolerance &&
                _playerGameObject.transform.rotation.eulerAngles.y - _wallGameObject.transform.eulerAngles.y < 180 + _tolerance) ||
                (_playerGameObject.transform.rotation.eulerAngles.y - _wallGameObject.transform.eulerAngles.y > -180 - _tolerance &&
                _playerGameObject.transform.rotation.eulerAngles.y - _wallGameObject.transform.eulerAngles.y < -180 + _tolerance);

    }
}
