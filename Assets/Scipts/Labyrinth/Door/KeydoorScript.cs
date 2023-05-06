using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeydoorScript : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private bool open;
    [SerializeField] private int newMin = 0;
    [SerializeField] private int newMax = 360;
    private RotatingRestriction restriction;

    void Start()
    {
        restriction = this.gameObject.GetComponent<RotatingRestriction>();
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject == key)
        {
            Destroy(otherCollider.gameObject);
            // Door is opened, work according to open
            if (open)
            {
                restriction.restrictionMax = newMax;
                restriction.restrictionMin = newMin;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
