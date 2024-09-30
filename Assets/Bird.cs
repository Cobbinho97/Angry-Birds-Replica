using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 initialPosition;

    [SerializeField] private float launchPower = 500;

    private bool birdWasLaunched;

    private float waitingTime;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1 , initialPosition);
        GetComponent<LineRenderer>().SetPosition(0 , transform.position);

        if (birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            waitingTime += Time.deltaTime;
        }

        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || waitingTime > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        Vector2 directionToPosition = initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToPosition * launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
