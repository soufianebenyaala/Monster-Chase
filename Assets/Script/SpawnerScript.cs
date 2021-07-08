using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterRefrence;

    private GameObject monsterSpawner;

    [SerializeField]
    private Transform LeftPos,RightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        
    }
    IEnumerator SpawnMonsters()
	{
		while (true)
		{
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefrence.Length);
            randomSide = Random.Range(0, 2);

            monsterSpawner = Instantiate(monsterRefrence[randomIndex]);

            if (randomSide == 0)
            {

                monsterSpawner.transform.position = LeftPos.position;
                monsterSpawner.GetComponent<Monster>().speed = Random.Range(4, 10);

            }
            else
            {
                monsterSpawner.transform.position = RightPos.position;
                monsterSpawner.GetComponent<Monster>().speed = -Random.Range(4, 10);
                Debug.Log("rgsg : " + monsterSpawner.GetComponent<Monster>().speed);
                monsterSpawner.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

        }

	}
    // Update is called once per frame
    void Update()
    {
        
    }


}
