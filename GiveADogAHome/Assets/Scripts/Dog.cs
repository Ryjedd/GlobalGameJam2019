using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{	
	protected int type;
	protected bool ownerTreats;
	protected new string name;
    public int speed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(int dogType)
    {
        this.type = dogType;
    }

    public string getName(){
		return this.name;
	}

	public int getType(){
		return this.type;
	}

	public bool getOwnerTreats(){
		return this.ownerTreats;
	}

	public void setName(string name){
		this.name = name;
	}
		
}
