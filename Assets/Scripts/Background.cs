using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f; 
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed *Time.deltaTime;
        //Time.deltaTime는 컴퓨터 성능에 상관없이 똑같은 이동위치만큼 바뀔수 있게 설정해주는거임
        if(transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20f,0);
        }
    }
}
