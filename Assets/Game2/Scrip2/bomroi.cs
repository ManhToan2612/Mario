using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomroi : MonoBehaviour
{
    public GameObject boom;
    public GameObject player;
    public bool start = true;
    public GameObject vuNo;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
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
            yield return new WaitForSeconds(5f); // Chờ một khoảng thời gian ngẫu nhiên trước khi tạo bom mới
            Vector3 randomPosition = GenerateRandomPosition();
            Instantiate(boom, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(player.transform.position.x - 5f, player.transform.position.x + 5f); // Random vị trí x trong một phạm vi nhất định xung quanh vị trí của người chơi
        float randomY = player.transform.position.y + 10f; // Vị trí y sẽ được chọn trên trục y
        return new Vector3(randomX, randomY, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("nendat"))
        {
            GameObject vuno = Instantiate(vuNo, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(vuno, 1f);
        }
         if(other.gameObject.CompareTag("roixuong")){
            Destroy(gameObject);
        }

    }
}

