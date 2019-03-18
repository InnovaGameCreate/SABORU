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
        switch (playerState)
        {
            case PlayerState.Sitting:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Standing);
                    Debug.Log("Standing");
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StateChanged(PlayerState.Tiping);
                    Debug.Log("Tiping");
                }
                break;
            case PlayerState.Standing:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Sitting);
                    Debug.Log("Sitting");
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StateChanged(PlayerState.Resting);
                    Debug.Log("Resting");
                }
                break;
            case PlayerState.Tiping:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Sitting);
                    Debug.Log("Sitting");
                }
                break;
            case PlayerState.Resting:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Standing);
                    Debug.Log("Standing");
                }
                break;
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
                playerMove.enabled = false;
                /* Restingスクリプト呼び出し */
                break;
        }
    }

}
