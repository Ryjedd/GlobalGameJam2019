using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 10;
    private const int MAX_DOGS = 50;
    public GameObject dog1; //selected in the editor
    public GameObject dog2; //selected in the editor
    public GameObject dog3; //selected in the editor

    List<GameObject> treatList = new List<GameObject>();
    public int treatNum = 5;
    private const int MAX_TREATS = 10;
    public GameObject treat1; //selected in the editor
    public GameObject treat2; //selected in the editor
    public GameObject treat3; //selected in the editor

    private GameObject player1;
    private GameObject player2;
    private float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {

        //GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
        //dog.GetComponent<Dog>().setName("kiwidog");
        //Debug.Log(dog.GetComponent<Dog>().getName());
        

        InvokeRepeating("InstantiateDogs", 0.0f, 10.0f);
        InvokeRepeating("InstantiateTreats", 0.0f, 5.0f);

        player1 = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player1.GetComponent<Player>().setCharacter(player1);
        player1.transform.localScale = Vector3.one;
        player1.GetComponent<Player>().setName("kiwi");
    }


    void InstantiateDogs()
    {
        //instantiate dogs
        int newDogNum = Random.Range(5, 15);
        if (newDogNum + dogNum <= MAX_DOGS)
        {
            for (int i = 0; i < dogNum; i++)
            {
                int dogType = Random.Range(1, 4);
                Debug.Log(dogType);
                GameObject dog;
                if (dogType == 1)
                {
                    dog = dog1;
                }else if(dogType == 2)
                {
                    dog = dog2;
                }else
                {
                    dog = dog3;
                }
                GameObject go = Instantiate(dog, new Vector3((float)i - 30.0F, 1, 25), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                
                go.GetComponent<Wander>().setup(dogType);
                go.GetComponent<Dog>().setup(dogType);
                dogList.Add(go);
            }
            dogNum += newDogNum;
        } else if(dogNum < MAX_DOGS)
        {
            newDogNum = MAX_DOGS - dogNum;
            for (int i = 0; i < dogNum; i++)
            {
                int dogType = Random.Range(1, 4);
                Debug.Log(dogType);
                GameObject dog;
                if (dogType == 1)
                {
                    dog = dog1;
                }
                else if (dogType == 2)
                {
                    dog = dog2;
                }
                else
                {
                    dog = dog3;
                }

                GameObject go = Instantiate(dog, new Vector3((float)i - 30.0F, 1, 25), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                go.GetComponent<Wander>().setup(dogType);
                go.GetComponent<Dog>().setup(dogType);
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
                int treatType = Random.Range(1, 4);
                Debug.Log(treatType);
                GameObject treat;
                if (treatType == 1)
                {
                    treat = treat1;
                }
                else if (treatType == 2)
                {
                    treat = treat2;
                }
                else
                {
                    treat = treat3;
                }

                GameObject go = Instantiate(treat, new Vector3(Random.Range(20.0f, 65.0f), 1.0f, Random.Range(-25.0f, 32.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                go.GetComponent<Treat>().setup(treatType);
                treatList.Add(go);
            }
            treatNum += newTreatNum;
        }
        else if (treatNum < MAX_TREATS)
        {
            newTreatNum = MAX_TREATS - treatNum;
            for (int i = 0; i < treatNum; i++)
            {
                int treatType = Random.Range(1, 4);
                Debug.Log(treatType);
                GameObject treat;
                if (treatType == 1)
                {
                    treat = treat1;
                }
                else if (treatType == 2)
                {
                    treat = treat2;
                }
                else
                {
                    treat = treat3;
                }

                GameObject go = Instantiate(treat, new Vector3(Random.Range(20.0f, 65.0f), 1.0f, Random.Range(-25.0f, 32.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                go.GetComponent<Treat>().setup(treatType);
                treatList.Add(go);
            }
            treatNum = MAX_TREATS;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");
            player1.GetComponent<Rigidbody>().velocity = new Vector3(mH * speed, player1.GetComponent<Rigidbody>().velocity.y, mV * speed);
        }
        //Debug.Log(player1.GetComponent<Player>().getTreatCount());
    }
}
