using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_P : MonoBehaviour
{

	[Header("Floats")]
	public float moveSpeed;
	public float patrolTime;

	[Header("Patrol Booleans")]
	public bool xPatrol;
	public bool yPatrol;
	public bool zPatrol;

	[Header("References")]
	public Vector3 direction;
	public CharacterController myController;

    // Start is called before the first frame update
    void Start()
    {
       myController = GetComponent <CharacterController>();
       direction = Vector3.left;
       StartCoroutine(xRoutine());
       StartCoroutine(yRoutine());
       StartCoroutine(zRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        myController.Move(direction * Time.deltaTime * moveSpeed);
    }

    IEnumerator xRoutine()
    {
    	while(xPatrol) 
    	{
    		direction = Vector3.right;
    		yield return new WaitForSeconds(patrolTime);

    		direction = Vector3.left;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }

    IEnumerator zRoutine()
    {
    	while(xPatrol) 
    	{
    		direction = Vector3.forward;
    		yield return new WaitForSeconds(patrolTime);
    		direction = Vector3.back;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }

    IEnumerator yRoutine()
    {
    	while(xPatrol) 
    	{
    		direction = Vector3.up;
    		yield return new WaitForSeconds(patrolTime);

    		direction = Vector3.down;
    		yield return new WaitForSeconds(patrolTime);
    	}
    }




}
