using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:ce313cd0-f553-4462-b470-aae1dda8e036
	public partial class MainExperimentPanel
	{
		public const string Name = "MainExperimentPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button KILN_Btn;
		[SerializeField]
		public UnityEngine.UI.Button GrindingApparatus_Btn;
		[SerializeField]
		public UnityEngine.UI.Button GlassFrit_Btn;
		[SerializeField]
		public UnityEngine.UI.Button Temperature_Btn;
		[SerializeField]
		public UnityEngine.UI.Button FormRemoval_Btn;
		[SerializeField]
		public UnityEngine.UI.Button ColdWork_Btn;
		[SerializeField]
		public UnityEngine.UI.Image InformationImage;
		[SerializeField]
		public TMPro.TextMeshProUGUI InformationTxt;
		[SerializeField]
		public UnityEngine.UI.Button BackToggle;
		[SerializeField]
		public UnityEngine.UI.Button FullscreenToggle;
		[SerializeField]
		public UnityEngine.UI.Button HelpToggle;
		[SerializeField]
		public UnityEngine.UI.Image BlackBg;
		[SerializeField]
		public UnityEngine.UI.Image TemperatureSetting;
		[SerializeField]
		public RectTransform Temperature_Te;
		[SerializeField]
		public UnityEngine.UI.Button TemperatureTop;
		[SerializeField]
		public UnityEngine.UI.Button TemperatureBelow;
		[SerializeField]
		public TMPro.TextMeshProUGUI Information;
		[SerializeField]
		public TMPro.TextMeshProUGUI TempNumTop;
		[SerializeField]
		public RectTransform Time;
		[SerializeField]
		public UnityEngine.UI.Button TimeTop;
		[SerializeField]
		public UnityEngine.UI.Button TimeBelow;
		[SerializeField]
		public TMPro.TextMeshProUGUI InformationTime;
		[SerializeField]
		public TMPro.TextMeshProUGUI TempNumTime;
		[SerializeField]
		public UnityEngine.UI.Button ResettingBtn;
		[SerializeField]
		public UnityEngine.UI.Button STartBtn;
		[SerializeField]
		public UnityEngine.UI.Image TemperaturePromat;
		[SerializeField]
		public UnityEngine.UI.Button SureBtn_Pro;
		[SerializeField]
		public TemperatureSetting SelectGlass;
		[SerializeField]
		public UnityEngine.UI.Image SelectGlassNoNumber;
		[SerializeField]
		public UnityEngine.UI.Button SureBtn_Num;
		[SerializeField]
		public UnityEngine.UI.Button Grey_Gl;
		[SerializeField]
		public UnityEngine.UI.Button Violet_Gl;
		[SerializeField]
		public UnityEngine.UI.Button Green_Gl;
		[SerializeField]
		public UnityEngine.UI.Button Blue_Gl;
		[SerializeField]
		public UnityEngine.UI.Button Yellow_Gl;
		[SerializeField]
		public SliderDry SliderDry;
		[SerializeField]
		public TemperatureNine TemperatureNine;
		[SerializeField]
		public TemperatureSix TemperatureSix;
		[SerializeField]
		public UnityEngine.UI.Image BackHomePagePanel;
		[SerializeField]
		public UnityEngine.UI.Image ColdWorkOverPanel;
		
		private MainExperimentPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			KILN_Btn = null;
			GrindingApparatus_Btn = null;
			GlassFrit_Btn = null;
			Temperature_Btn = null;
			FormRemoval_Btn = null;
			ColdWork_Btn = null;
			InformationImage = null;
			InformationTxt = null;
			BackToggle = null;
			FullscreenToggle = null;
			HelpToggle = null;
			BlackBg = null;
			TemperatureSetting = null;
			Temperature_Te = null;
			TemperatureTop = null;
			TemperatureBelow = null;
			Information = null;
			TempNumTop = null;
			Time = null;
			TimeTop = null;
			TimeBelow = null;
			InformationTime = null;
			TempNumTime = null;
			ResettingBtn = null;
			STartBtn = null;
			TemperaturePromat = null;
			SureBtn_Pro = null;
			SelectGlass = null;
			SelectGlassNoNumber = null;
			SureBtn_Num = null;
			Grey_Gl = null;
			Violet_Gl = null;
			Green_Gl = null;
			Blue_Gl = null;
			Yellow_Gl = null;
			SliderDry = null;
			TemperatureNine = null;
			TemperatureSix = null;
			BackHomePagePanel = null;
			ColdWorkOverPanel = null;
			
			mData = null;
		}
		
		public MainExperimentPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		MainExperimentPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MainExperimentPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
