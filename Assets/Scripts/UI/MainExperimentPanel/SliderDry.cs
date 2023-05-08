/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Collections;
using Doozy.Engine.UI;

namespace QFramework.Example
{
	public partial class SliderDry : UIElement
	{
		private void Start()
		{
			StartCoroutine(ImageUpdate());
		}
		IEnumerator ImageUpdate()
		{
			float value = 0; 
			while (value <= 1)
			{
				yield return new WaitForSeconds(0.1f);
				value += 0.01f;
				SliderImg.fillAmount = value;
			}
			if (SliderImg.fillAmount >= 0.9)
			{
				UIKit.GetPanel<MainExperimentPanel>().TemperaturePromat.GetComponent<UIView>().SetVisibility(true);
				this.GetComponent<UIView>().SetVisibility(false);
				
			}
		}
		protected override void OnBeforeDestroy()
		{
		}
	}
}