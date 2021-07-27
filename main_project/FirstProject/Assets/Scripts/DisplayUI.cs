using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
	public int value;
	public GameObject displayObject;
	CoinManager coinManager;
	GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {	
    	gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        coinManager = gameManager.coinManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    	if(other.tag == "Player")
    	{
    		GainShoe();
    		displayObject.SetActive(true);
    	}
    }

    void GainShoe()
    {
    	coinManager.coinText.text = "$0";
    	Destroy(gameObject);  
    }
}
