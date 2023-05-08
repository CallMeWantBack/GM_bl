using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:40f9ab15-0e71-4bca-a6e4-38815a5a5a7f
	public partial class HomepagePanel
	{
		public const string Name = "HomepagePanel";
		
		[SerializeField]
		public UnityEngine.UI.Button HelpToggle;
		[SerializeField]
		public UnityEngine.UI.Button FullscreenToggle;
		[SerializeField]
		public UnityEngine.UI.Image Center_DemoBg;
		/// <summary>
		/// 加载界面开始进入按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button ProcessAwareness;
		/// <summary>
		/// 加载界面开始进入按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button GlassCasting;
		/// <summary>
		/// 加载界面开始进入按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button KnowledgeAssessment;
		/// <summary>
		/// 加载界面开始进入按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button TestReport;
		
		private HomepagePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			HelpToggle = null;
			FullscreenToggle = null;
			Center_DemoBg = null;
			ProcessAwareness = null;
			GlassCasting = null;
			KnowledgeAssessment = null;
			TestReport = null;
			
			mData = null;
		}
		
		public HomepagePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		HomepagePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new HomepagePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
