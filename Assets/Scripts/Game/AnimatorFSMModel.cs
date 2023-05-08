using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{

    //M 层 数据状态机
    public class AnimatorFSMModel : AbstractModel
    {
        /// <summary>
        /// 温度
        /// </summary>
        public int TemperatureNum;

        /// <summary>
        /// 时长
        /// </summary>
        public int TimeCount;
        /// <summary>
        /// 操作步骤
        /// </summary>
        public enum StepIstate
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G
        }
        /// <summary>
        /// 规则 不规则 粉末
        /// </summary>
        public enum MoldStyle
        {
            Rule,
            Irregular,
            Powder,
            Default
        }
        /// <summary>
        /// 大尺寸 小尺寸
        /// </summary>
        public enum MoldSize
        {
             Big,
             Small,
             Default
        }
        public FSM<StepIstate> FSM;
        public MoldStyle Mold_Style;
        public MoldSize Mold_Size;

        // Start is called before the first frame update

        protected override void OnInit()
        {
            FSM = new FSM<StepIstate>();
            Mold_Style = MoldStyle.Default;
            Mold_Size = MoldSize.Default;
            TemperatureNum = 0;
            TimeCount = 0;
        }
    }
    public class AnimatorApp : Architecture<AnimatorApp>
    {
        protected override void Init()
        {
            this.RegisterModel(new AnimatorFSMModel());
        }
    }
    public struct AnimaChangeEvent
    {


    }
    public struct NumCountChangeEvent
    {


    }
    public struct ModleSizeOrStaly
    {


    }
    public class ReleCommand : AbstractCommand
    {
        protected override void OnExecute()
        {

            this.GetModel<AnimatorFSMModel>().Mold_Style = AnimatorFSMModel.MoldStyle.Rule;
            this.SendEvent<ModleSizeOrStaly>();
        }
    }
    public class IrregularCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().Mold_Style = AnimatorFSMModel.MoldStyle.Irregular;
            this.SendEvent<ModleSizeOrStaly>();
        }
    }
    public class PowderCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().Mold_Style = AnimatorFSMModel.MoldStyle.Powder;
            this.SendEvent<ModleSizeOrStaly>();
        }
    }
    public class BigSizeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().Mold_Size = AnimatorFSMModel.MoldSize.Big;
            this.SendEvent<ModleSizeOrStaly>();
        }
    }
    public class SmallSizeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().Mold_Size = AnimatorFSMModel.MoldSize.Small;
            this.SendEvent<ModleSizeOrStaly>();
        }
    }
    public class IacreaseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.A);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IbcreaseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.B);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IccresseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.C);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IdcresseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.D);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IecresseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.E);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IfcresseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.F);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class IgcresseAniCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<AnimatorFSMModel>().FSM.ChangeState(AnimatorFSMModel.StepIstate.G);
            this.SendEvent<AnimaChangeEvent>();
        }
    }
    public class InTempFirstcreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
           
            if (this.GetModel<AnimatorFSMModel>().TemperatureNum==250)
            {
                this.GetModel<AnimatorFSMModel>().TemperatureNum = 250;
            }
            else
            {
                this.GetModel<AnimatorFSMModel>().TemperatureNum += 10;
            }
            this.SendEvent<NumCountChangeEvent>();
        }
    }
    public class DeTempLastecreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
          
            if (this.GetModel<AnimatorFSMModel>().TemperatureNum == 0)
            {
                this.GetModel<AnimatorFSMModel>().TemperatureNum = 0;
            }
            else
            {
                this.GetModel<AnimatorFSMModel>().TemperatureNum -= 10;
            }
            this.SendEvent<NumCountChangeEvent>();
        }
    }
    public class InTimeFirstecreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            if (this.GetModel<AnimatorFSMModel>().TimeCount==24)
            {
                this.GetModel<AnimatorFSMModel>().TimeCount = 24;
            }
            else
            {
                this.GetModel<AnimatorFSMModel>().TimeCount += 1;
            }
           
            this.SendEvent<NumCountChangeEvent>();
        }
    }
    public class DeTimeLastcreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            if (this.GetModel<AnimatorFSMModel>().TimeCount == 0)
            {
                this.GetModel<AnimatorFSMModel>().TimeCount = 0;
            }
            else
            {
                this.GetModel<AnimatorFSMModel>().TimeCount -= 1;
            }
          
            this.SendEvent<NumCountChangeEvent>();
        }
    }
}
