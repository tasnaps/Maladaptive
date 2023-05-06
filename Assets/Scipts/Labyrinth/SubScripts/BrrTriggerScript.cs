using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrrTriggerScript : MonoBehaviour
{
    private Transform brr;
    private int border = 20;
    private Vector3 move = new Vector3(0, 0, -0.1F);
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        brr = this.gameObject.transform.parent.gameObject.transform.Find("Brr");
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        
        if (otherCollider.gameObject.tag == "Player" && !done)
        {
            StartCoroutine(LolCoroutine());
        }
    }

    IEnumerator LolCoroutine()
    {
        done = true;
        for (int i = 0; i < border; i++)
        {
            brr.position += move;
            yield return new WaitForSeconds(0.03F);        
        }
    }
}
