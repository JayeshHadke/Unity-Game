using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponer : MonoBehaviour
{

	public GameObject[] enemies;

	private GameObject enemy;

    private int randomIndex;
    private int randomSide;


	public Transform left, right;
	
	// Start is called before the first frame update
	void Start()
    {

		StartCoroutine(SpawnEnemy());
	}


    IEnumerator SpawnEnemy() {
		while (true) {

			yield return new WaitForSeconds(Random.Range(1, 4));

			randomIndex = Random.Range(0, enemies.Length);
			randomSide = Random.Range(0, 2);
			enemy = Instantiate(enemies[randomIndex]);

			if (randomSide == 0)
			{
				enemy.transform.position = left.position;
				enemy.GetComponent<Enemy>().speed = Random.Range(4, 10);

			}
			else
			{
				enemy.transform.position = right.position;
				enemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
				enemy.transform.localScale = new Vector3(-1, 1, 1);
			}
		}
	}
    // Update is called once per frame
}
