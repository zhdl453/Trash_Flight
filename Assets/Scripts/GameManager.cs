using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 디자인 패턴: 여러 스크립트에 접근 가능
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;

    void Awake(){
        if (instance==null){
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin +=1;
        text.SetText(coin.ToString()); //문자열로 바꿔줘야함.

        if(coin % 10 ==0){
            Player player = FindObjectOfType<Player>(); //어떤 타입을 찾을지는 꺽새 안에 적음
            if(player !=null){
                player.Upgrade();
            }
        }
    }
}
