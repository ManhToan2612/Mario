using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Accessibility;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class code_dichuyen : MonoBehaviour
{
  
  
    private bool NenDat = true;
    public float dichuyen;
    public float tocdo;
    public float docao;
    private Rigidbody2D rb;
    private Animator amt;
    private bool isfacingright = true;
     public GameObject Panel;
     public GameObject Text;
     public GameObject Btn;
     public GameObject player;
     public ParticleSystem particleSystem;
     public TextMeshProUGUI diemText;

   
  
     int tong= 0;
    void tinhTong(int score){
        tong += score;
        diemText.text= "Diem: " + tong;
    }
    
     
     
    void Start()
    {
        
        tocdo = 5f;
        docao = 11f;
        rb = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
        tinhTong(0);
      particleSystem.Stop();
       
    }

    void Update()
    {
        dichuyen = Input.GetAxis("Horizontal");
        

        if (dichuyen != 0)
        {
            amt.SetBool("isRunning", true);
            rb.velocity = new Vector2(dichuyen * tocdo, rb.velocity.y);
        }
        else
        {
            amt.SetBool("isRunning", false);
        }


        if (Input.GetKey(KeyCode.Space) && NenDat)
        {
           amt.SetBool("nhay",true);
            rb.AddForce(Vector2.up * docao, ForceMode2D.Impulse);
            NenDat = false;
            
        }
        else{
            amt.SetBool("nhay",false);
        }
        

        Flip();
    }

    private void Flip()
    {
        if ((isfacingright && dichuyen < 0) || (!isfacingright && dichuyen > 0))
        {
            isfacingright = !isfacingright;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x *= -1;
            transform.localScale = kich_thuoc;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tag1"))
        {
            NenDat = true;
        }
           
  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tag1"))
        {
            NenDat = false;
        }
     
    }

   private void OnTriggerEnter2D(Collider2D collision1)
{
    if (collision1.gameObject.tag == "trai" || collision1.gameObject.tag == "phai")
    {
        
        Time.timeScale = 0;
        Panel.SetActive(true);
        Text.SetActive(true);
        Btn.SetActive(true);
        float playerX = player.transform.position.x;
        SetObjectXPosition(Panel, playerX);
        SetObjectXPosition(Btn, playerX);
        SetObjectXPosition(Text, playerX);
    }
    if (collision1.gameObject.tag == "tren")
    {
        var name = collision1.attachedRigidbody.name;
        // quai++;
        // diem.SetText(quai.ToString());
        Destroy(GameObject.Find(name));
        tinhTong(3);
        // Destroy(collision1.gameObject);
    }
     if(collision1.gameObject.tag == "win"){
        SceneManager.LoadScene("map1");
    }
      if(collision1.gameObject.tag == "win2"){
            SceneManager.LoadScene("map2");
    }

    if(collision1.gameObject.tag== "vang"){
        var name= collision1.attachedRigidbody.name;
        Destroy(GameObject.Find(name));
        tinhTong(1);
    }
    
    if(collision1.CompareTag("gach")){
        var name = collision1.attachedRigidbody.name;
        Destroy(GameObject.Find(name));
        Instantiate(particleSystem,
        collision1.gameObject.transform.position,
        collision1.gameObject.transform.localRotation);
    }
   
    if(collision1.gameObject.tag== "roixuong"){

        Time.timeScale = 0;

        Panel.SetActive(true);
        Text.SetActive(true);
        Btn.SetActive(true);
        
        float playerX = player.transform.position.x;
        SetObjectXPosition(Panel, playerX);
        SetObjectXPosition(Btn, playerX);
        SetObjectXPosition(Text, playerX);
    }
}
void SetObjectXPosition(GameObject obj, float xPosition)
{
    if (obj != null)
    {
        Vector3 newPosition = obj.transform.position;
        newPosition.x = xPosition;
        obj.transform.position = newPosition;
    }
    else
    {
        Debug.LogError("GameObject không được gán hoặc là null.");
    }
}

   
}