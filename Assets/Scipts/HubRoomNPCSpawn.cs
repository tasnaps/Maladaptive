using UnityEngine;

public class HubRoomNPCSpawn : MonoBehaviour
{
    // The object to use as the center of the plane for spawning new objects
    public GameObject centerObject;

    // The new object to be spawned
    public GameObject objectToSpawn;

    // Spawn radiuses.
    public float innerCircleMinDistance = 345.0f;
    public float innerCircleMaxDistance = 400.0f;
    public float outerCircleMinDistance = 400.0f;
    public float outerCircleMaxDistance = 1200.0f;
    
    // The number of new objects to spawn
    public int outerCircleObjectCount = 8000;
    public int innerCircleObjectCount = 4000;

    // Gap for portal.
    public float gapStart = 45.0f;
    public float gapEnd = 50.0f;

    // Random rotation range of NPCs.
    public float minRotation = -5.0f;
    public float maxRotation = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the position of the center object
        Vector3 centerPosition = centerObject.transform.position;

        // Spawn new objects on a plane between  and innerCircleMaxDistance from the center object
        

        for (int i = 0; i < innerCircleObjectCount; i++)
        {   
            float distance = Random.Range(innerCircleMinDistance, innerCircleMaxDistance);

            

            float maxAngle = 360.0f;
            float minAngle = 0.0f;
            float angle = Random.Range(minAngle, maxAngle);
            // Check if the angle is within the forbidden range
            if (angle > gapStart && angle < gapEnd)
            {
                // If the angle is within the forbidden range, skip to the next iteration to regenerate the angle
                continue;
            }

            Vector3 spawnPosition = centerPosition + Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;
            float randomYOffset = Random.Range(-0.25f, 0.25f);
            spawnPosition.y -= (2.5f + randomYOffset);


            // Calculate the random rotation values
            float rotationX = Random.Range(minRotation, maxRotation);
            float rotationY = Random.Range(minRotation, maxRotation);
            float rotationZ = Random.Range(minRotation, maxRotation);
            Quaternion randomRotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

            Instantiate(objectToSpawn, spawnPosition, randomRotation);
        }

        for (int i = 0; i < outerCircleObjectCount; i++)
        {
            
            float distance = Random.Range(outerCircleMinDistance, outerCircleMaxDistance);
            float maxAngle = 360.0f;
            float minAngle = 0.0f;
            float angle = Random.Range(minAngle, maxAngle);
            

            Vector3 spawnPosition = centerPosition + Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;
            float randomYOffset = Random.Range(-0.5f, 0.5f);
            spawnPosition.y -= (2.5f + randomYOffset); 

            // Calculate the random rotation values
            float rotationX = Random.Range(minRotation, maxRotation);
            float rotationY = Random.Range(minRotation, maxRotation);
            float rotationZ = Random.Range(minRotation, maxRotation);
            Quaternion randomRotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

            Instantiate(objectToSpawn, spawnPosition, randomRotation);
        }

    }
}
