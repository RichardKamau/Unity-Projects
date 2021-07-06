using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{

	[Header("Floats")]
	public float moveSpeed;

	public float patrolTime;

	[Header("Patrol Booleans")]
	public bool xPatrol;

	public bool yPatrol;
	
	public bool zPatrol;
	
	public bool movePlayer;

	[Header("References")]
	public Vector3 direction;
	
	public CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(xRoutine());
       StartCoroutine(zRoutine());
       StartCoroutine(yRoutine());

       playerController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        if (movePlayer)
        {
        	playerController.Move(direction * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator xRoutine()
    {
    	while(xPatrol) 
    	{
    		direction = Vector3.left;
    		yield return new WaitForSeconds(patrolTime);

    		direction = Vector3.right;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }

    IEnumerator zRoutine()
    {
    	while(zPatrol) 
    	{
    		direction = Vector3.forward;
    		yield return new WaitForSeconds(patrolTime);
    		direction = Vector3.back;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }

    IEnumerator yRoutine()
    {
    	while(yPatrol) 
    	{
    		direction = Vector3.up;
    		yield return new WaitForSeconds(patrolTime);

    		direction = Vector3.down;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }




}
