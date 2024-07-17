using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bongHoa : MonoBehaviour
{
    public GameObject buttlet; //prefab vien dan
    public Transform bullerPos; //vi tri vien dan
    public float timer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0f) // du dieu kien ban
        {
            animator.SetTrigger("atk");
           
        }
    }
    private void PlanintShoot()
    {
        Instantiate(buttlet, bullerPos.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.CompareTag("quabom")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("roixuong")){
            Destroy(gameObject);
        }

    }
}
