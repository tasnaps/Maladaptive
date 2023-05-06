using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubRoomEndingOutroTrigger : MonoBehaviour {
    public GameObject playerObject; // The object that will trigger the scene change

    void OnTriggerEnter(Collider other){
        if(other.gameObject == playerObject) {
            GameObject myObject = GameObject.Find(gameObject.name);
            string pathToScene = myObject.GetComponent<ScenePathVariable>().pathToScene;
            Debug.Log("Travelling to :" + pathToScene);
            SceneManager.LoadScene (sceneName: pathToScene);
        }
    }
}