using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
		
		GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
		dog.GetComponent<Dog>().setName("kiwidog");
		Debug.Log(dog.GetComponent<Dog>().getName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
