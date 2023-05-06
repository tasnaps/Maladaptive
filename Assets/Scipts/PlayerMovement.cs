using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Mikko Turunen @ 2023/02/11
/// 
/// Player WASD-movement. This class will work in conjuction with PlayerMouseLook.cs.
/// Current features:
///     Movement with chosen keys or gamepad.
///     Gravity that is tied to game's scene.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _playerCharacterController;

    [SerializeField] private float _movementSpeed;

    private Vector3 _gravity;
    private Vector3 _movementDirection;
    private Vector3 _verticalDirection;

    // Start is called before the first frame update
    void Start()
    {
        _gravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    /// <summary>
    /// Author: Mikko Turunen @ 2023/02/11
    /// 
    /// Move player relative to camera's view.
    /// If the player characer is in the air, the player will fall down.
    /// 
    /// At the movement this is very simple, maybe we could add acceleration at a later date. 
    /// </summary>
    private void MovePlayer()
    {
        // Get the player movement direction, by default it's WASD
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (!_playerCharacterController.isGrounded)
        {
            _verticalDirection += _gravity * Time.deltaTime;
        }
        else
        {
            _verticalDirection = new Vector3(0.0f, -0.001f);
        }

        // Get the player's movement direction and make it relative to the camera
        _movementDirection = (transform.right * x + transform.forward * z).normalized * _movementSpeed + _verticalDirection;

        _playerCharacterController.Move(_movementDirection * Time.deltaTime);
    }
}
