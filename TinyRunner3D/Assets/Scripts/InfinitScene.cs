using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitScene : MonoBehaviour
{
    [SerializeField] private GameObject[] scenePrefabs;
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float prefabLength;
    [SerializeField] private int numberTiles;
    [SerializeField] private Transform playerTransform;

    private float xPosLeft = -0.5f;
    private float xPosRight = 0.5f;

    private List<GameObject> activePrefabs = new List<GameObject>();
    
    void Start()
    {
        for(int i = 0; i < numberTiles; i++)
        {
            if(i == 0)
            {
                SpawnPrefab(0);
            }
            else
            {
                SpawnPrefab(Random.Range(0, scenePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform.position.z - 150 > zSpawn - (numberTiles * prefabLength))
        {
            SpawnPrefab(Random.Range(0, scenePrefabs.Length));
            DeletePrefab();
        }
    }

    public void SpawnPrefab(int prefabIndex)
    {
        GameObject go = Instantiate(scenePrefabs[prefabIndex], new Vector3(xPosLeft, 0, zSpawn), transform.rotation);
        GameObject go2 = Instantiate(scenePrefabs[prefabIndex], new Vector3(xPosRight, 0, zSpawn), new Quaternion(0, 180, 0, 0));
        activePrefabs.Add(go);
        activePrefabs.Add(go2);
        zSpawn += prefabLength;
    }

    private void DeletePrefab()
    {
        Destroy(activePrefabs[0]);
        activePrefabs.RemoveAt(0);
    }
}
