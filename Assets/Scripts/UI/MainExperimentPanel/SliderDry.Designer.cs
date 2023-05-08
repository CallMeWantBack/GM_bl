/****************************************************************************
 * 2023.5 ADMIN-20230222X
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public partial class SliderDry
	{
		[SerializeField] public UnityEngine.UI.Image SliderImg;

		public void Clear()
		{
			SliderImg = null;
		}

		public override string ComponentName
		{
			get { return "SliderDry";}
		}
	}
}
