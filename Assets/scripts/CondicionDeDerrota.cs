using UnityEngine;
using UnityEngine.SceneManagement;

public class CondicionDeDerrota : MonoBehaviour
{
    private Scene escena; // Stores the current scene

    void Start()
    {
        escena = SceneManager.GetActiveScene(); // Get the active scene
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If colliding with an object tagged as "Block", add a point
        if (col.gameObject.CompareTag("Block"))
        {
            GameManager.instance.AddPoint();
        }

        // If colliding with the floor, restart the level
        if (col.gameObject.CompareTag("floor"))
        {
            Debug.Log("start over!");
            GameManager.instance.ResetPoints();
            SceneManager.LoadScene(escena.name); // Reload the current scene
        }
    }
}
