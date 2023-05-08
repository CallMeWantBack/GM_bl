/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using PicklePro;

namespace QFramework.Example
{
	public partial class TemperatureSetting : UIElement, IController
    {
        private AnimatorFSMModel mAnimatorFSMModel;
        public Toggle[] toggleEffects;
        public Queue<Toggle> toggleEffectsQue = new Queue<Toggle>();
      
        private void Awake()
		{
            mAnimatorFSMModel = this.GetModel<AnimatorFSMModel>();
            switch (mAnimatorFSMModel.Mold_Style)
            {
                case AnimatorFSMModel.MoldStyle.Rule:
                    
                    break;
                case AnimatorFSMModel.MoldStyle.Irregular:
                    ToggleGroup.GetComponent<ToggleEffectGroup>().enabled = false;
           
                    for (int i = 0; i < toggleEffects.Length; i++)
                    {
                        toggleEffects[i].GetComponent<ToggleEffect>().enabled = false;
                        if (toggleEffects[i].isOn==true)
                        {
                            toggleEffectsQue.Enqueue(toggleEffects[i]);
                        }
                    }
                    if (toggleEffectsQue.Count>2)
                    {
                        var deleQue=toggleEffectsQue.Dequeue();
                        deleQue.isOn = false;
                    }
                    break;
                case AnimatorFSMModel.MoldStyle.Powder:
                   
                    break;
                case AnimatorFSMModel.MoldStyle.Default:
                    break;
                default:
                    break;
            }
        }
        private new void OnDestroy()
        {

            mAnimatorFSMModel = null;
        }
        public IArchitecture GetArchitecture()
        {
            return AnimatorApp.Interface;
        }
        //private void style
        protected override void OnBeforeDestroy()
		{
		}
	}
}