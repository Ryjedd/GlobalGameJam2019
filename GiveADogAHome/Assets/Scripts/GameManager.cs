using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 10;
    private const int MAX_DOGS = 50;
    public GameObject dog; //selected in the editor

    // Start is called before the first frame update
    void Start()
    {

        //GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
        //dog.GetComponent<Dog>().setName("kiwidog");
        //Debug.Log(dog.GetComponent<Dog>().getName());


        InvokeRepeating("InstantiateDogs", 0.0f, 10.0f);
    }


    void InstantiateDogs()
    {
        //instantiate dogs
        int newDogNum = Random.Range(5, 15);
        if (newDogNum + dogNum <= MAX_DOGS)
        {
            for (int i = 0; i < dogNum; i++)
            {
                GameObject go = Instantiate(dog, new Vector3((float)i - 30.0F, 1, 25), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                dogList.Add(go);
            }
            dogNum += newDogNum;
        } else if(dogNum < MAX_DOGS)
        {
            newDogNum = MAX_DOGS - dogNum;
            for (int i = 0; i < dogNum; i++)
            {
                GameObject go = Instantiate(dog, new Vector3((float)i - 30.0F, 1, 25), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                dogList.Add(go);
            }
            dogNum = MAX_DOGS;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
