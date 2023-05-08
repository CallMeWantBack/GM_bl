using System.Collections;
using QFramework.Example;
using QFramework;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System.Text;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;
using Doozy;
using Doozy.Engine.UI;

namespace QFramework.Example
{
    public class KnowledgeAssetPanelData : UIPanelData
    {
    }
    public partial class KnowledgeAssetPanel : UIPanel
    {
        [Header("所有的问题")]
        public List<GameObject> Questions;
        private ResLoader resLoader = ResLoader.Allocate();
        protected override void OnInit(IUIData uiData = null)
        {
            StartCoroutine(GetData());
            BtnOnclickEvent();
            mData = uiData as KnowledgeAssetPanelData ?? new KnowledgeAssetPanelData();
        }

        private void BtnOnclickEvent()
        {
           
            SureBtn.onClick.AddListener(() =>
            {
                for (int i = 0; i < Questions.Count; i++)
                {
                    Questions[i].GetComponent<QuestionItem>().ISCorect();
                    Questions[i].GetComponent<QuestionItem>().SetInfo();
                    Questions[i].GetComponent<QuestionItem>().isWronOrTrue = Questions[i].GetComponent<QuestionItem>().ISCorect();
                }
            });
            BackToggle.onClick.AddListener(() =>
            {
                this.GetComponent<UIView>().SetVisibility(false);
                UIKit.GetPanel<HomepagePanel>().Center_DemoBg.GetComponent<UIView>().SetVisibility(true);
            });
        }
        private void Update()
        {
            if (ScrollView.verticalScrollbar.value >= 0)
            {
                SureBtn.transform.DOLocalMoveY(-973, 0.1f);
            }
            else
            {
                SureBtn.transform.DOLocalMoveY(-778, 0.1f);
            }
        }
        IEnumerator GetData()
        {
            var uri = new System.Uri(Path.Combine(Application.streamingAssetsPath, "TopicJson.json"));
            UnityWebRequest www = UnityWebRequest.Get(uri);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                JsonData jsonData = JsonMapper.ToObject(Encoding.UTF8.GetString(www.downloadHandler.data, 3, www.downloadHandler.data.Length - 3));

                for (int i = 0; i < jsonData["topicItemDMs"].Count; i++)
                {

                    GameObject gameObject = resLoader.LoadSync<GameObject>("resources://Question");
                    GameObject question = Instantiate(gameObject);
                    Questions.Add(question);

                    question.transform.parent = Content.transform;
                    question.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    question.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = jsonData["topicItemDMs"][i]["TopicTytle"].ToString();
                    question.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = jsonData["topicItemDMs"][i]["AnswerList"][0].ToString();
                    question.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = jsonData["topicItemDMs"][i]["AnswerList"][1].ToString();
                    question.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = jsonData["topicItemDMs"][i]["AnswerList"][2].ToString();
                    question.transform.GetChild(0).GetChild(1).GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = jsonData["topicItemDMs"][i]["AnswerList"][3].ToString();


                    for (int z = 0; z < jsonData["topicItemDMs"][i]["RealAnswerList"].Count; z++)
                    {
                        question.GetComponent<QuestionItem>().RealAnswerList.Add(jsonData["topicItemDMs"][i]["RealAnswerList"][z].ToString());
                    }
                    for (int j = 0; j < jsonData["topicItemDMs"][i]["AnswerList"].Count; j++)
                    {
                        question.GetComponent<QuestionItem>().AnswerList.Add(jsonData["topicItemDMs"][i]["AnswerList"][j].ToString());
                    }
                      
                  


                }
            }
        }


        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
        private void OnDestroy()
        {
            resLoader.Recycle2Cache();
            resLoader = null;
        }
    }
}
