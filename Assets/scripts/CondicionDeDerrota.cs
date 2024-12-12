using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CondicionDeDerrota : MonoBehaviour
{
    private Scene escena;
    static int points = 0;  // ����� ������ ������

    public static int maxPoints = 6; // ���� ������� ����� ����� ����� ���� ���

    void Start()
    {
        escena = SceneManager.GetActiveScene();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // �� ������� �� ����� (��� �� �� �-Tag Block)
        if (col.gameObject.CompareTag("Block"))
        {
            points++;  // ����� �����
            Debug.Log("points: " + points + " maxPOintt " + maxPoints);

            // �� ����� �� ���� ������� ��������, ���� ���� ���
            if (points >= maxPoints)
            {
                points = 0;
                Debug.Log("nextLevel!!!");

                // ���� ����� �� ����� ���� ��� ����� ������� �-Build Settings
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;


                // ���� �� �� ���� ����
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    maxPoints += 6;
                    Debug.Log("maxPoint iss:" + maxPoints);
                    SceneManager.LoadScene(nextSceneIndex); // ���� �� ����� ����
                }
                else
                {
                    Debug.Log("the game is fnishhh!");
                }
            }
        }

        // �� ������ ����� ������
        if (col.gameObject.CompareTag("floor"))
        {
            Debug.Log("start over!");
            points = 0;
            Debug.Log(escena.name);
            SceneManager.LoadScene(escena.name);  // ���� ���� �� ���� ����
        }
    }
}
