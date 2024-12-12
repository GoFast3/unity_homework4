using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSpawn : MonoBehaviour
{
    private bool condicionMovimientoHorizontal = true; // Controls horizontal movement
    private bool condicionMovimientoVertical = true;   // Controls vertical movement

    public Camera camaraPrincipal; // Reference to the main camera
    [SerializeField] float moveCamera = 0.5f; // Distance the camera moves vertically
    [SerializeField] float moveSpawn = 0.5f;  // Distance the spawn object moves vertically
    [SerializeField] float sideSpanSpeed = 5f; // Speed of horizontal movement
    [SerializeField] float delayTime = 0.3f;   // Delay time before the camera moves

    void Start()
    {
        // Initialization logic can go here
    }

    void Update()
    {
        // If the Space key is pressed and vertical movement is allowed
        if (Input.GetKeyDown(KeyCode.Space) && condicionMovimientoVertical)
        {
            StartCoroutine(MoveWithDelay()); // Start movement with delay
            condicionMovimientoVertical = false; // Prevent further vertical movement until reset
        }

        // Horizontal movement to the right
        if (transform.position.x <= 5 && condicionMovimientoHorizontal)
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpanSpeed);
            if (transform.position.x >= 5)
            {
                condicionMovimientoHorizontal = false; // Switch direction when reaching the right limit
            }
        }

        // Horizontal movement to the left
        if (!condicionMovimientoHorizontal)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * sideSpanSpeed);
            if (transform.position.x <= -5)
            {
                condicionMovimientoHorizontal = true; // Switch direction when reaching the left limit
            }
        }

        condicionMovimientoVertical = true; // Reset vertical movement condition
    }

    IEnumerator MoveWithDelay()
    {
        // Move the spawn object immediately upwards
        transform.Translate(Vector3.up * moveSpawn);

        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Move the camera upwards after the delay
        camaraPrincipal.transform.Translate(Vector3.up * moveCamera);
    }
}
