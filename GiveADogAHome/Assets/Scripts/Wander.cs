using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
    public float speed = 5;
    public float directionChangeInterval = .5f;
    public float maxHeadingChange = 360;
    private bool turnAround = false;
    private float mainDirection = 1;
    private float turnTowards = 0;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    public void setup(int dogType)
    {
        speed = Random.Range(5.0f, 10.0f) / dogType;
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
        var forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed);
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
           // Debug.Log("NEW DIRECTION");
            var floor = Mathf.Clamp(0, 0, 360);
            var ceil = Mathf.Clamp(360, 0, 360);
        // Debug.Log("FLOOR: " + floor);
        // Debug.Log("CEIL: " + ceil);
        if (mainDirection == 1)
        {
            Debug.Log("NOT HOME");
            heading = Random.Range(0, 360);
        }
        else
        {
                heading = turnTowards;
                Debug.Log("HOME1");
        }
           // Debug.Log("HEADING: " + heading);
            targetRotation = new Vector3(0, heading, 0);
    }
    
    public void TurnAround()
    {
        Debug.Log("PLEASE TURN AROUND");
        
        
        if (mainDirection == 1)
        {
            int turnDirection = Random.Range(1, 3);
            if (turnDirection == 1)
            {
                turnTowards = 360;
            }
            else
            {
                turnTowards = 0;
            }
            mainDirection = -1;
        }
        
    }

    public void TurnAround2()
    {
        mainDirection = 1;
    }
}