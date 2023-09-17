using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;
    [SerializeField] AudioClip swordHit;
    [SerializeField] AudioClip win;
    [SerializeField] GameObject bonfireParticle;
    [SerializeField] GameObject bonfireLight;

    AudioSource audioSource;
    Rigidbody rb;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //We are storing collided part to know that the collided part of the sword is the blade.
        Collider collidedSwordPart = collision.GetContact(0).thisCollider; 

        if (collidedSwordPart.CompareTag("Blade") && !collisionDisabled)
        {
            if (!collision.gameObject.CompareTag("Friendly"))
            {
                rb.isKinematic = true;
            }
        }
        
        if (isTransitioning || collisionDisabled) 
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You collided with a Friendly object.");
                break;
            case "Fuel":
                Debug.Log("You collected a Fuel.");
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    private void StartCrashSequence()
    {
        //TODO
        //Add SoundFX Upon Crash.
        //Add Particle Effect Upon Crash.
        //Add Stuck After Collision.

        audioSource.Stop();
        audioSource.PlayOneShot(swordHit);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void StartFinishSequence()
    {
        //TODO
        //Add SoundFX Upon Crash.
        //Add Particle Effect Upon Crash.
        //Add Stuck After Collision.

        audioSource.Stop();
        audioSource.PlayOneShot(swordHit);
        audioSource.PlayOneShot(win);
        bonfireParticle.SetActive(true);
        bonfireLight.SetActive(true);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        

        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        Debug.Log("You collided with a Obstacle. You got stuck.");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        Debug.Log("You finished the game.");
        
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {

            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
