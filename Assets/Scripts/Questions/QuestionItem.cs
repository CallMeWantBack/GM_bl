using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionItem : MonoBehaviour
{
    [Header("正确答案")]
    public List<string> RealAnswerList;
    [Header("所有答案")]
    public List<string> AnswerList;
    [Header("用户选择的答案")]
    public List<string> PlayAnswerList;
    [Header("所有的Toggle选择")]
    public List<Toggle> toggles;
    public TMP_Text TMP_TextInfo; 

    public bool isWronOrTrue;
    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// 判断这道题是否是正确的
    /// </summary>
    /// <returns></returns>
    public bool ISCorect()
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                PlayAnswerList.Add(toggles[i].transform.GetChild(1).GetComponent<TMP_Text>().text);
            }
            else
            {
                if (IsRealAnswer(toggles[i].transform.GetChild(1).GetComponent<TMP_Text>().text))
                {
                    return false;
                }
            }

        }
        return true;
    }
    public void SetInfo()
    {
        TMP_TextInfo.gameObject.SetActive(true);
        string strTemp = "";
        if (ISCorect())
        {
            strTemp += "回答正确";
            TMP_TextInfo.color = Color.green;
            TMP_TextInfo.text = strTemp;

        }
        else
        {
            strTemp += "回答错误,正确答案为：";
            TMP_TextInfo.color = Color.red;
            for (int i = 0; i < RealAnswerList.Count; i++)
            {
                string select =RealAnswerList[i].ToString();
                string[] sArray = select.Split('、');
                strTemp += sArray[0];
            }
            TMP_TextInfo.text = strTemp;
        }
    }
    /// <summary>
    /// 判断是否是正确答案
    /// </summary>
    /// <param name="Msg"></param>
    /// <returns></returns>
    private bool IsRealAnswer(string Msg )
    {
        for (int j = 0; j < RealAnswerList.Count; j++)
        {
            if (Msg == RealAnswerList[j])
            {
                return true;
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
