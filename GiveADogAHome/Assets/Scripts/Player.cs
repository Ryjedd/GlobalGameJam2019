using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected string type;
	protected new string name;
	protected int dogCount;
	protected int goldTreatCount = 0;
    protected int silverTreatCount = 0;
    protected int bronzeTreatCount = 0;
    protected float speed;
    protected GameObject character;
    protected Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string getType(){
		return this.type;
	}
	public string getName(){
		return this.name;
	}
	public int getDogCount(){
		return this.dogCount;
	}
	public int getGoldTreatCount(){
		return this.goldTreatCount;
	}
    public int getSilverTreatCount()
    {
        return this.silverTreatCount;
    }
    public int getBronzeTreatCount()
    {
        return this.bronzeTreatCount;
    }
    public float getSpeed(){
        
        return this.speed;
	}
    public void setName(string name)
    {
        this.name = name;
    }

    public void updateWalk(float velocity)
    {
        //Debug.Log(velocity);
        animator.SetFloat("Speed", velocity);
    }

    public void setCharacter(GameObject character)
    {
        this.character = character;
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("COLLISION");
        if (col.gameObject.tag == "Door")
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 1)
        {
            col.gameObject.GetComponent<Treat>().destroyTreat();
            //Destroy(col.gameObject);
            this.goldTreatCount += 1;
        }
        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 2)
        {
            col.gameObject.GetComponent<Treat>().destroyTreat();
            //Destroy(col.gameObject);
            this.silverTreatCount += 1;
        }
        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 3)
        {
            col.gameObject.GetComponent<Treat>().destroyTreat();
            //Destroy(col.gameObject);
            this.bronzeTreatCount += 1;
        }

        //Debug.Log("TAG: " + col.gameObject.tag);
        if (col.gameObject.tag == "dog1"){
            if(this.goldTreatCount > 0)
            {
                col.gameObject.GetComponent<Dog>().destroyDog();
                //Destroy(col.gameObject);
                this.dogCount += 1;
                this.goldTreatCount -= 1;
            }
        }
        if (col.gameObject.tag == "dog2"){
            if (this.silverTreatCount > 0)
            {
                col.gameObject.GetComponent<Dog>().destroyDog();
                //Destroy(col.gameObject);
                this.dogCount += 1;
                this.silverTreatCount -= 1;
            }
        }
        if (col.gameObject.tag == "dog3"){
            if(this.bronzeTreatCount > 0)
            {
                col.gameObject.GetComponent<Dog>().destroyDog();
                //Destroy(col.gameObject);
                this.dogCount += 1;
                this.bronzeTreatCount -= 1;
            }
        }
    }


}
