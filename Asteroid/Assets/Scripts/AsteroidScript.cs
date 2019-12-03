using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidScript : MonoBehaviour
{
    public float max_health = 100;
    public float health = 100;
    public float mov_speed = 5;

    public Image healthbar;

    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        this.trans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trans.Translate(Vector2.down * mov_speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        this.health = Mathf.Clamp(this.health, 0, this.max_health);
        Debug.Log(this.health / this.max_health);
        this.healthbar.fillAmount = (float)(this.health / this.max_health);
    }
}
