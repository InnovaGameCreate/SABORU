﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Type t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if(instance == null)
                {
                    Debug.LogError(t + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    virtual protected void Awake()
    {
        //他のゲームオブジェクトにアタッチされているかを調べる
        //アタッチされていたら破棄
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if(instance == null)
        {
            instance = this as T;
            return true;
        } else if (Instance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }
}

