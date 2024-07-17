using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

//Ve coin theo hinh sin
// Moi 5s thi ve mot lan
// Xoa coin bi bo qua
public class coin : MonoBehaviour
{
    public GameObject player; // anh xa toi nhan vat
    public GameObject _coin; // anh xa voin
    public float nextPosX;
    public float nextPosY; // vi tri sinh ra coin
    private float khoangCach; // khoang cach coin cach ra voi nguoi choi
    public float doCong; // do cong hinh sin
     public float chieucaocuasin;
     public float doRongsin;
    public float chieucao; // chieu cao so voi mat dat cua coin
    public float chieucaotoithieu;
    public float thoiGian; // Bao lau ve coin 1 lan
    public float soLuongCoin; // So luong voin moi lan  ve ra
    public float timer; // theo doi thoi gian
    private Vector3 nextPos;


    // Start is called before the first frame update
    void Start()
    {
        khoangCach = 8f;
        chieucaotoithieu = 4f;
        thoiGian = 5f;
        soLuongCoin = 12;
        timer= 0;
        veCoin2();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > thoiGian){
            veCoin2();
            timer= 0;
        }
    }

    private void veCoin()
    {
        chieucao = Random.Range(-7f, -5f) + chieucaotoithieu;
        // doCong = Random.Range(0.8f, 1.2f);
        doRongsin = 10f;
        chieucaocuasin= 5f;
        
        nextPosX = player.transform.position.x + khoangCach;
        for (int i = 0; i < soLuongCoin; i++)
        {
            nextPosY = Mathf.Abs(chieucaocuasin * Mathf.Sin(nextPosX/ doRongsin)) + chieucaotoithieu;
            Instantiate(_coin, new Vector3(nextPosX, nextPosY, -5f), Quaternion.identity, transform);
            nextPosX++;
        }
    }
    private void veCoin2(){
        float a;
        a= Random.Range(0.01f, 0.10f);//do cong
         float b;
        b= Random.Range(-2f, 0f);// do lech chieu cao
        // vi tri dau tien ve coin la vi tri nguoi choi. cong them khoang cach ve vao X, va chieu cao vao y
        nextPos= player.transform.position + new Vector3(khoangCach, 0, 0);
        int soCoin2=(int)(soLuongCoin/2);
        for(int i = -1* soCoin2; i <= soCoin2; i++) {
            // y= -a * x * x. Trong do a quyet dinh do cong
            Vector3 toaDoVe= nextPos + new Vector3(i+ soCoin2, -1* a*  i* i+ a* soCoin2* soCoin2+ b, -5f);   
            Instantiate(_coin, toaDoVe, Quaternion.identity, transform); 
        }
    }
}
