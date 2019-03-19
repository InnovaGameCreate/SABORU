using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //playerのダメージ
    public float playerDamagePoint = 0;
    //スライダーコンポーネント格納変数
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDamagePoint+=1;
        if(playerDamagePoint > slider.maxValue){
            playerDamagePoint = slider.minValue;
        }

        slider.value = playerDamagePoint;
        
    }
}
