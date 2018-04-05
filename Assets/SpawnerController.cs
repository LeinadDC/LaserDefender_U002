using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    // Use this for initialization
    public GameObject enemyPrefab;
    public float width, height;
    
	void Start () {

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

     void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
