using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Doozy.Engine.UI;

namespace QFramework.Example
{
	public class TestReportPanelData : UIPanelData
	{
	}
	public partial class TestReportPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as TestReportPanelData ?? new TestReportPanelData();
			OnclickBtnEvent();
			// please add init code here
		}
		private void OnclickBtnEvent()
        {
			BackToggle.onClick.AddListener(() =>
			{
				this.GetComponent<UIView>().SetVisibility(false);
				UIKit.GetPanel<HomepagePanel>().Center_DemoBg.GetComponent<UIView>().SetVisibility(true);
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
