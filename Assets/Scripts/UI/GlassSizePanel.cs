using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Doozy.Engine.UI;
using Cinemachine;
namespace QFramework.Example
{
    public class GlassSizePanelData : UIPanelData
    {
    }
    public partial class GlassSizePanel : UIPanel
    {
      
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as GlassSizePanelData ?? new GlassSizePanelData();
            BtnOnckickEvent();
            // please add init code here
        }
        private void BtnOnckickEvent()
        {
            BackToggle.onClick.AddListener(() =>
            {
                this.GetComponent<UIView>().SetVisibility(false);
                UIKit.GetPanel<GlassConstructionPanel>().GetComponent<UIView>().SetVisibility(true);
            });
            SmallSize.onClick.AddListener(() =>
            {
                UIKit.OpenPanelAsync<MainExperimentPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<MainExperimentPanel>().AsLastSibling();
                    this.GetComponent<UIView>().SetVisibility(false);
                    UIKit.GetPanel<HomepagePanel>().Hide();
                });

            });
            BigSize.onClick.AddListener(() =>
            {

                UIKit.OpenPanelAsync<MainExperimentPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<MainExperimentPanel>().AsLastSibling();
                    this.GetComponent<UIView>().SetVisibility(false);
                    UIKit.GetPanel<HomepagePanel>().Hide();
                });
            });
        }
        public void GetSprites(Button button)
        {
            SmallSize.transform.GetChild(0).GetComponent<Image>().sprite = button.transform.GetChild(0).GetComponent<Image>().sprite;
            BigSize.transform.GetChild(0).GetComponent<Image>().sprite = button.transform.GetChild(0).GetComponent<Image>().sprite;
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
