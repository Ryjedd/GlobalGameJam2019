using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected string type;
	protected new string name;
	protected int dogCount;
	protected int goldTreatCount;
    protected int silverTreatCount;
    protected int bronzeTreatCount;
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
        if(col.gameObject.name.Contains("GoldTreat"))
        {
            isCollide = true;
            Destroy(col.gameObject);
            this.goldTreatCount += 1;
        }

        if (col.gameObject.name.Contains("SilverTreat"))
        {
            isCollide = true;
            Destroy(col.gameObject);
            this.goldTreatCount += 1;
        }

        if (col.gameObject.name.Contains("BronzeTreat"))
        {
            isCollide = true;
            Destroy(col.gameObject);
            this.goldTreatCount += 1;
        }
        Debug.Log("collision name: " + col.gameObject.name);
    }


}
