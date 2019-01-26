﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 10;
    private const int MAX_DOGS = 50;
    public GameObject dog; //selected in the editor

    List<GameObject> treatList = new List<GameObject>();
    public int treatNum = 5;
    private const int MAX_TREATS = 10;
    public GameObject treat; //selected in the editor

    // Start is called before the first frame update
    void Start()
    {

        //GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
        //dog.GetComponent<Dog>().setName("kiwidog");
        //Debug.Log(dog.GetComponent<Dog>().getName());


        InvokeRepeating("InstantiateDogs", 0.0f, 10.0f);
        GameObject player1 = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
        Debug.Log("player position" + player1.GetComponent<Transform>());
        dog.GetComponent<Dog>().setName("kiwi");
        Debug.Log("player name: " + player1.GetComponent<Player>().getName());
        InvokeRepeating("InstantiateTreats", 0.0f, 5.0f);
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

    void InstantiateTreats()
    {
        //instantiate dogs
        int newTreatNum = Random.Range(1, 4);
        if (newTreatNum + treatNum <= MAX_TREATS)
        {
            for (int i = 0; i < treatNum; i++)
            {
                GameObject go = Instantiate(treat, new Vector3(Random.Range(20.0f, 65.0f), 1.0f, Random.Range(-25.0f, 32.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                treatList.Add(go);
            }
            treatNum += newTreatNum;
        }
        else if (treatNum < MAX_TREATS)
        {
            newTreatNum = MAX_TREATS - treatNum;
            for (int i = 0; i < treatNum; i++)
            {
                GameObject go = Instantiate(treat, new Vector3(Random.Range(20.0f, 65.0f), 1.0f, Random.Range(-25.0f, 32.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                treatList.Add(go);
            }
            treatNum = MAX_TREATS;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
