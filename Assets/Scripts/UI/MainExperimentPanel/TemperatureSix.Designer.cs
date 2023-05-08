/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class TemperatureSix
	{
		[SerializeField] public UnityEngine.UI.Image SetTemCC;
		[SerializeField] public UnityEngine.UI.Button CCbTN_Six;
		[SerializeField] public TMPro.TMP_InputField TemccInputFiled_Six;

		public void Clear()
		{
			SetTemCC = null;
			CCbTN_Six = null;
			TemccInputFiled_Six = null;
		}

		public override string ComponentName
		{
			get { return "TemperatureSix";}
		}
	}
}
