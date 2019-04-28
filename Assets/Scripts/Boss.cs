using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int health;

    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Boundary")
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Bolt"))
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            health -= 1;
            if (health <= 0)
            {
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
        Destroy(other.gameObject);
    }
}