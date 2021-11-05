using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    Vector3 _initialPosition;
    private bool _birdLaunched;
    private float _timesittingAround;

    [SerializeField] private float _launchPower = 500;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }


    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;

        Vector2 directionToInitialPosition = _initialPosition - transform.position ;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;

        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y);
    }
    // This method uses: It will be used 100 per second. When the game will start and the birds will be thrown out of the map it will
    // reset the game and gave the player another chance to finish the level
    private void Update()
    {

        // Setting a line for launching the bird
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        


        // If the bird is idle this method will be pushed

        if (_birdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timesittingAround += Time.deltaTime;
        }


        if (transform.position.y > 10 ||
            transform.position.y < -10 || 
            transform.position.x > 10 || 
            transform.position.x < -20 || 
            _timesittingAround > 3)

        {
            string resetScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(resetScene);
        }


    }
}
