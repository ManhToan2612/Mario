using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    private new Camera camera;
    private float y;
    private float z;
   
    
    // Start is called before the first frame update
    void Start()
    {
        camera= Camera.main;
        y= transform.position.y;
        z= transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(camera.transform.position.x, y, z);
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Player")){
    //         EndGame();
    //     }
    // }

    // private void EndGame(){
    //     Time.timeScale= 0f; // tam dung tro choi
    //     Debug.Log(gameManager.instance.coin);
    // }
}
