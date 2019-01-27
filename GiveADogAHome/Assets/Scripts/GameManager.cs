using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeLeft = 30.0f;
    public bool isGameOver = false;
    public Image gameOverScreen;

    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 10;
    private const int MAX_DOGS = 50;
    public GameObject smallDog1; //selected in the editor
    public GameObject smallDog2; //selected in the editor
    public GameObject smallDog3; //selected in the editor
    public GameObject medDog1; //selected in the editor
    public GameObject medDog2; //selected in the editor
    public GameObject medDog3; //selected in the editor
    public GameObject largeDog1; //selected in the editor
    public GameObject largeDog2; //selected in the editor
    public GameObject largeDog3; //selected in the editor

    List<GameObject> treatList = new List<GameObject>();
    public int treatNum = 5;
    private const int MAX_TREATS = 10;
    public GameObject treat1; //selected in the editor
    public GameObject treat2; //selected in the editor
    public GameObject treat3; //selected in the editor

    private GameObject player1;
    private GameObject player2;
    private float speed = 10.0f;

    public Text player1_goldScore;
    public Text player1_silverScore;
    public Text player1_bronzeScore;
    public Text player1_dogScore;
    public Text player2_goldScore;
    public Text player2_silverScore;
    public Text player2_bronzeScore;
    public Text player2_dogScore;
    public Text Timer;

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

        InvokeRepeating("InstantiateDogs", 0.0f, 10.0f);
        InvokeRepeating("InstantiateTreats", 0.0f, 5.0f);
    }


    void InstantiateDogs()
    {
        //instantiate dogs
        int newDogNum = Random.Range(1, 5);
        if (newDogNum + dogNum <= MAX_DOGS)
        {
            for (int i = 0; i < newDogNum; i++)
            {
                int dogType = Random.Range(1, 4);
                Debug.Log(dogType);
                GameObject dog;
                int dogModelNum = Random.Range(1, 4);
                if (dogType == 1)
                {
                    if (dogModelNum == 1)
                    {
                        dog = smallDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = smallDog2;
                    }
                    else
                    {
                        dog = smallDog3;
                    }
                }else if(dogType == 2)
                {
                    if (dogModelNum == 1)
                    {
                        dog = medDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = medDog2;
                    }
                    else
                    {
                        dog = medDog3;
                    }
                }
                else
                {
                    if (dogModelNum == 1)
                    {
                        dog = largeDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = largeDog2;
                    }
                    else
                    {
                        dog = largeDog3;
                    }
                }
                GameObject go = Instantiate(dog, new Vector3((float)i - 5.0F, 1, 30), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                
                go.GetComponent<Wander>().setup(dogType);
                go.GetComponent<Dog>().setup(dogType);
                dogList.Add(go);
            }
            dogNum += newDogNum;
        } else if(dogNum < MAX_DOGS)
        {
            newDogNum = MAX_DOGS - dogNum;
            for (int i = 0; i < newDogNum; i++)
            {
                int dogType = Random.Range(1, 4);
                Debug.Log(dogType);
                GameObject dog;
                int dogModelNum = Random.Range(1, 4);
                if (dogType == 1)
                {
                    if (dogModelNum == 1)
                    {
                        dog = smallDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = smallDog2;
                    }
                    else
                    {
                        dog = smallDog3;
                    }
                }
                else if (dogType == 2)
                {
                    if (dogModelNum == 1)
                    {
                        dog = medDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = medDog2;
                    }
                    else
                    {
                        dog = medDog3;
                    }
                }
                else
                {
                    if (dogModelNum == 1)
                    {
                        dog = largeDog1;
                    }
                    else if (dogModelNum == 2)
                    {
                        dog = largeDog2;
                    }
                    else
                    {
                        dog = largeDog3;
                    }
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

                GameObject go = Instantiate(treat, new Vector3(Random.Range(30.0f, 60.0f), 1.0f, Random.Range(-20.0f, 36.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                go.GetComponent<Treat>().setType(treatType);
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

                GameObject go = Instantiate(treat, new Vector3(Random.Range(30.0f, 60.0f), 1.0f, Random.Range(-20.0f, 36.0f)), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                go.GetComponent<Treat>().setType(treatType);
                treatList.Add(go);
            }
            treatNum = MAX_TREATS;
        }
    }

    void displayPlayer1Text()
    {
        player1_goldScore.text = "GoldTreat: " + player1.GetComponent<Player>().getGoldTreatCount().ToString();
        player1_silverScore.text = "silverTreat: " + player1.GetComponent<Player>().getSilverTreatCount().ToString();
        player1_bronzeScore.text = "bronzeTreat: " + player1.GetComponent<Player>().getBronzeTreatCount().ToString();
        player1_dogScore.text = "Dog Score: " + player1.GetComponent<Player>().getDogCount().ToString();
    }

    void displayPlayer2Text()
    {
        player2_goldScore.text = "GoldTreat: " + player2.GetComponent<Player>().getGoldTreatCount().ToString();
        player2_silverScore.text = "silverTreat: " + player2.GetComponent<Player>().getSilverTreatCount().ToString();
        player2_bronzeScore.text = "bronzeTreat: " + player2.GetComponent<Player>().getBronzeTreatCount().ToString();
        player2_dogScore.text = "Dog Score: " + player2.GetComponent<Player>().getDogCount().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            gameOverScreen.enabled = false;
            timeLeft -= Time.deltaTime;
            Timer.text = "Time Remaining: " + Mathf.Round(timeLeft);
            Debug.Log(timeLeft);
            //getting player1 movement
            float mH1 = Input.GetAxis("Horizontal");
            float mV1 = Input.GetAxis("Vertical");
            player1.GetComponent<Rigidbody>().velocity = new Vector3(mH1 * speed, player1.GetComponent<Rigidbody>().velocity.y, mV1 * speed);

            //getting player2 movement
            float mH2 = Input.GetAxis("Horizontal_P2");
            float mV2 = Input.GetAxis("Vertical_P2");
            player2.GetComponent<Rigidbody>().velocity = new Vector3(mH2 * speed, player2.GetComponent<Rigidbody>().velocity.y, mV2 * speed);

            displayPlayer1Text();
            displayPlayer2Text();
            if (timeLeft < 0)
            {
                gameOver();
            }
        }

        void gameOver()
        {
            isGameOver = true;
            int player1Score = player1.GetComponent<Player>().getDogCount();
            int player2Score = player2.GetComponent<Player>().getDogCount();

            gameOverScreen.enabled = true;
            if (player1Score > player2Score)
            {
                Debug.Log("Player 1 wins!!");
            }
            else
            {
                Debug.Log("Player 2 wins!!");
            }
        }
    }
}
