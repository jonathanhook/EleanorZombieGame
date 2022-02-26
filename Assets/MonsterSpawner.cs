using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfMonsters;
    public float worldSize;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMonsters()
    {
        for(int i = 0; i < numberOfMonsters; i++)
        {
            float x = Random.Range(0.0f, worldSize);
            float z = Random.Range(0.0f, worldSize);

            Instantiate(prefab, new Vector3(x, 0.0f, z), Quaternion.identity, null);
        }
    }
}
