using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorHandler : MonoBehaviour
{
    public int keyAmount;
    Oscillator oscillator;

    private void Start()
    {
        oscillator = gameObject.GetComponent<Oscillator>();
    }

    public void decreaseKeyCounter()
    {
        keyAmount -= 1;

        if (keyAmount == 0)
        {
            oscillator.enabled = true;
        }
    }
}
