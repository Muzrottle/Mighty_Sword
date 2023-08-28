using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You collided with a Friendly object.");
                break;
            case "Fuel":
                Debug.Log("You collected a Fuel.");
                break;
            case "Finish":
                Debug.Log("You finished the game.");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel()
    {
        Debug.Log("You collided with a Obstacle. You got stuck.");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
