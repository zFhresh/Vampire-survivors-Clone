using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }
    void Start()
    {
        
    }
    public void SetEnemyWawe(int EnemyCount) {
        Spawner.Instance.StartEnemyWawe(EnemyCount);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
