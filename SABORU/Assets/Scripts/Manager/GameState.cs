﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    // 現在のゲーム進行状態
    public enum Progress {
        
        None = -1,
        Title,
        Main,
        GameOver,
        GameClear,
        // TODO 分岐するならこれより下にも追加する
        
    }

}
