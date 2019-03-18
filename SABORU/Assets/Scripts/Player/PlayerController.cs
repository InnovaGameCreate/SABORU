using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum PlayerState
    {
        Sitting, Standing, Tiping, Resting
    }


public class PlayerController : MonoBehaviour
{
    public PlayerMove playerMove;
    public PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.Sitting;
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //状態がsittingのときの状態遷移
        if (playerState == PlayerState.Sitting)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Standing);
                    Debug.Log("Standing");
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    StateChanged(PlayerState.Tiping);
                    Debug.Log("Tiping");
                }
            }
        //状態がstandingのときの状態遷移
        else if (playerState == PlayerState.Standing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StateChanged(PlayerState.Sitting);
                Debug.Log("Sitting");
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                StateChanged(PlayerState.Resting);
                Debug.Log("Resting");
            }
        }
        
    }
    //状態が変化するときの処理を行う
    void StateChanged(PlayerState p)
    {
        switch (p)
        {
            case PlayerState.Sitting:
                playerState = PlayerState.Sitting;
                playerMove.enabled = false;
                break;
            case PlayerState.Standing:
                playerState = PlayerState.Standing;
                playerMove.enabled = true;
                break;
            case PlayerState.Tiping:
                playerState = PlayerState.Tiping;
                /* Tipingスクリプト呼び出し */
                break;
            case PlayerState.Resting:
                playerState = PlayerState.Resting;
                /* Restingスクリプト呼び出し */
                break;
        }
    }

}
