using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CondicionDeDerrota : MonoBehaviour
{
    private Scene escena;
    static int points = 0;  // משתנה לספירת נקודות

    public static int maxPoints = 6; // מספר הנקודות שצריך להשיג לעבור לשלב הבא

    void Start()
    {
        escena = SceneManager.GetActiveScene();
        
    }

    void OnCollisionEnter2D(Collision2D col)  
    {
        // אם התנגשנו עם קוביה (שיש לה את ה-Tag Block)
        if (col.gameObject.CompareTag("Block"))
        {
            points++;  // הוספת נקודה
            Debug.Log("points: " + points+" maxPOintt "+maxPoints );
           
            // אם השגנו את מספר הנקודות המקסימלי, ניגש לשלב הבא
            if (points >= maxPoints)
            {
                points = 0;
                Debug.Log("nextLevel!!!");

                // אפשר להטען את הסצנה הבאה לפי סצנות שנמצאות ב-Build Settings
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                

                // בודק אם יש סצנה הבאה
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    maxPoints += 6;
                    Debug.Log("maxPoint iss:"+maxPoints);
                    SceneManager.LoadScene(nextSceneIndex); // טוען את הסצנה הבאה
                }
                else
                {
                    Debug.Log("the game is fnishhh!");
                }
            }
        }

        // אם הקוביה פוגעת בריצפה
        if (col.gameObject.CompareTag("floor"))
        {
            Debug.Log("start over!");
            points = 0;
            Debug.Log(escena.name);
            SceneManager.LoadScene(escena.name);  // טוען מחדש את אותה סצנה
        }
    }
}
