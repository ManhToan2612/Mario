using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
    public List<GameObject> listGround; //Mảng các block bản đồ
    public Transform player;
    public GameObject bo;
    public GameObject hoa;
    public float rangeToDestroyObject = 60f; //Khoảng cách để tạo sẵn map và hủy

    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra


    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo



    int groundLen;
    int groundTall;


    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(-16f, -1f, 0.0f);

        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    void generateBlockMap()
    {
        for (int i = 0; i < 10; i++)
        {
            float khoangCach = Random.Range(8f, 8f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, -1f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 2; groundTall = 0; break;
                case 1: groundLen = 3; groundTall = 1; break;
                case 2: groundLen = 4; groundTall = 0; break;
                case 3: groundLen = 5; groundTall = 1; break;
                case 4: groundLen = 6; groundTall = 1; break;
            }
            float sacxuat = Random.Range(0, 1f);
            if (sacxuat < 0.2f)
            {
                Instantiate(hoa, new Vector3(nextPos.x + 1, nextPos.y + groundTall, 0), Quaternion.identity, transform);
            }
            else if (sacxuat > 0.8f)
            {
                Instantiate(bo, new Vector3(nextPos.x + 1, nextPos.y + groundTall, 0), Quaternion.identity, transform);
            }
            endPos = new Vector3(nextPos.x + groundLen, groundTall, 0);
        }
    }
}
