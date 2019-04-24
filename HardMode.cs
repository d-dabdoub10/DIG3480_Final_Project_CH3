using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour
{

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void Activate()
    {
        gameController.hardMode = true;
    }
}
