using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) 
        {
            return;
        }

        float cycles = Time.time / period; //Contiunally growing over time.
        
        const float tau = Mathf.PI * 2; // Constant value of 6.283
        float rawSineWave = Mathf.Sin(cycles * tau); // Going -1 to 1.

        movementFactor = (rawSineWave + 1f) / 2f; // Recalculated to go from 0 from 1 so its cleaner. 

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
