/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class TemperatureSetting
	{
		[SerializeField] public UnityEngine.UI.Button SureBtn_Glass;
		[SerializeField] public RectTransform ToggleGroup;
		[SerializeField] public UnityEngine.UI.Toggle Violet_Se;
		[SerializeField] public UnityEngine.UI.Toggle Green_Se;
		[SerializeField] public UnityEngine.UI.Toggle Blue_Se;
		[SerializeField] public UnityEngine.UI.Toggle Yellow_Se;

		public void Clear()
		{
			SureBtn_Glass = null;
			ToggleGroup = null;
			Violet_Se = null;
			Green_Se = null;
			Blue_Se = null;
			Yellow_Se = null;
		}

		public override string ComponentName
		{
			get { return "TemperatureSetting";}
		}
	}
}
