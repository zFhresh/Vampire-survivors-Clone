using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    [SerializeField] Sprite[] Bloods;
    void Start()
    {
        int a = Random.Range(0,Bloods.Length);
        this.GetComponent<SpriteRenderer>().sprite = Bloods[a];
    }

}
