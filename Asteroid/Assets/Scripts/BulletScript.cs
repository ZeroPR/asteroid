using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour { 

    public float mov_speed = 35;
    public int damage = 50;
    Transform trans;

    void Start()
    {
        this.trans = this.GetComponent<Transform>();
        StartCoroutine("SelfDestroy");
    }

    private void FixedUpdate()
    {
        trans.Translate(new Vector2(0, mov_speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<AsteroidScript>().TakeDamage(damage);
            Destroy(this.gameObject);

        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
