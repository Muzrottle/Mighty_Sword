using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject sword;
    BoxCollider[] swordColliders;

    private void Start()
    {
        swordColliders = sword.GetComponentsInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
    }

    private void DebugKeys()    
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            if (nextSceneIndex == totalScenes)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (var collider in swordColliders)
            {
                collider.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
