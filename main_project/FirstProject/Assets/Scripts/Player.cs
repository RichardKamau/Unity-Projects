using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// Naming CharacterController Variable
	
	//Movement Variables
	[Header("Movement variables")]
	// Speed of character
	public float speed;


	[Header("Dashing Variables")]
	public float dashSpeed;

	public bool canDashLeft;

	public bool canDashRight;

	public bool canDashForward;

	public bool canDashBack;

	public float dashWaitTime;

	public float dashCoolDown;

	public bool canDash;


	[Header("Jumping Variables")]
	public float yForce;

	public float yGravity;

	public float maxGravity;

	public float jumpSpeed;

	public bool isJumping;

	public LayerMask groundLayer;



	[Header("References")]

	CharacterController myController;

	DoubleJump doubleJump;



    // Start is called before the first frame update
    void Start()
    {
    	// Adding a value to CharacterController
        myController = GetComponent <CharacterController>();

        doubleJump = GetComponent <DoubleJump>();

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // setting keybinds for movement
        if (Input.GetKey(KeyCode.W))
        {
        	MoveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
        	MoveBack();
        }

        if (Input.GetKey(KeyCode.A))
        {
        	MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
        	MoveRight();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
        	if(!isJumping)
        	{
        		Jump();
        	}
        	else
        	{
        		if(doubleJump.available)
        		{
        			doubleJump.available = false;
        			Jump();
        		}
        	}
        }
        

       	//if the palyer is on the grounded set is jumping to false

    	if(myController.isGrounded && yForce < 0)
    	{
    		isJumping = false;
    		doubleJump.available = true;
    	}

    	if(!myController.isGrounded)
    	{
    		//mathf takes the largest of the two values
    		//gravity is building up oveertime, yForce + y Gravity - Positive + negative.
    		yForce = Mathf.Max(maxGravity, yForce + (yGravity * Time.deltaTime));
    	}

    	//Apply y Force to the Player
    	myController.Move(Vector3.up * yForce * Time.deltaTime);

    	if(Input.GetKeyDown(KeyCode.W))
    	{
    		if(canDashForward)
    		{
    			Dash(Vector3.forward);
    		}
    		else
    		{
    			canDashForward = true;
    			StartCoroutine(DisableDashRoutine());
    		}

    	}

    	if(Input.GetKeyDown(KeyCode.A))
    	{
    		if(canDashLeft)
    		{
    			Dash(Vector3.left);
    		}
    		else
    		{
    			canDashLeft = true;
    			StartCoroutine(DisableDashRoutine());
    		}
    		
    	}

    	if(Input.GetKeyDown(KeyCode.D))
    	{
    		if(canDashRight)
    		{
    			Dash(Vector3.right);
    		}
    		else
    		{
    			canDashRight = true;
    			StartCoroutine(DisableDashRoutine());
    		}
    		
    	}

    	if(Input.GetKeyDown(KeyCode.S))
    	{
    		if(canDashBack)
    		{
    			Dash(Vector3.back);
    		}
    		else
    		{
    			canDashBack = true;
    			StartCoroutine(DisableDashRoutine());
    		}
    		
    	}

    }


    void Jump(){
    	isJumping = true;
    	yForce = jumpSpeed;
    }

    // moving in all directions
    void MoveForward()
    {
    	myController.Move(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveBack()
    {
    	myController.Move(Vector3.back * Time.deltaTime * speed);
    }

    void MoveLeft()
    {
    	myController.Move(Vector3.left * Time.deltaTime * speed);
    }

    void MoveRight()
    {
    	myController.Move(Vector3.right * Time.deltaTime * speed);
    }

    void Dash(Vector3 direction)
    {
    	myController.Move(direction * Time.deltaTime * dashSpeed);

    	DisableDash();
    }

    void DisableDash()
    {
    	canDashBack = false;

    	canDashForward = false;

    	canDashRight = false;

    	canDashLeft = false;
    }

    IEnumerator DisableDashRoutine()
    {
    	yield return new WaitForSeconds(dashWaitTime);
    	DisableDash();
    }

    IEnumerator CoolingDashDown()
    {
    	yield return new WaitForSeconds(dashCoolDown);
    	DisableDash();
    }



}
