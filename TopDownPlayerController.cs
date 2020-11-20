using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprRend;
    public float speed, slowSpeed, fastSpeed, bulletSpeed, x, y, shootCoolDown, shootTimer;

    public GameObject bulletPrefab;
    public Transform endOfGun;

    public int kazooChanger;


    public Vector2 dir, faceDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //for changing spr if you wanna
        sprRend = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {

        speed = fastSpeed;
        //GET INPUT
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        dir = new Vector2(x,y);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        faceDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = -faceDir; 

        


        //Shooting
        if(Input.GetMouseButton(0)){

            speed = slowSpeed;

            
            if(shootTimer <= 0){
                Shoot();
                
                shootTimer = shootCoolDown;
            }
        }
        
        shootTimer -= Time.deltaTime;


        
            
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir.normalized * speed * Time.fixedDeltaTime);
    }

    void Shoot(){

        
        Vector3 t = new Vector3(endOfGun.position.x, endOfGun.position.y, endOfGun.position.z);
        var projectile = Instantiate(bulletPrefab, t, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletSpeed);
    }







}