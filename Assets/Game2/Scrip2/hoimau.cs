using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoimau : MonoBehaviour
{
    public GameObject nhanvat;
    public bool start = true;
    public GameObject tao;

    void Start()
    {
        if (nhanvat == null)
        {
            Debug.LogError("Player object is not assigned in bomroi script!");
            return;
        }
        StartCoroutine(SpawnBoomRandomly());
    }

    IEnumerator SpawnBoomRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f); // Chờ một khoảng thời gian ngẫu nhiên trước khi tạo quả táo mới
            Vector3 randomPosition = GenerateRandomPosition();
            Instantiate(tao, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = nhanvat.transform.position.x + 15f; // Random vị trí x trong một phạm vi nhất định xung quanh vị trí của người chơi
        float randomY = nhanvat.transform.position.y + 0f; // Vị trí y sẽ được chọn trên trục y
        return new Vector3(randomX, randomY, 0f);
    }
   
}
