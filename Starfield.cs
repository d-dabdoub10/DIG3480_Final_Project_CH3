using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour {

    private GameController obj;
    private ParticleSystem ps; 
    private float hSliderValue = 1.0F;

    // Use this for initialization
    void Start () {
        obj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ps = GetComponent<ParticleSystem>();

        var main = ps.main; 
        main.simulationSpeed = hSliderValue;

    }

    // Update is called once per frame
    void Update () {
        if (obj.winCondition == true)
        {
            if (hSliderValue <= 15)
            {
                hSliderValue += Time.deltaTime;
            }
        }
    }
}