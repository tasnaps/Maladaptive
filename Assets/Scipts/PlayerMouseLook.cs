using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Mikko Turunen @ 2023/02/11
/// 
/// Player mouse look behaviour class for FPS-controller. 
/// Enables the use of mouse and possibly controller for player character.
/// 
/// This class will work in conjucntion with PlayerMovement.cs
/// </summary>
public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private float _playerMouseSensitivityX = 1.0f;
    [SerializeField] private float _playerMouseSensitivityY = 1.0f;

    private float _xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        MouseLook();
        if(PlayerPrefs.HasKey("Sensitivity"))
        {
            _playerMouseSensitivityX = PlayerPrefs.GetFloat("Sensitivity");
            _playerMouseSensitivityY = PlayerPrefs.GetFloat("Sensitivity");
        }
    }


    /// <summary>
    /// Author: Mikko Turunen @ 2023/02/11
    /// 
    /// Get the mouse input and move the player camera accordingly.
    /// This method also clamps the look to +-90 degrees vertically, which allows us to follow conventions.
    /// </summary>
    public void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * _playerMouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * _playerMouseSensitivityY;

        _xRotation += mouseY * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(-_xRotation, 0.0f, 0.0f);
        _player.transform.Rotate(new Vector3(0.0f, mouseX, 0.0f) * Time.deltaTime);
    }
}