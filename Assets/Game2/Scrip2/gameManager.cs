using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class pm2 : MonoBehaviour
{
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;
    public Slider hpNV;
    public Slider hoimau;
    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed;
    //Tốc độ nhảy
    public float jumpSpeed;
    public bool nhay;
    public Animator animator;
    public Transform playerY;
    public GameObject Panel, panelesc;
    public GameObject Text, textEsc;
    public GameObject Btn, HomeEsc, Btnesc;
    public GameObject choiTiep;
    public GameObject player;
    public GameObject Home;
    public TextMeshProUGUI diemText;
    public TextMeshProUGUI Score;
    public GameObject viendan;
    public Transform vitriVienDan;
    public int highScore; // luu so diem trong qua trinh choi
    public int currenScore;
    // Điểm rơi của nhân vật
    public Transform respawnPoint;
    public bool isDead;
    public Transform raycast;
    public LayerMask layerMask;
    public GameObject bomroi;



    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        moveSpeed = 5f;
        jumpSpeed = 7.5f;
        animator = GetComponent<Animator>();
        currenScore = 5;
        // DropBom();
        // lay diem high score
        highScore = PlayerPrefs.GetInt("HighScore");
        Score.text = "Diem cao nhat: " + highScore.ToString("n0");
    }

    void Update()
    {
        hpNVV();
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            huyquai();
        }
           if (Input.GetKeyDown(KeyCode.T))
        {
            DropBom();
        }
        //Nếu phím 
        if (Input.GetKeyDown(KeyCode.Space) && nhay) playerJump(jumpSpeed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelesc.SetActive(true);
            textEsc.SetActive(true);
            HomeEsc.SetActive(true);
            Btnesc.SetActive(true);
            Time.timeScale = 0;
        }
        Raycast();

        if (Input.GetKeyDown(KeyCode.S) && currenScore > 0)
        {
            Playershoot();
        }
    }

    private void FixedUpdate()
    {
        playerRun(moveSpeed);
    }

    void playerJump(float jumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "nendat")
        {
            nhay = true;
            animator.SetBool("nhya", false);
        }
        if (other.gameObject.tag == "vang")
        {
            currenScore++;
            diemText.text = " " + currenScore.ToString("n0");

        }
        else if (other.gameObject.tag == "roixuong")
        {
            
            hpNV.value = 0;
            Time.timeScale = 0f;
            Home.SetActive(true);
            Panel.SetActive(true);
            Text.SetActive(true);
            if (currenScore > highScore)
            {
                highScore = currenScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            Score.color = Color.red;
        }
        if (other.gameObject.CompareTag("quai"))
        {
            hpNV.value--;
        }

        if (other.gameObject.CompareTag("quabom"))
        {
             hpNV.value = 0;
            Time.timeScale = 0f;
            Home.SetActive(true);
            Panel.SetActive(true);
            Text.SetActive(true);
            if (currenScore > highScore)
            {
                highScore = currenScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            Score.color = Color.red;
        }
        if(other.gameObject.CompareTag("hoimau")){
            hpNV.value++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "nendat")
        {
            nhay = false;
            animator.SetBool("nhya", true);
        }
    }
    public void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycast.position, Vector2.right, 10f, layerMask);
        if (hit)
        {
            Debug.DrawRay(raycast.position, Vector2.right * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(raycast.position, Vector2.right * 10f, Color.blue);
        }
    }

    public void Playershoot()
    {
        Instantiate(viendan, vitriVienDan.position, Quaternion.identity);
        currenScore--;
    }
    void hpNVV()
    {
        if (hpNV.value == 0)
        {
            Time.timeScale = 0f;
            Panel.SetActive(true);
            Home.SetActive(true);
            Text.SetActive(true);
            Btn.SetActive(true);
            if (currenScore > highScore)
            {
                highScore = currenScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            Score.color = Color.red;
        }
        else if (hpNV.value == 5)
        {
            Time.timeScale = 1f;
        }
    }
    void huyquai(){
         if (GameObject.FindWithTag("quai") != null)
    {
        Destroy(GameObject.FindWithTag("quai")); // Hủy quái
    }
    }
    void DropBom()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 bomroingaunhien = new Vector3(Random.Range(-31f, 5f), 11f, 0f);
            Instantiate(bomroi, bomroingaunhien, Quaternion.identity);
        }
    }

}
