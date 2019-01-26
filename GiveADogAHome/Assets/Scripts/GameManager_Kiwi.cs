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
        //Setting Player 1
        player1 = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player1.GetComponent<Player>().setCharacter(player1);
        player1.transform.localScale = Vector3.one;

        //Setting Player 2
        player2 = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player2.GetComponent<Player>().setCharacter(player2);
        player2.transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        //getting player1 movement
        float mH1 = Input.GetAxis("Horizontal");
        float mV1 = Input.GetAxis("Vertical");
        player1.GetComponent<Rigidbody>().velocity = new Vector3(mH1 * speed, player1.GetComponent<Rigidbody>().velocity.y, mV1 * speed);

        //getting player2 movement
        float mH2 = Input.GetAxis("Horizontal_P2");
        float mV2 = Input.GetAxis("Vertical_P2");
        player2.GetComponent<Rigidbody>().velocity = new Vector3(mH2 * speed, player2.GetComponent<Rigidbody>().velocity.y, mV2 * speed);

        Debug.Log("Player 1 Score: " + player1.GetComponent<Player>().getGoldTreatCount());
        Debug.Log("Player 2 Score: " + player2.GetComponent<Player>().getGoldTreatCount());
    }
}
