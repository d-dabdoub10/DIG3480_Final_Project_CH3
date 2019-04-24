using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	public float scrollSpeed;
	private float tileSizeZ;
    private GameController obj;

	private Vector3 startPosition;
        
	void Start()
	{
		startPosition = transform.position;
		tileSizeZ = transform.localScale.y;
        obj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

	void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
        if (obj.winCondition == true)
        {
            if(scrollSpeed >= -15)
                scrollSpeed -= Time.deltaTime;
        }
	}
}
