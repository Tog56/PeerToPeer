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

    //G�r med WASD genom ett inputsystem
    private void Walk() 
    {
        movVec = action.ReadValue<Vector2>();
        rigbod.transform.position += new Vector3(movVec.x, 0, movVec.y) * Time.fixedDeltaTime * speed;
    }

    //H�r �r jump funktionen som g�r att kuben kan hoppa genom anv�ndning av rigidbodyn
    //H�ll ned space f�r att g�ra detta 
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

    //H�r kommer kuben f� �kad hastighet genom att �ka speed
    //h�ll ned shift f�r att g�ra detta 
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

    //H�r kommmer kubens hastighet saktas ned genom att s�nka speed
    //H�ll ned K f�r att g�ra detta 
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
