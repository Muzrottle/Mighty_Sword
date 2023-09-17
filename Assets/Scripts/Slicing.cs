using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicing : MonoBehaviour
{
    bool isSliced = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade") && !isSliced)
        {
            isSliced = true;

            Rigidbody[] childGameObjects = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody gameObject in childGameObjects)
            {
                gameObject.useGravity = true;
                gameObject.isKinematic = false;
            }
        }
    }
}
