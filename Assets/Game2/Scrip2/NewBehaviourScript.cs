using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }

    public void chuyenmanhinh()
    {
        SceneManager.LoadScene("man2");
    }
    public void chuyenbai3()
    {
        SceneManager.LoadScene("bai4");
        Time.timeScale= 1;
    }
    public void choilai()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void hoanthanh()
    {
        SceneManager.LoadScene("home");
    }
    public void quitGame()
    {
        #if UNITY_EDITOR
        // Nếu đang chạy trong Editor, sử dụng EditorApplication.isPlaying= false;
        UnityEditor.EditorApplication.isPlaying = false;
        #else 
        // Nếu đang chạy trong build, sử dụng AppLIcation.Quit() để thoat game
        Application.Quit();
        #endif

    }

    public void home()
    {
        SceneManager.LoadScene("bai2");
    }
    public void Contenue(){
        panel.SetActive(false);
        Time.timeScale= 1;
    }
}
