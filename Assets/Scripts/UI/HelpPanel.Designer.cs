using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:0878f4a5-223f-46df-9226-fa941fb9b926
	public partial class HelpPanel
	{
		public const string Name = "HelpPanel";
		
		
		private HelpPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public HelpPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		HelpPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new HelpPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
