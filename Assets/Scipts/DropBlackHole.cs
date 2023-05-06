using UnityEngine;
using UnityEngine.SceneManagement;

public class DropBlackHole : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed = 5f;

    private bool shouldMove = true;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        shouldMove = true;
    }

    private void Update()
    {
        if (shouldMove)
        {
            Vector3 direction = targetPosition - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}