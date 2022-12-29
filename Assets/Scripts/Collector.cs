using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	
    }
    void OnCollisionEnter2D(Collision2D target)
	{
		print("target " + target.gameObject.name + " " + target.gameObject.tag);
		if (target.gameObject.tag == "Enemy")
		{
			Destroy(target.gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
		}
	}
}
