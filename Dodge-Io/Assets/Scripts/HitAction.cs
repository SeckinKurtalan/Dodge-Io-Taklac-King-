using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAction : MonoBehaviour
{
    public GameObject player;
    private bool hitStatus=false;
    public bool GameOverStatus = false;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitStatus)
        {
            player.SetActive(false);
            GameOverStatus = true;
        }
    }


    private void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            hitStatus = true;
        }

    }
    
    private void OnTriggerExit(Collider Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            hitStatus = false;
        }
    }

}