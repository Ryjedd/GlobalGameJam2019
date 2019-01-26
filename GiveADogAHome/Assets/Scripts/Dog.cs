using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{	
	protected string type;
	protected bool ownerTreats;
	protected new string name;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public string getName(){
		return this.name;
	}

	public string getType(){
		return this.type;
	}

	public bool getOwnerTreats(){
		return this.ownerTreats;
	}

	public void setName(string name){
		this.name = name;
	}
		
}
