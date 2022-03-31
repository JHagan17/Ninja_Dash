using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int shurikens;
    static shurikenUI ShurikenUI;
    
    
    #region Singleton
    
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
        
        ShurikenUI = FindObjectOfType<shurikenUI>();
        shurikens = 0;
        ShurikenUI.UpdateShurikens();

    }
    #endregion

    public GameObject player;

    void Update()
    {
        
    }

    public static void AddShurikens(int shurikenValue)
    {
        shurikens += shurikenValue;

        ShurikenUI.UpdateShurikens();
    }


    
}
