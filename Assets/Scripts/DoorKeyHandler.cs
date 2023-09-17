using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyHandler : MonoBehaviour
{
    [SerializeField] GameObject[] lockedDoor;
    LockedDoorHandler doorUnlockHandler;
    bool isKeySliced = false;

    private void Start()
    {
        //Get the script from the door that is locked by this key.
        foreach (GameObject door in lockedDoor)
        {
            doorUnlockHandler = door.GetComponent<LockedDoorHandler>();
            //We do this because there could be more than 1 key. So it must know how many keys it takes to open it.
            doorUnlockHandler.keyAmount += 1;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade") && !isKeySliced)
        {
            isKeySliced = true;

            foreach (GameObject door in lockedDoor)
            {
                doorUnlockHandler = door.GetComponent<LockedDoorHandler>();
                doorUnlockHandler.decreaseKeyCounter();
            }
        }
    }
}
