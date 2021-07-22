using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLoader : MonoBehaviour
{
	GameManager gameManager;

	public GameObject playerObject;

	public Player player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "Player")
    	{
    		player.myController.enabled = false;
    		playerObject.transform.position = gameManager.checkpoint.location;
    		player.myController.enabled = true;
    	}	    	
    }
}
