using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] dogArray;
    public int dogNum = 10;
    public GameObject dog; //selected in the editor

    // Start is called before the first frame update
    void Start()
    {
		
		//GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
		//dog.GetComponent<Dog>().setName("kiwidog");
		//Debug.Log(dog.GetComponent<Dog>().getName());

        //instantiate dogs
        dogArray = new GameObject[dogNum];
        for (int i = 0; i < dogNum; i++)
        {
            GameObject go = Instantiate(dog, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
            go.transform.localScale = Vector3.one;
            dogArray[i] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
