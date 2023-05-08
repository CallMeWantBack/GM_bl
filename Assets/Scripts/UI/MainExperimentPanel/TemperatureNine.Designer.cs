/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class TemperatureNine
	{
		[SerializeField] public UnityEngine.UI.Image SetTemCC;
		[SerializeField] public UnityEngine.UI.Button CCbTN;
		[SerializeField] public TMPro.TMP_InputField TemccInputFiled;

		public void Clear()
		{
			SetTemCC = null;
			CCbTN = null;
			TemccInputFiled = null;
		}

		public override string ComponentName
		{
			get { return "TemperatureNine";}
		}
	}
}
