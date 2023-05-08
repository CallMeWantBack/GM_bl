using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:e3d774b8-e485-461c-813d-b52a304f83e0
	public partial class UnveilFinishPanel
	{
		public const string Name = "UnveilFinishPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button HelpToggle;
		[SerializeField]
		public UnityEngine.UI.Button FullscreenToggle;
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		[SerializeField]
		public UnityEngine.UI.Button BrightBtn;
		[SerializeField]
		public UnityEngine.UI.Button FrostingBtn;
		[SerializeField]
		public UnityEngine.UI.Button BlackBtn;
		[SerializeField]
		public UnityEngine.UI.Button SmokeGreyBtn;
		[SerializeField]
		public UnityEngine.UI.Button TransparentBtn;
		[SerializeField]
		public UnityEngine.UI.Button VioletBtn;
		[SerializeField]
		public UnityEngine.UI.Button LightAmberBtn;
		[SerializeField]
		public UnityEngine.UI.Button DeepAmberBtn;
		[SerializeField]
		public UnityEngine.UI.Button GrassGreenBtn;
		[SerializeField]
		public UnityEngine.UI.Button DarkGreen;
		[SerializeField]
		public UnityEngine.UI.Button DarkBlueBtn;
		[SerializeField]
		public UnityEngine.UI.Button SkyBlueBtn;
		[SerializeField]
		public UnityEngine.UI.Button SubmitBtn;
		
		private UnveilFinishPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			HelpToggle = null;
			FullscreenToggle = null;
			BackToggle = null;
			BrightBtn = null;
			FrostingBtn = null;
			BlackBtn = null;
			SmokeGreyBtn = null;
			TransparentBtn = null;
			VioletBtn = null;
			LightAmberBtn = null;
			DeepAmberBtn = null;
			GrassGreenBtn = null;
			DarkGreen = null;
			DarkBlueBtn = null;
			SkyBlueBtn = null;
			SubmitBtn = null;
			
			mData = null;
		}
		
		public UnveilFinishPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UnveilFinishPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UnveilFinishPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
