
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    void OnTriggerEnter(Collider other){
        
        GameObject myObject = GameObject.Find(gameObject.name);
        string pathToScene = myObject.GetComponent<ScenePathVariable>().pathToScene;
        Debug.Log("Travelling to :" + pathToScene);
        SceneManager.LoadScene (sceneName: pathToScene);
        
    }

}