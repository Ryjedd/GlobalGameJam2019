using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected string type;
	protected new string name;
	protected int dogCount;
	protected int treatCount;
	protected float speed;
    protected GameObject character;
    protected bool isCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
	public int getTreatCount(){
		return this.treatCount;
	}
	public float getSpeed(){
		return this.speed;
	}
    public void setName(string name)
    {
        this.name = name;
    }

    public void setCharacter(GameObject character)
    {
        this.character = character;
    }

    public bool getCollide()
    {
        return this.isCollide;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "GoldTreat")
        {
            isCollide = true;
            Destroy(col.gameObject);
            treatCount += 1;
        }
        Debug.Log("collision name: " + col.gameObject.name);
    }


}
