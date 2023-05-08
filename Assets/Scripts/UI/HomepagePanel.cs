using Doozy.Engine.UI;
namespace QFramework.Example
{
    public class HomepagePanelData : UIPanelData
    {
    }
    public partial class HomepagePanel : UIPanel
    {
       
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as HomepagePanelData ?? new HomepagePanelData();
            BtnOclickeEvent();
            
            // please add init code here
        }


        private void BtnOclickeEvent()
        {
            ProcessAwareness.onClick.AddListener(() =>
            {
                UIKit.OpenPanelAsync<ProcessPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<ProcessPanel>().BackToggleScale();
                    UIKit.GetPanel<ProcessPanel>().GetComponent<UIView>().SetVisibility(true);
                    Center_DemoBg.GetComponent<UIView>().SetVisibility(false);
                });
            });
            GlassCasting.onClick.AddListener(() =>
            {
                UIKit.OpenPanelAsync<GlassConstructionPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<GlassConstructionPanel>().GetComponent<UIView>().SetVisibility(true);
                    Center_DemoBg.GetComponent<UIView>().SetVisibility(false);

                });
            });
            KnowledgeAssessment.onClick.AddListener(() =>
            {
                UIKit.OpenPanelAsync<KnowledgeAssetPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<KnowledgeAssetPanel>().GetComponent<UIView>().SetVisibility(true);
                    Center_DemoBg.GetComponent<UIView>().SetVisibility(false);

                });
            });
            TestReport.onClick.AddListener(() =>
            {
                UIKit.OpenPanelAsync<TestReportPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                {
                    UIKit.GetPanel<TestReportPanel>().GetComponent<UIView>().SetVisibility(true);
                    Center_DemoBg.GetComponent<UIView>().SetVisibility(false);

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
