using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vacham : MonoBehaviour
{
    public float left, right;
public bool isright;
private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
       var NamX = transform.position.x;
if (NamX < left)
{
    isright = true;
}
if (NamX > right)
{
    isright = false;
}
if (isright) {
    transform.Translate(new Vector3(Time.deltaTime * speed , 0,0));
}
else
{
    transform.Translate(new Vector3(- Time.deltaTime*speed , 0,0));
}
    }
}
