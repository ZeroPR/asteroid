using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float health = 100;
    public float mov_speed = 5;

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
}
