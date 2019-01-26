using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    private int type = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START TREAT");
        float treatLife = Random.Range(3.0f, 10.0f);
        InvokeRepeating("destroyTreat", treatLife, treatLife);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public int getType()
    {
        return this.type;
    }

    public void destroyTreat()
    {
        //Debug.Log("DESTROY");
        //Object.Destroy(this.gameObject);
        //GameObject.Find("GameManager").GetComponent<GameManager_Kiwi>().treatNum -= 1;
        //Debug.Log("TREAT NUM: ");
        //Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager_Kiwi>().treatNum);
    }

    public void setType(int type)
    {
        this.type = type;
    }
}
