using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 1 이거 추가    
public class HpBar : MonoBehaviour
{
     // 2 변수 선언
    public Player player; 
    public Slider bar;

    void Update()
    {
        // 3 함수 작성
        float maxHp = player.maxHp;
        float currentHp = player.hp;

        float hpPercentage = currentHp / maxHp;
        bar.value = hpPercentage;
    }
}
