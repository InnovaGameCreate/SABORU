using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    void Start(){
        pauseUI.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf){
                Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }   
    }

}
