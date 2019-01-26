using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Kiwi : MonoBehaviour
{
    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 10;
    private const int MAX_DOGS = 50;
    private GameObject player1;
    private GameObject player2;
    private float speed = 6.0f;
    //public GameObject dog; //selected in the editor
    // Start is called before the first frame update
    void Start()
    {

        //GameObject dog = (GameObject)Instantiate(Resources.Load("Prefabs/Dog")); 
        //dog.GetComponent<Dog>().setName("kiwidog");
        //Debug.Log(dog.GetComponent<Dog>().getName());


        //InvokeRepeating("InstantiateDogs", 0.0f, 10.0f);
        player1 = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player1.GetComponent<Player>().setCharacter(player1);
        player1.transform.localScale = Vector3.one;
        player1.GetComponent<Player>().setName("kiwi");
        
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
        Debug.Log(player1.GetComponent<Player>().getTreatCount());
    }
}
