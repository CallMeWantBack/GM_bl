using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class NumCHnage : MonoBehaviour
{
    public GameObject text1, text2;
    public Button button1, button2;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() =>
        {
            text1.transform.DOLocalMoveY(75, 2);
           
        });
        button2.onClick.AddListener(() =>
        {
            text1.transform.DOLocalMoveY(-75, 2);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
