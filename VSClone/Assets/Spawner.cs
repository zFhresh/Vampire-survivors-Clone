using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]List<Transform> SpawnPozs = new List<Transform>();
    [SerializeField] GameObject Enemy;
    // !!! Bu kısmı ileride DataManager e taşı
    int KillCount = 0;
    [SerializeField] int EnemyCount;
    Coroutine Corotine;
    public List<GameObject> Enemys = new List<GameObject>();
    public static Spawner Instance;
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
        foreach(Transform t in transform) {
            SpawnPozs.Add(t);
        }
    }
    public void StartEnemyWawe(int _EnemyCount) {
        EnemyCount = _EnemyCount;
        Corotine =  StartCoroutine(_Spawner());
    }
    public void EnemyDead() {
         KillCount++;
         if(KillCount >= 60) {
            StopCoroutine(Corotine);
         }
         if(Enemys.Count > 0) { Enemys.RemoveAt(Enemys.Count - 1); }
    }
    IEnumerator _Spawner() {
        while(true) {
            yield return new WaitForSeconds(0.1f);
            if(Enemys.Count >= EnemyCount) {
                StopCoroutine(Corotine);
                Debug.Log("Wawe bitti");
            }
            int nmb = Random.Range(0,SpawnPozs.Count);
            Vector3 spawnpoz = new Vector3(SpawnPozs[nmb].position.x,SpawnPozs[nmb].position.y,0);
            GameObject g = Instantiate(Enemy,spawnpoz,Quaternion.identity);
            Enemys.Add(g);

        }
    }
}
