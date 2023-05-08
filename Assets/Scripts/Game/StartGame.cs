using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Example;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResKit.InitAsync().ToAction().Start(monoBehaviour: this, onFinish: _ =>
        {
            UIKit.OpenPanelAsync<LoadPanel>().ToAction().Start(this);
            ModleCtroller.Instance.CameraVitureInit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
