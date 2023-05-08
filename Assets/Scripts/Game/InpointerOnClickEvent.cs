using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Example;
using UnityEngine.UI;
using DG.Tweening;
using PicklePro;

public class InpointerOnClickEvent : MonoBehaviour,ISingleton
{
    public static InpointerOnClickEvent Instance
    {
        get { return MonoSingletonProperty<InpointerOnClickEvent>.Instance; }
    }
    public void ShowScaleDo(Button button,List<Button> buttons,float startpos,Vector2 startvector2,Vector2 endvector2,float endpos)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<RectTransform>().DOAnchorPosX(startpos, 0.1f, true);
            buttons[i].GetComponent<RectTransform>().DOSizeDelta(startvector2, 0.1f, true);
            buttons[i].GetComponent<ToggleEffect>().isOn = false;
        }
        button.GetComponent<RectTransform>().DOAnchorPosX(endpos, 0.2f, true);
        button.GetComponent<RectTransform>().DOSizeDelta(endvector2, 0.2f, true);
        button.GetComponent<ToggleEffect>().isOn = true;
    }
    public void BackToggleScale(List<Button> buttons,float startpos)
    {
        for (int i = 0; i < buttons.Count; i++)
        {

            if (buttons[i].GetComponent<ToggleEffect>().isOn == true)
            {
                Debug.Log(buttons[i].name);
                buttons[i].GetComponent<RectTransform>().DOAnchorPosX(startpos, 0, true);
            }
        }


    }

    public void OnSingletonInit()
    {
       
    }
}
