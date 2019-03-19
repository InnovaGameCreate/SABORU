using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject gameStartView;
    [SerializeField]
    private string nextSceneName;
    private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton = gameStartView.GetComponent<Button>();

        // スタートボタンを押した時のイベント処理を登録
        startButton.onClick.AddListener(()=> {
            // SceneManager.LoadScene(nextSceneName);
            GameManager.Instance.NowState = GameState.Progress.Main;
        });

        // ゲームシーンが変更された事を登録
        GameManager.Instance.OnChangeGameState += () => {
        
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
