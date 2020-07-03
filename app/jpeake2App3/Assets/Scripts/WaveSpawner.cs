using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab1;
	public Transform enemyPrefab2;
	public Transform enemyPrefab3;
	public Transform enemyPrefab4;
	public Transform enemyPrefab5;

	public Transform spawnPoint;

	public IEnumerator SpawnWave (float waveIndex)
	{
		if (waveIndex < 5)
		{
			for (int i = 0; i < waveIndex; i++)
			{
				SpawnEnemy(enemyPrefab1);
				yield return new WaitForSeconds(0.5f);
			}
		}
		// level 2
		else if (waveIndex < 10)
		{
			for (int i = 0; i < waveIndex; i++)
			{
				if (i % 3 == 0)
				{
					SpawnEnemy(enemyPrefab2);
					yield return new WaitForSeconds(0.5f);
				}

				SpawnEnemy(enemyPrefab1);
				yield return new WaitForSeconds(0.5f);
			}
		}
		// level 3
		else if (waveIndex < 15)
		{
			for (int i = 0; i < waveIndex; i++)
			{
				if (i % 4 == 0)
				{
					SpawnEnemy(enemyPrefab3);
					yield return new WaitForSeconds(0.5f);
				}

				SpawnEnemy(enemyPrefab2);
				yield return new WaitForSeconds(0.5f);
			}
		}
		// level 4
		else if (waveIndex < 20)
		{
			for (int i = 0; i < waveIndex; i++)
			{
				if (i % 5 == 0)
				{
					SpawnEnemy(enemyPrefab4);
					yield return new WaitForSeconds(0.5f);
				}

				SpawnEnemy(enemyPrefab3);
				yield return new WaitForSeconds(0.5f);
			}
		}
		// level 5
		else
		{
			for (int i = 0; i < waveIndex; i++)
			{
				if (i % 4 == 0)
				{
					SpawnEnemy(enemyPrefab4);
					yield return new WaitForSeconds(0.5f);
				}

				if (i % 5 == 0)
				{
					SpawnEnemy(enemyPrefab4);
					yield return new WaitForSeconds(0.5f);
				}

				SpawnEnemy(enemyPrefab5);
				yield return new WaitForSeconds(0.5f);
			}
		}
	}

	void SpawnEnemy (Transform transform)
	{
		Instantiate(transform, spawnPoint.position, spawnPoint.rotation);
	}

}
