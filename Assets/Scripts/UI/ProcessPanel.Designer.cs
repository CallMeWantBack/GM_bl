using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:3c7f7ab2-b837-4ebf-bf9f-5a0fb51a192e
	public partial class ProcessPanel
	{
		public const string Name = "ProcessPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		/// <summary>
		/// 工艺目的
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button ProcessPurpose_Btn;
		/// <summary>
		/// 工艺原理
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button Principle_Btn;
		/// <summary>
		/// 工艺要求
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button TechnRequi_Btn;
		/// <summary>
		/// 完成
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button ViewCompletedBtn;
		[SerializeField]
		public TMPro.TextMeshProUGUI PurposeTxt;
		[SerializeField]
		public TMPro.TextMeshProUGUI PrincipleTxt;
		[SerializeField]
		public TMPro.TextMeshProUGUI TechnRequiTxt;
		
		private ProcessPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackToggle = null;
			ProcessPurpose_Btn = null;
			Principle_Btn = null;
			TechnRequi_Btn = null;
			ViewCompletedBtn = null;
			PurposeTxt = null;
			PrincipleTxt = null;
			TechnRequiTxt = null;
			
			mData = null;
		}
		
		public ProcessPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		ProcessPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new ProcessPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
