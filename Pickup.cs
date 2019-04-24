using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int pickupScore;

    private GameController gameController;
    private PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {

            return;
        }
        if (other.CompareTag("Player")){

            playerController.fireRate *= 2;
            Debug.Log("test");
        }
        Destroy(gameObject);
    }
}
