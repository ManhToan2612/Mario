using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viendan1 : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(15f, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "nendat"){
            Destroy(gameObject);
        }
    }
}
