using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:742e13b9-9719-4913-984f-c50da83fc9a6
	public partial class LoadPanel
	{
		public const string Name = "LoadPanel";
		
		/// <summary>
		/// 加载界面开始进入按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button StartExperimentBtn;
		
		private LoadPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			StartExperimentBtn = null;
			
			mData = null;
		}
		
		public LoadPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		LoadPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new LoadPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
