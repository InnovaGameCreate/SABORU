using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // シーンごとにロードするシーンを変える
    public void IntoMainManu(){
        if(SceneManager.GetActiveScene().name == "GameOver")
            SceneManager.LoadScene("Title");
}

}
