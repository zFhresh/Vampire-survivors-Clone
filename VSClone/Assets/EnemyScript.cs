using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float Speed;
    bool canMove = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove) {GetComponent<Rigidbody2D>().velocity = Vector2.zero;  return;}
        GetComponent<Rigidbody2D>().velocity =  (PlayerScript.Instance.gameObject.transform.position - transform.position ).normalized * Speed;
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("Çarptı");
            canMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            Debug.Log("Çarptım bitti");
            canMove = true;
        }
    }
}
