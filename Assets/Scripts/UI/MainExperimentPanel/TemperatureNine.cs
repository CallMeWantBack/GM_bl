/****************************************************************************
 * 2023.4 ADMIN-20230222X
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TMPro;
namespace QFramework.Example
{
	public partial class TemperatureNine : UIElement
	{
		public List<Button> buttons;
		public string TempNum;
		public string InputTxt;
		private void Awake()
		{
            foreach (var item in buttons)
            {
				item.transform.GetChild(1).gameObject.SetActive(false);
				item.onClick.AddListener(() =>
				{
					SetTemCC.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y+80, item.transform.localPosition.z);
					TempNum = item.transform.GetChild(0).GetComponent<TMP_Text>().text;
					SetHide();
					item.transform.GetChild(1).gameObject.SetActive(true);
				});
            }
			TemccInputFiled.onValueChanged.AddListener(delegate 
			{
				InputTxt = TemccInputFiled.text;
               
               
			});
			CCbTN.onClick.AddListener(() =>
			{
                if (TempNum!=InputTxt)
                {
					print(" ‰»Î¥ÌŒÛ");
                }
			});
		}
		private void SetHide()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
				buttons[i].transform.GetChild(1).gameObject.SetActive(false);
			}
        }

		protected override void OnBeforeDestroy()
		{
		}
	}
}