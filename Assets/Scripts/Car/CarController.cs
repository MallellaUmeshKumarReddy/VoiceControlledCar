using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 10f;       
    public float acceleration = 2f;    
    public float deceleration = 1f;    

    public float currentSpeed = 0f;    
    private string lastCommand = "";   

    public float CurrentSpeed => currentSpeed; 




    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed < maxSpeed)
                currentSpeed += acceleration * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime;  
        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime;
            if (currentSpeed < 0)
                currentSpeed = 0; 
        }

        if (currentSpeed > 0)
        {
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
    }

    public void SetMovement(string command)
    {
        command = command.ToLower();

        if (command.Contains("go"))
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
        }

        else if (command.Contains("stop"))
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
            }
        }

        if (currentSpeed > 0)
        {
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
        }

        if (command.Contains("left") && lastCommand != "left")
        {
            TurnLeft();
            lastCommand = "left";
        }
        else if (command.Contains("right") && lastCommand != "right")
        {
            TurnRight();
            lastCommand = "right";
        }
        else if (!command.Contains("left") && !command.Contains("right"))
        {
            lastCommand = "";
        }
    }

    void TurnLeft()
    {
        transform.Rotate(0, 0, 90); 
    }

    void TurnRight()
    {
        transform.Rotate(0, 0, -90); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            //Debug.Log("Game Over Player Won");
            RaceManager.Instance.FinishRace();
        }
    }

}
