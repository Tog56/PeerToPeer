using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigbod;
    float speed = 2;
    Vector3 movVec;
    PlayerInput playerInput;
    InputAction action;

    Vector3 gravity = new Vector3 (0, -1, 0);
    Vector3 jumpForce = new Vector3 (0, 0.5f, 0);


    void Start()
    {
        rigbod = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        action = playerInput.actions.FindAction("Movement"); 
    }

    void Update()
    {
        Walk();
        Jump();
        Sprint();
        sneak();
    }

    //Går med WASD genom ett inputsystem
    private void Walk() 
    {
        movVec = action.ReadValue<Vector2>();
        rigbod.transform.position += new Vector3(movVec.x, 0, movVec.y) * Time.fixedDeltaTime * speed;
    }

    //Här är jump funktionen som gör att kuben kan hoppa genom användning av rigidbodyn
    //Håll ned space för att göra detta 
    private void Jump() 
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rigbod.transform.position += jumpForce;
        
        }
        if (rigbod.transform.position.y > 1) 
        {
            rigbod.transform.position += gravity;
        
        }
    }

    //Här kommer kuben få ökad hastighet genom att öka speed
    //håll ned shift för att göra detta 
    private void Sprint() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 4;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2;

        }
    }

    //Här kommmer kubens hastighet saktas ned genom att sänka speed
    //Håll ned K för att göra detta 
    private void sneak() 
    { 
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            speed = 0.5f;
        
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            speed = 2;

        }

    }
}
