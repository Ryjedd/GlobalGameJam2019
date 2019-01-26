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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 1)
        {
            //col.gameObject.GetComponent<Treat>().destroyTreat();
            Destroy(col.gameObject);
            this.goldTreatCount += 1;
        }
        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 2)
        {
            Destroy(col.gameObject);
            this.silverTreatCount += 1;
        }
        if (col.gameObject.name.Contains("Treat") && col.gameObject.GetComponent<Treat>().getType() == 3)
        {
            Destroy(col.gameObject);
            this.bronzeTreatCount += 1;
        }
        if (col.gameObject.name.Contains("Dog1")){
            if(this.goldTreatCount > 0)
            {
                Destroy(col.gameObject);
                this.dogCount += 1;
                this.goldTreatCount -= 1;
            }
        }
        if (col.gameObject.name.Contains("Dog2")){
            if (this.silverTreatCount > 0)
            {
                Destroy(col.gameObject);
                this.dogCount += 1;
                this.silverTreatCount -= 1;
            }
        }
        if (col.gameObject.name.Contains("Dog3")){
            if(this.bronzeTreatCount > 0)
            {
                Destroy(col.gameObject);
                this.dogCount += 1;
                this.bronzeTreatCount -= 1;
            }
        }
        Debug.Log("collision name: " + col.gameObject.name);
    }


}
