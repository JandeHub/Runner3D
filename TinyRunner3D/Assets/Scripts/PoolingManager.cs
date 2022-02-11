using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
    public class PooledItems
    {
        public string Name;
        public GameObject objectToPool;
        public int amount;
        
    }
public class PoolingManager : MonoBehaviour
{
    [SerializeField] private Transform fatherFollower;
    private static PoolingManager _instance;
    public static PoolingManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();

    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        for(int i = 0; i < pooledLists.Count; i++)
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>());

            for( int j = 0; j < l.amount; j++)
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool);
                tmp.SetActive(false);
                _items[l.Name].Add(tmp);
                tmp.transform.parent = fatherFollower.transform;
            }
        }
    }
    

    public GameObject GetPooledObject(string name)
    { //Busca un objeto que esté desactivado y lo retorna
        List<GameObject> tmp = _items[name];
        for(int i = 0; i < tmp.Count; i++)
        {
            if(!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }


}
