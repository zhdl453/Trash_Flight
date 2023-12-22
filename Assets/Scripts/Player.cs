using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;
    // Update is called once per frame
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    void Update()
    {
        // //키보드 상하좌우를 누르면 값이 저 변수로 담아짐.
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // else if(Input.GetKey(KeyCode.RightArrow))
        // {
        //      transform.position += moveTo;
        // }

        //Debug.Log(Input.mousePosition); //마우스 위치 좌표를 콘솔로 찍어줌.

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Input.mousePosition); //마우스 위치 좌표를 콘솔로 찍어줌.
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); //최소값 -.2.35f를 넘어가면 최소값, 최대값도 넘어가면 최대값이 한계가 되겠끔 설정해줌
        transform.position = new Vector3(toX,transform.position.y, transform.position.z);

        Shoot();
    }   
    void Shoot(){
        if(Time.time - lastShotTime > shootInterval){ //게임이 시작된 이후로 현재까지 흐른시간
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
            Debug.Log("Game Over");
            Destroy(gameObject);
        } else if(other.gameObject.tag == "Coin"){
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade(){
        weaponIndex +=1;
        if(weaponIndex >= weapons.Length){
            weaponIndex = weapons.Length -1;
        }
    }
}
