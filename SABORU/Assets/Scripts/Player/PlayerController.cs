using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum PlayerState
    {
        Sitting, Standing
    }


public class PlayerController : MonoBehaviour
{
    public PlayerMove playerMove;
    public PlayerState playerState;
    public GameObject Task;
    //稼いだお金
    public int getMoney = 0;
    //所持金を表示するテキスト用変数
    public Text getMoneys;
    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.Sitting;
        playerMove = GetComponent<PlayerMove>();
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
        }
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
                break;
            case PlayerState.Standing:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StateChanged(PlayerState.Sitting);
                    Debug.Log("Sitting");
                }
                break;
        }

        getMoneys.text = "所持金：" + getMoney.ToString() + "円";
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Chair" && playerState == PlayerState.Sitting)
        {
            Debug.Log("あたり");
            Task.SetActive(true);
            getMoney = getMoney + 10;
            }
    }

    void OnTriggerExit(Collider other)
    {
        Task.SetActive(false);

    }


}
