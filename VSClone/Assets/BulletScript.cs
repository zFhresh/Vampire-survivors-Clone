using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera MainCam;
    private Rigidbody2D rb;
    public float Force;
    public int Damage;
    void Start()
    {
        MainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x , direction.y).normalized * Force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);
        Invoke("DestroyYourSelf",4);
    }
    private void DestroyYourSelf() {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("ForPlayer")) {return;} 
        if(other.CompareTag("Player")) {return;}
        if(other.GetComponent<EnemyScript>() != null) {
            other.GetComponent<EnemyScript>().GetDamage(Damage);
        }
        Destroy(this.gameObject);
    }
}
