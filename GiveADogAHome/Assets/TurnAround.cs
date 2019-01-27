using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "dog1" || col.gameObject.tag == "dog2" || col.gameObject.tag == "dog3")
        {
            //Debug.Log("TURN AROUND");
            col.gameObject.GetComponent<Wander>().TurnAround();
        }
    }
}
