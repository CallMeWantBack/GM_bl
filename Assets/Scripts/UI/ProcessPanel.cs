using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
using Doozy.Engine.UI;
using System.Collections.Generic;
using PicklePro;

namespace QFramework.Example
{
	public class ProcessPanelData : UIPanelData
	{
	}
	public partial class ProcessPanel : UIPanel
	{
        public List<GameObject> txtContents;
        public List<Button> buttons;
        private void Awake()
        {
            BtnOnclickEvent();
        }
        private void BtnOnclickEvent()
        {
            var inpointerOnclickEvent = InpointerOnClickEvent.Instance;
            ProcessPurpose_Btn.onClick.AddListener(() =>
            {
                inpointerOnclickEvent.ShowScaleDo(ProcessPurpose_Btn, buttons, -135, new Vector2(140, 60), new Vector2(220, 80), -215);
                ShowContent(0);
            });
            Principle_Btn.onClick.AddListener(() =>
            {

                inpointerOnclickEvent.ShowScaleDo(Principle_Btn, buttons, -135, new Vector2(140, 60), new Vector2(220, 80), -215);
                ShowContent(1);
            });
            TechnRequi_Btn.onClick.AddListener(() =>
            {

                inpointerOnclickEvent.ShowScaleDo(TechnRequi_Btn, buttons, -135, new Vector2(140, 60), new Vector2(220, 80), -215);
                ShowContent(2);
            });
            ViewCompletedBtn.onClick.AddListener(() =>
            {
                print(string.Format("<color=Yellow>{0}</color>", "-----------------"));
                inpointerOnclickEvent.BackToggleScale(buttons, -215);
                this.GetComponent<UIView>().SetVisibility(false);
                UIKit.GetPanel<HomepagePanel>().Center_DemoBg.GetComponent<UIView>().SetVisibility(true);
               
            });
            BackToggle.onClick.AddListener(() =>
            {
                inpointerOnclickEvent.BackToggleScale(buttons, -215);
                this.GetComponent<UIView>().SetVisibility(false);
                UIKit.GetPanel<HomepagePanel>().Center_DemoBg.GetComponent<UIView>().SetVisibility(true);
               
            });
        }
        private void ShowContent(int index)
        {
            var toggle = txtContents;
            for (int i = 0; i < toggle.Count; i++)
            {
                GameObject go = toggle[i];
                go.SetActive(false);
            }

            if (index < toggle.Count)
            {
                //SetActive(toggleContents[index], isShow);
                toggle[index].SetActive(true);
            }
        }
        public void BackToggleScale()
        {
            for (int i = 0; i < buttons.Count; i++)
            {

                if (buttons[i].GetComponent<ToggleEffect>().isOn == true)
                {
                    Debug.Log(buttons[i].name);
                    buttons[i].GetComponent<RectTransform>().DOAnchorPosX(-215, 0, true);
                }
            }


        }
        protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as ProcessPanelData ?? new ProcessPanelData();
			// please add init code here
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
	}
}
