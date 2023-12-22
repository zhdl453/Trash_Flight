using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;
    // Start is called before the first frame update
    void Start() //Start()는 게임 객체를 비활성화 했다가 다시 활성화하는 경우에도 호출됨. 한번호출되는거.
    {
        Destroy(gameObject, 1f); //1f초 뒤에 없애주게 걸어주는거임.
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        //Time.deltaTime는 컴퓨터 성능에 상관없이 똑같은 이동위치만큼 바뀔수 있게 설정해주는거임
        
    }
}
