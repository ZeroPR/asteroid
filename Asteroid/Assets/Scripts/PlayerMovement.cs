using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mov_speed = 10;
    public float FireCooldownSeconds = 0.5f; 
    public GameObject BulletSpawner;
    public GameObject bullet;


    Transform trans;

    bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        this.trans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            FireMainWeapon();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement() {
        var velocity = new Vector2(Input.GetAxis("Horizontal") * mov_speed * Time.deltaTime, Input.GetAxis("Vertical") * mov_speed * Time.deltaTime);
        trans.Translate(velocity);
        var x = trans.position.x;
        var y = trans.position.y;
        x = Mathf.Clamp(x, -9, 9);
        y = Mathf.Clamp(y, -4.5f, 4.5f);
        trans.position = new Vector2(x, y);
    }

    void FireMainWeapon() {
        this.canFire = false;
        Instantiate(bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
        StartCoroutine("FireCooldown");
    }

    IEnumerator FireCooldown() {
        yield return new WaitForSeconds(FireCooldownSeconds);
        this.canFire = true;
    }
}
