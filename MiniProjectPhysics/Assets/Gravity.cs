using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    GameObject[] objects;//Array of all other object in the scene

    float G = 6.673e-8f;//Graviation constant reduced due to scale
    float scaleMultiplier = 5000;//Used to increase attraction due to scale(same in all scripts)

    Vector3 gravity;//Variable to accumulate gravity of all objects

    // Start is called before the first frame update
    void Start()
    {
        objects=GameObject.FindGameObjectsWithTag("Object");
        gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        gravity = Vector3.zero;
        foreach(GameObject go in objects)
        {
            if (go != this.gameObject)
            {
                Vector3 u = this.transform.position - go.transform.position;
                float r = u.magnitude;
                u.Normalize();
                u = u * scaleMultiplier;

                gravity += (G * (go.GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass / (r * r))) * -u;
            }
        }
        GetComponent<Rigidbody>().AddForce(gravity*Time.deltaTime, ForceMode.Impulse);
    }
}
