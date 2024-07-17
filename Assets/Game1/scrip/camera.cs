using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Diem;
    public GameObject player;
    public float start, end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        var playerX= player.transform.position.x;
        var CmrX= transform.position.x;
        var CmrY= transform.position.y;
        var CmrZ= transform.position.z;
        

        

        if(playerX > start && playerX < end){
            CmrX= playerX;
        }

        if(playerX < start){
            CmrX = start;
        }
        if(playerX > end){
            CmrX= end;
        }
        
        

        transform.position= new Vector3(CmrX, CmrY, CmrZ);
    }

    
}
