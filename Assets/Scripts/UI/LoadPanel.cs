using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Doozy;
using Doozy.Engine.UI;

namespace QFramework.Example
{
	public class LoadPanelData : UIPanelData
	{
	}
	public partial class LoadPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as LoadPanelData ?? new LoadPanelData();
			// please add init code here
			Btn_OnclickEvent();
		}
		private void Btn_OnclickEvent()
        {
			StartExperimentBtn.onClick.AddListener(() =>
			{			
				UIKit.OpenPanelAsync<HomepagePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
				{
					UIKit.GetPanel<HomepagePanel>().AsFirstSibling();
					this.GetComponent<UIView>().SetVisibility(false);
				});
			});
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
