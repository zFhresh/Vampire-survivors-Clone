using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    [SerializeField] float timeBetweenDestroy;
    int TotalKill = 0;
    [SerializeField] int limit;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,180*Time.deltaTime);
        CenterCollider();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {return;}
        Destroy(other.gameObject);
        TotalKill++;
        if(TotalKill >= limit) {
            //? Sınırı aşarsan kendini imha et
            Invoke("DestroyYourSelf",1);
        }
    }
     public void DestroyYourSelf() {
        Destroy(this.gameObject);
    }
    public void CenterCollider() {
        Collider2D[] hits =  Physics2D.OverlapCircleAll(transform.position,0.7f);
        if(hits == null) {
            return;
        }
        else {
            PullHits(hits);
        }
    }
    public void PullHits(Collider2D[] hits) {
        foreach (Collider2D hit in hits) {
            if(hit.GetComponent<Rigidbody2D>() == null || hit.gameObject == this.gameObject || hit.gameObject.CompareTag("Player")) {
                continue;
            }
           // if(hit.GetComponent<EnemyScript>() != null) {hit.GetComponent<EnemyScript>().canMove = false; }

            hit.GetComponent<Rigidbody2D>().velocity =  transform.position - hit.gameObject.transform.position;
            if(hit.transform.localScale.x <= 0.2f) {return;}
            hit.transform.localScale -= new Vector3(0.01f,0.01f,0);
        }
    }
}
