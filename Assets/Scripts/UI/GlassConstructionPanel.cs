using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Doozy.Engine.UI;

namespace QFramework.Example
{
	public class GlassConstructionPanelData : UIPanelData
	{
	}
	public partial class GlassConstructionPanel : UIPanel, IController
	{
		private AnimatorFSMModel mAnimatorFSMModel;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as GlassConstructionPanelData ?? new GlassConstructionPanelData();
			BtnOnckickEvent();
			// please add init code here
		}
        private void Start()
        {
			mAnimatorFSMModel = this.GetModel<AnimatorFSMModel>();

		}
        private void BtnOnckickEvent()
        {
			BackToggle.onClick.AddListener(() =>
			{
				this.GetComponent<UIView>().SetVisibility(false);
				UIKit.GetPanel<HomepagePanel>().Center_DemoBg.GetComponent<UIView>().SetVisibility(true);
			});
			RuleToggle.onClick.AddListener(() =>
			{
				UIKit.OpenPanelAsync<GlassSizePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
				{
					this.GetComponent<UIView>().SetVisibility(false);
					UIKit.GetPanel<GlassSizePanel>().transform.GetComponent<UIView>().SetVisibility(true);
					UIKit.GetPanel<GlassSizePanel>().GetSprites(RuleToggle);
					this.SendCommand<ReleCommand>();


				});

			});
			IrregularToggle.onClick.AddListener(() =>
			{
				UIKit.OpenPanelAsync<GlassSizePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
				{
					this.GetComponent<UIView>().SetVisibility(false);
					UIKit.GetPanel<GlassSizePanel>().transform.GetComponent<UIView>().SetVisibility(true);
					UIKit.GetPanel<GlassSizePanel>().GetSprites(IrregularToggle);
					this.SendCommand<IrregularCommand>();
				});

			});
			DifferentNumbersTogggle.onClick.AddListener(() =>
			{
				UIKit.OpenPanelAsync<GlassSizePanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
				{
					this.GetComponent<UIView>().SetVisibility(false);
					UIKit.GetPanel<GlassSizePanel>().transform.GetComponent<UIView>().SetVisibility(true);
					UIKit.GetPanel<GlassSizePanel>().GetSprites(DifferentNumbersTogggle);
					this.SendCommand<PowderCommand>();
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
		public IArchitecture GetArchitecture()
		{
			return AnimatorApp.Interface;
		}
		private new void OnDestroy()
		{
			mAnimatorFSMModel = null;
		}
	}
}
