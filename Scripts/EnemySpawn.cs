using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;
	

	public void SpawnEnemy()
	{	
        enemy.transform.position = spawnPoint.position;
	}
    // Start is called before the first frame update
    void Start()
    {
		
		SpawnEnemy();
		
    }

	// Update is called once per frame
	void Update()
	{
		
	}
}
