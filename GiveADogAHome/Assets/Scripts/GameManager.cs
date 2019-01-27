using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeLeft = 120.0f;
    public bool isGameOver = false;
    public Image gameOverScreen;
	public Image playAgain;
	public int min = 0;
	public int sec = 0;
    List<GameObject> dogList = new List<GameObject>();
    public int dogNum = 0;
    private const int MAX_DOGS = 20;
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
    public int treatNum = 0;
    private const int MAX_TREATS = 5;
    public GameObject treat1; //selected in the editor
    public GameObject treat2; //selected in the editor
    public GameObject treat3; //selected in the editor

    private GameObject player1;
    private GameObject player2;
    private float speed = 15.0f;

    public Text player1_goldScore;
    public Text player1_silverScore;
    public Text player1_bronzeScore;
    public Text player1_dogScore;
    public Text player2_goldScore;
    public Text player2_silverScore;
    public Text player2_bronzeScore;
    public Text player2_dogScore;
	public Text WinText;
    public Text Timer;

    // Start is called before the first frame update
    void Start()
    {
        //Setting Player 1
        player1 = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player1.GetComponent<Player>().setCharacter(player1);
        player1.transform.localScale = Vector3.one;

        //Setting Player 2
        player2 = Instantiate(Resources.Load("Prefabs/Player2"), new Vector3(0 - 30.0F, 1, 25), Quaternion.identity) as GameObject;
        player2.GetComponent<Player>().setCharacter(player2);
        player2.transform.localScale = Vector3.one;

        InvokeRepeating("InstantiateDogs", 5.0f, 10.0f);
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
                //Debug.Log(dogType);
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
        } else
        {
            newDogNum = MAX_DOGS - dogNum;
            for (int i = 0; i < newDogNum; i++)
            {
                int dogType = Random.Range(1, 4);
                //Debug.Log(dogType);
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
            for (int i = 0; i < newTreatNum; i++)
            {
                int treatType = Random.Range(1, 4);
                //Debug.Log(treatType);
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
                treatNum += 1;
                ///Debug.Log("ADD 1");
            }
        }
        else
        {
            newTreatNum = MAX_TREATS - treatNum;
            for (int i = 0; i < newTreatNum; i++)
            {
                int treatType = Random.Range(1, 4);
                //Debug.Log(treatType);
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
               // Debug.Log("ADD 2");
                treatNum += 1;
            }
        }
        print("TREAT NUM: " + treatNum);
    }

    void displayPlayer1Text()
    {
        player1_goldScore.text = "Bone Treat: " + player1.GetComponent<Player>().getGoldTreatCount().ToString();
        player1_silverScore.text = "Hotdog Treat: " + player1.GetComponent<Player>().getSilverTreatCount().ToString();
        player1_bronzeScore.text = "Ham Treat: " + player1.GetComponent<Player>().getBronzeTreatCount().ToString();
        player1_dogScore.text = "Dog Score: " + player1.GetComponent<Player>().getDogCount().ToString();
    }

    void displayPlayer2Text()
    {
        player2_goldScore.text = "Bone Treat: " + player2.GetComponent<Player>().getGoldTreatCount().ToString();
        player2_silverScore.text = "Hotdog Treat: " + player2.GetComponent<Player>().getSilverTreatCount().ToString();
        player2_bronzeScore.text = "Ham Treat: " + player2.GetComponent<Player>().getBronzeTreatCount().ToString();
        player2_dogScore.text = "Dog Score: " + player2.GetComponent<Player>().getDogCount().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            gameOverScreen.enabled = false;
			WinText.enabled = false;
			playAgain.enabled = false;
            timeLeft -= Time.deltaTime;
			min = Mathf.FloorToInt(timeLeft / 60);
			sec = Mathf.FloorToInt(timeLeft % 60);
			Timer.text = min.ToString("00") + ":" + sec.ToString("00");
			//Timer.text = "Time Remaining: " + Mathf.Round(timeLeft);
            //getting player1 movement
            float mH1 = Input.GetAxis("Horizontal");
            float mV1 = Input.GetAxis("Vertical");
            Vector3 move1 = new Vector3(mH1,0, mV1);
            if (move1 != Vector3.zero)
                player1.transform.forward = move1;

            //Debug.Log(player1.GetComponent<Rigidbody>().velocity);
            player1.GetComponent<Rigidbody>().velocity = new Vector3(mH1 * speed, player1.GetComponent<Rigidbody>().velocity.y, mV1 * speed);
            player1.GetComponent<Player>().updateWalk(player1.GetComponent<Rigidbody>().velocity.magnitude);
            //Debug.Log("MAGNITUDE: " + player1.GetComponent<Rigidbody>().velocity.magnitude);

            //getting player2 movement
            float mH2 = Input.GetAxis("Horizontal_P2");
            float mV2 = Input.GetAxis("Vertical_P2");
            Vector3 move2 = new Vector3(mH2, 0, mV2);
            if (move2 != Vector3.zero)
                player2.transform.forward = move2;
            player2.GetComponent<Rigidbody>().velocity = new Vector3(mH2 * speed, player2.GetComponent<Rigidbody>().velocity.y, mV2 * speed);
            player2.GetComponent<Player>().updateWalk(player2.GetComponent<Rigidbody>().velocity.magnitude);

			if(!(player2.GetComponent<Player>().getPunch()) && Input.GetKeyDown(KeyCode.LeftShift) && (player2.GetComponent<Player>().getPlayerCollision())){
				Punch(5.0f, player1.transform.forward, player2);
			}
			if(!(player1.GetComponent<Player>().getPunch()) && Input.GetKeyDown(KeyCode.RightShift) && (player1.GetComponent<Player>().getPlayerCollision())){
				Punch(5.0f, player2.transform.forward, player1);
			}
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
			WinText.enabled = true;
			playAgain.enabled = true;

			player1_goldScore.enabled = false;
			player1_silverScore.enabled = false;
			player1_bronzeScore.enabled = false;
			player1_dogScore.enabled = false;
			player2_goldScore.enabled = false;
			player2_silverScore.enabled = false;
			player2_bronzeScore.enabled = false;
			player2_dogScore.enabled = false;
			Timer.enabled = false;

            if (player1Score > player2Score)
            {
                Debug.Log("Player 1 wins!!");
				WinText.text = "player 1 Wins\n" + "Score: " + player1Score;
            }
            else
            {
                Debug.Log("Player 2 wins!!");
				WinText.text = "player 2 Wins\n" + "Score: " + player2Score;
            }
        }

		void Punch(float distance, Vector3 direction, GameObject player){
			player.GetComponent<Player>().setPunch(true);
			float timer = 0;
			Vector3 orgPos = player.GetComponent<Transform>().position;
			direction.Normalize();
			Vector3 newDistance = distance * direction;
			player.GetComponent<Transform>().position = orgPos + newDistance;
			player.GetComponent<Player>().setPunch(false);
			player.GetComponent<Player>().setPlayerCollision(false);
		}
    }
}
