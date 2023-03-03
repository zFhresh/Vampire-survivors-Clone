using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]List<Transform> SpawnPozs = new List<Transform>();
    [SerializeField] GameObject Enemy;
    void Start()
    {
        foreach(Transform t in transform) {
            SpawnPozs.Add(t);
        }
        StartCoroutine(_Spawner());
    }

    // Update is called once per frame
    IEnumerator _Spawner() {
        while(true) {
            yield return new WaitForSeconds(0.7f);
            int nmb = Random.Range(0,SpawnPozs.Count);
            Vector3 spawnpoz = new Vector3(SpawnPozs[nmb].position.x,SpawnPozs[nmb].position.y,0);
            Instantiate(Enemy,spawnpoz,Quaternion.identity);

        }
    }
}
