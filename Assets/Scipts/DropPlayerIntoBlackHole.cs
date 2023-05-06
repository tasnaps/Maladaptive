using UnityEngine;
using UnityEngine.SceneManagement;

public class DropPlayerIntoBlackHole : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject playerObject2;

    private Transform playerTransform;
    private Transform playerTransform2;
    private PlayerMovement playerMovement;

    private float currentSpeed = 0f; // Current lifting speed
    public float acceleration; // Acceleration of lifting speed
    public float maxHeight = 10f; // Height at which the player starts moving towards object X center
    public float stopAccelHeight = 400f;
    public Transform targetObject; // Object that the player will move towards

    void Start()
    {
        playerTransform = playerObject.GetComponent<Transform>();
        playerTransform2 = playerObject2.GetComponent<Transform>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    void OnEnable()
    {
        // Subscribe to the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This method will be called when a scene is loaded
        Debug.Log("Scene loaded: " + scene.name);
        InvokeRepeating("Lift", 4f, Time.fixedDeltaTime); // Invoke Lift function repeatedly with fixed interval
    }

    void Lift()
    {
        // Disable the player movement script
        playerMovement.enabled = false;

        currentSpeed += acceleration;

        // Move the player upward by changing their Y position with the current lifting speed
        if (playerTransform.position.y < stopAccelHeight)
        {
            playerTransform.position += Vector3.up * currentSpeed * Time.fixedDeltaTime;
        }

        // Move the player towards the target object
        if (playerTransform.position.y > maxHeight)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, targetObject.position, currentSpeed / 22);
        }

        // Move the camera upward by changing their Y position with the current lifting speed
        if (playerTransform2.position.y < stopAccelHeight)
        {
            playerTransform2.position += Vector3.up * currentSpeed * Time.fixedDeltaTime;
        }
        // Move the camera towards the target object
        if (playerTransform2.position.y > maxHeight)
        {
            playerTransform2.position = Vector3.MoveTowards(playerTransform2.position, targetObject.position, currentSpeed / 22);
        }
    }
}