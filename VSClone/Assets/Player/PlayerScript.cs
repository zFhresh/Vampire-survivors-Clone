using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float Horizontal;
    float vertical;
    [SerializeField]float Speed;
    Rigidbody2D rb;
    bool canFire;
    float timer;
    public float timeBetweenFiring;
    public static PlayerScript Instance;
    Animator anim;
    [SerializeField] GameObject Bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(Instance == null) {
            Instance = this;
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (!canFire) {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring) {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetKey(KeyCode.Mouse0) && canFire) {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            canFire = false;
        }
        MoveVector = new Vector2(
            Horizontal,
            vertical
        );
        anim.SetFloat("Horizontal",Horizontal);
        
    }
   


    public Vector2 MoveVector;
    private void LateUpdate() {
        rb.velocity = MoveVector * Speed; 
    }
}
