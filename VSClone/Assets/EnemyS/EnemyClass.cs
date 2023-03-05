using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class EnemyClass : MonoBehaviour
{
    
    [SerializeField] protected float Speed;
    [SerializeField] protected int Heal = 100;
    [HideInInspector]public bool canMove = true;
    [SerializeField] GameObject Blood;
    [SerializeField] float AtackCoulDown;
    [SerializeField] TextMeshPro AttackTextTMP;
    
    void Start()
    {

    }
    public abstract void Damage();
    public void GetDamage(int Damage) {
        Heal -= Damage;
        AttackTextTMP.gameObject.SetActive(true);
        AttackTextTMP.text = Damage.ToString();
        if(Heal <= 0) {
            IsDead();
        }
        Invoke("HideDamageText",.7f);
    }
    public void HideDamageText() {
        Debug.Log("Çalıştı");
        AttackTextTMP.gameObject.SetActive(false);
    }
    public void IsDead() {
        Instantiate(Blood,transform.position,Quaternion.identity);
        Spawner.Instance.EnemyDead();
        Destroy(this.gameObject);
    }
    public void CanMove() {
        canMove = true;
    }
    // Update is called once per frame
    float timer = 0;
    void Update()
    {
        if(!canMove) {GetComponent<Rigidbody2D>().velocity = Vector2.zero;  return;}
        GetComponent<Rigidbody2D>().velocity =  (PlayerScript.Instance.gameObject.transform.position - transform.position ).normalized * Speed;
        timer += Time.deltaTime;
        if(timer > AtackCoulDown) {
            timer = 0;
            Debug.Log("SALDIRRRRRRRRRR!!!!!!!!!!!!!!!!!");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            timer = AtackCoulDown + 1;
            Debug.Log(timer + " " + AtackCoulDown);
            canMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            canMove = true;
        }
    }
}
