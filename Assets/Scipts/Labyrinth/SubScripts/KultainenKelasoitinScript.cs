using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KultainenKelasoitinScript : MonoBehaviour
{
    private Transform tyhja;
    private Transform taysi;
    private Transform kela;
    private Transform third;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        tyhja = this.transform.Find("Tyhja");
        taysi = this.transform.Find("Taysi");
        kela = this.transform.Find("Kela C");
        third = this.transform.Find("Third Wheel");

        taysi.gameObject.SetActive(false);

        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == kela.gameObject && !activated)
        {
            activated = true;
            taysi.gameObject.SetActive(true);
            kela.gameObject.SetActive(false);
            third.gameObject.SetActive(false);
            SceneManager.LoadScene("HubRoomEnding");
        }
    }
}
