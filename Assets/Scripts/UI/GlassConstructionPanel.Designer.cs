using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:28fbedd1-1ab0-4726-8a3d-ba405bc42870
	public partial class GlassConstructionPanel
	{
		public const string Name = "GlassConstructionPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		[SerializeField]
		public UnityEngine.UI.Button RuleToggle;
		[SerializeField]
		public UnityEngine.UI.Button IrregularToggle;
		[SerializeField]
		public UnityEngine.UI.Button DifferentNumbersTogggle;
		
		private GlassConstructionPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackToggle = null;
			RuleToggle = null;
			IrregularToggle = null;
			DifferentNumbersTogggle = null;
			
			mData = null;
		}
		
		public GlassConstructionPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		GlassConstructionPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new GlassConstructionPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
