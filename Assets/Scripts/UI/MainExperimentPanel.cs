using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Collections.Generic;
using PicklePro;
using Doozy.Engine.UI;
using Cinemachine;
using HighlightPlus;

namespace QFramework.Example
{
    public class MainExperimentPanelData : UIPanelData
    {
    }
    public partial class MainExperimentPanel : UIPanel, IController
    {
        public List<Button> listBtns;
        private AnimatorFSMModel mAnimatorFSMModel;

        private bool count = true;
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as MainExperimentPanelData ?? new MainExperimentPanelData();
            OnClickEvent();
            // please add init code here
        }
        void Start()
        {
            mAnimatorFSMModel = this.GetModel<AnimatorFSMModel>();

            ActionEvent();
            BtnrollEvent();
            this.RegisterEvent<AnimaChangeEvent>(e =>
            {
                ActionEvent();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

        }
        public void Infortxt(string infortxt)
        {
            InformationImage.GetComponent<UIView>().SetVisibility(false);
            InformationImage.GetComponent<UIView>().SetVisibility(true);
            InformationTxt.text = infortxt;
        }
        private void OnClickEvent()
        {
            HelpToggle.onClick.AddListener(() =>
            {
                count = !count;
                if (count)
                {
                    UIKit.GetPanel<HelpPanel>().GetComponent<UIView>().SetVisibility(false);
                }
                else
                {

                    UIKit.OpenPanelAsync<HelpPanel>().ToAction().Start(monoBehaviour: this, onFinish: _ =>
                    {
                        UIKit.GetPanel<HelpPanel>().AsLastSibling();
                        UIKit.GetPanel<HelpPanel>().GetComponent<UIView>().SetVisibility(true);

                    });
                }

            });
            SureBtn_Pro.onClick.AddListener(() =>
            {
                TemperaturePromat.GetComponent<UIView>().SetVisibility(false);
                ModleCtroller.Instance.modleGlass[4].GetComponent<HighlightEffect>().highlighted = true;
                ModleCtroller.Instance.modleGlass[4].GetComponent<MeshCollider>().enabled = true;
                Infortxt("点击窑炉门");
            });
        }
        private void BtnrollEvent()
        {
            ResettingBtn.onClick.AddListener(() =>
            {
                TempNumTime.text = null;
                TempNumTop.text = null;


            });
            STartBtn.onClick.AddListener(() =>
            {
                if (TempNumTop.text != "200℃")
                {
                    Information.Show();

                }
                if (TempNumTime.text != "10h")
                {
                    InformationTime.Show();

                }
                if (TempNumTime.text == "10h" && TempNumTop.text == "200℃")
                {
                    InformationImage.GetComponent<UIView>().SetVisibility(false);
                    SliderDry.GetComponent<UIView>().SetVisibility(true);                  
                    TemperatureSetting.GetComponent<UIView>().SetVisibility(false);
                }
            });
            TemperatureTop.onClick.AddListener(() =>
            {
                this.SendCommand<InTempFirstcreaseCountCommand>();
            });
            TemperatureBelow.onClick.AddListener(() =>
            {
                this.SendCommand<DeTempLastecreaseCountCommand>();
            });
            TimeTop.onClick.AddListener(() =>
            {
                this.SendCommand<InTimeFirstecreaseCountCommand>();
            });
            TimeBelow.onClick.AddListener(() =>
            {
                this.SendCommand<DeTimeLastcreaseCountCommand>();
            });
            UpdateViewTemp();
            UpdateViewTime();
            this.RegisterEvent<NumCountChangeEvent>(e =>
            {
                UpdateViewTime();
                UpdateViewTemp();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        private void UpdateViewTemp()
        {
            TempNumTop.text = mAnimatorFSMModel.TemperatureNum.ToString() + "℃";
        }
        private void UpdateViewTime()
        {
            TempNumTime.text = mAnimatorFSMModel.TimeCount + "h";


        }
        private void ActionEvent()
        {
            ActionKit.Sequence()
               .Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.A)
               .Callback(() =>
               {
                   print("初始状态为A-----进入熔炉");
                   InpointerOnClickEvent.Instance.ShowScaleDo(KILN_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("点击耐火砖，（放在推车上）");
               })
               .Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.B)
               .Callback(() =>
               {
                   print("状态B-----烘干磨具");
                   InpointerOnClickEvent.Instance.ShowScaleDo(GrindingApparatus_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("请点击窑炉设置面板，设置温度与烘干时长");
               })
               .Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.C)
               .Callback(() =>
               {
                   print("状态C-----放置玻璃料");
                   InpointerOnClickEvent.Instance.ShowScaleDo(GlassFrit_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("请根据你所选的模具，选择相应的玻璃料");
               })
               .Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.D)
               .Callback(() =>
               {
                   print("状态D-----设置温度");
                   InpointerOnClickEvent.Instance.ShowScaleDo(Temperature_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("请点击窑炉温度设置面板进行温度调整");
               }).Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.E)
               .Callback(() =>
               {
                   print("状态D-----拆模");
                   InpointerOnClickEvent.Instance.ShowScaleDo(FormRemoval_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("请点击桌面工具进行拆模");
               })
               .Condition(() => mAnimatorFSMModel.FSM.CurrentStateId == AnimatorFSMModel.StepIstate.F)
               .Callback(() =>
               {
                   print("状态D-----冷加工");
                   InpointerOnClickEvent.Instance.ShowScaleDo(ColdWork_Btn, listBtns, 140, new Vector2(140, 60), new Vector2(200, 80), 140);
                   Infortxt("请点击工作台上的水磨机进行打磨");
               })
               .Start(this);
        }
        protected override void OnOpen(IUIData uiData = null)
        {
            ModleCtroller.Instance.ModleInit();

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
        private void Update()
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
