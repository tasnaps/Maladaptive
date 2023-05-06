using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTestScript : MonoBehaviour
{
    public bool access = false;
    private bool applied = false;

    void Update()
    {
        if (access && !applied)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -10);
            access = false;
            applied = true;
        }
    }
}
