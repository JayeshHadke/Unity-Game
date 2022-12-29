using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	private Transform player;
	private Vector3 tempPos;

	public float minX, maxX;

	private void Awake()
	{
		player = GameObject.FindWithTag("Player").transform;

	}
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{


	}

	 void LateUpdate()
	{
		if (player == null)
			return;
		
		tempPos = transform.position;
		tempPos.x = player.position.x;

		if (tempPos.x < minX)
		{
			tempPos.x = minX;
		}
		if (tempPos.x > maxX)
		{
			tempPos.x = maxX;
		}

		transform.position = tempPos;
	}
	// Start is called before the first frame update
}
