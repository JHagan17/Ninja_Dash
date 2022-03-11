using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shurikenUI : MonoBehaviour
{
    public TextMeshProUGUI shurikenText;

    
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShurikens()
    {
        shurikenText.text = PlayerManager.shurikens.ToString();
    }
}
