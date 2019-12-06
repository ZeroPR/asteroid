using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidScript : MonoBehaviour
{
    public float max_health = 100;
    public float health = 100;
    public float mov_speed = 5;

    public Canvas canvas;
    public Image healthbar;

    Transform trans;

    [SerializeField] private Material dissolve_material;
    private float dissolveAmount;
    private bool isDissolving;

    private void Awake()
    {
        this.dissolve_material = new Material(dissolve_material);
        this.GetComponent<SpriteRenderer>().material = dissolve_material;
        this.canvas.enabled = false;
    }

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

    private void Update()
    {
        if (this.isDissolving)
        {
            this.dissolveAmount = Mathf.Clamp01(this.dissolveAmount += Time.deltaTime);
            this.dissolve_material.SetFloat("_DissolveAmount", this.dissolveAmount);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            this.isDissolving = true;
        }

        if(this.dissolveAmount == 1)
        {
            this.canvas.enabled = false;
            Destroy(this.gameObject);
        }
        
    }

    public void TakeDamage(float damage)
    {
        this.canvas.enabled = true;
        this.health -= damage;
        this.health = Mathf.Clamp(this.health, 0, this.max_health);
        Debug.Log(this.health / this.max_health);
        this.healthbar.fillAmount = (float)(this.health / this.max_health);
        if(this.health == 0)
        {
            this.isDissolving = true;
        }
    }
}
