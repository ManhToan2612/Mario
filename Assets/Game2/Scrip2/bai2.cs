using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bai2 : MonoBehaviour
{
    private void OnGUI() {
        GUI.Box(new Rect(10, 10, 200, 80),"Main Menu");
        GUI.Label(new Rect(100, 100, 1000, 100), "You win");
        
        if(GUI.Button(new Rect(40, 20, 80, 30),"Play Game")){
            SceneManager.LoadScene(1);
        }
    }
    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
