using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:bd822075-759b-4144-bf19-92e7bcb219d0
	public partial class GlassSizePanel
	{
		public const string Name = "GlassSizePanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		[SerializeField]
		public UnityEngine.UI.Button SmallSize;
		[SerializeField]
		public UnityEngine.UI.Button BigSize;
		
		private GlassSizePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackToggle = null;
			SmallSize = null;
			BigSize = null;
			
			mData = null;
		}
		
		public GlassSizePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		GlassSizePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new GlassSizePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
