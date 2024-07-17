using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bo : MonoBehaviour
{
    public Slider hp;
    private Rigidbody2D rb;
    private int direction;
    public float speed; // toc do di chuyen
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = -1; // ban dau di chuyen tu ben trai
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed * direction, rb.velocity.y, 0);
        hpBo();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("barier")){
         direction *= -1; // doi huong
         rb.gameObject.transform.localScale= new Vector3(rb.gameObject.transform.localScale.x * -1, 1, 1);     
        }
        if(other.gameObject.CompareTag("vienDanNV")){
            hp.value--;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("roixuong")){
            Destroy(gameObject);
        }

    }

    void hpBo(){
        if(hp.value == 0){
            Destroy(gameObject);
        }
    }
}
