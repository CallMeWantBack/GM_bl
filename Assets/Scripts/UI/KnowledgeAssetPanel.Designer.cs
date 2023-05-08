using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:ac75d751-bf3a-4609-8d9f-592faee27dc2
	public partial class KnowledgeAssetPanel
	{
		public const string Name = "KnowledgeAssetPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		[SerializeField]
		public UnityEngine.UI.ScrollRect ScrollView;
		[SerializeField]
		public RectTransform Content;
		[SerializeField]
		public UnityEngine.UI.Button SureBtn;
		
		private KnowledgeAssetPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackToggle = null;
			ScrollView = null;
			Content = null;
			SureBtn = null;
			
			mData = null;
		}
		
		public KnowledgeAssetPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		KnowledgeAssetPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new KnowledgeAssetPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
