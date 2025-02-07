using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GunPicker : MonoBehaviour
{
    public string CurrentCollidingGun = "None";

    [SerializeField] GunSpawnGenerator gunSpawnCountController;
    
    [SerializeField] GunShooter GameManagerShooter;

    public UnityEvent pickUpGun;

    public bool gunPickStatus;

    [SerializeField] PlayerMovement animatorBringer;
    void Start()
    {
        
    }

    
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider collider)
    {
         if(collider.gameObject.tag == "Gun")
        {
            animatorBringer.anim.SetLayerWeight(1, 1);
            gunPickStatus = true;
            CurrentCollidingGun = collider.gameObject.name;
            collider.gameObject.SetActive(false);
            pickUpGun.Invoke();
            gunSpawnCountController.spawnCount--;
            int listCount = gunSpawnCountController.spawnedGuns.Count;
            gunSpawnCountController.spawnedGuns.RemoveAt(listCount-1);
        }
            

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Gun")
        {
            gunPickStatus = false;
            CurrentCollidingGun = "None";
        }
    }


    public void PassTheGunName()
    {
        GameManagerShooter.firingGunName = CurrentCollidingGun;
        
    }

}
