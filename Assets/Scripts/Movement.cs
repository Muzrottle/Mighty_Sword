using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 10f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] AudioClip swordFly;
    [SerializeField] AudioClip swordSwing1;
    [SerializeField] AudioClip swordSwing2;

    [SerializeField] ParticleSystem swordFlyParticle;
    [SerializeField] TrailRenderer swingTrail;
    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartTrusting();
        }
        else
        {
            StopTrusting();
        }
    }

    private void StartTrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(swordFly);
        }

        if (!swordFlyParticle.isPlaying)
        {
            swordFlyParticle.Play();
        }
    }

    private void StopTrusting()
    {
        swordFlyParticle.Stop();
        audioSource.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //audioSource.PlayOneShot(swordSwing1);
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //audioSource.PlayOneShot(swordSwing2);
            ApplyRotation(-rotationSpeed);
        }
        else
        {
            swingTrail.enabled = false;
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Freezing rotation so that we can manually rotate.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so that the physics system can take over.
        swingTrail.enabled = true;
    }
}
