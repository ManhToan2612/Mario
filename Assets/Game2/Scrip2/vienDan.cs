using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vienDan : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // tu gan doi tuong
        Destroy(gameObject, 1.5f); //khoang thoi gian tu bien mat sau khi duoc tao ra, gameObject chinh la doi tuong hien tai
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {     
            Destroy(gameObject);
        }else if(other.gameObject.CompareTag("nendat")){
            Destroy(gameObject);
        }
    }
}
