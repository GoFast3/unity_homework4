using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int points = 0;


    [SerializeField] int maxPoints = 6; // Points needed to progress to the next level

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void AddPoint()
    {
        points++; // Increase the player's points
        Debug.Log("Points: " + points + "/" + maxPoints);

        // Check if the player reached the required points to advance
        if (points >= maxPoints)
        {
            NextLevel();
        }
    }

    public void ResetPoints()
    {
        points = 0; // Reset the player's score
    }

    public void NextLevel()
    {
        points = 0; // Reset points before loading the next level
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there is another level available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            maxPoints += 6; // Increase the required points for the next level
            SceneManager.LoadScene(nextSceneIndex); // Load the next scene
        }
        else
        {
            Debug.Log("Game Over! No more levels.");
        }
    }
}
