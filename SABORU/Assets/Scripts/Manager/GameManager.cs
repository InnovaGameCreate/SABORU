using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update

    [SerializeField]
    private GameState.Progress nowState = GameState.Progress.Title;
    private GameState.Progress prevState = GameState.Progress.None;

    public event Func<GameState.Progress> OnChangeGameState;

    /// <summary>
    /// 現状の進行状態
    /// </summary>
    /// <value></value>
    public GameState.Progress NowState {
        get => nowState;
        
        set { 
            prevState = nowState;
            nowState = value;

            // 状態が変化したことを通知する
            OnChangeGameState(); 
        }
    }

    /// <summary>
    /// 一つ前の進行状態
    /// </summary>
    /// <value></value>
    public GameState.Progress PrevState { get => prevState; }
    

    


   
}
