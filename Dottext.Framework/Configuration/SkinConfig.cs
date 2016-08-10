using System;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// Summary description for SkinConfig.
	/// </summary>
	[Serializable]
	public class SkinConfig
	{
		public SkinConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string _skinName="AnotherEon001";
		public string SkinName
		{
			get{return _skinName;}
			set{_skinName = value;}
		}

		private string _skinPath="~/Skins/";
		public string SkinPath
		{
			get{return _skinPath;}
			set{_skinPath = value;}
		}

		//private string _skinFullPath="~/Skins/";
		public string SkinFullPath
		{
			get
			{
				if(!SkinPath.EndsWith("/"))
				{
					SkinPath+="/";
				}
				return SkinPath+SkinName+"/";
			}
		
		}
		
		private string _controlPath;
		public string ControlPath
		{
			get{return _controlPath;}
			set{_controlPath = value;}
		}
		private string _teamplateFile="PageTemplate.ascx";
		public string TeamplateFile
		{
			get{
					return _teamplateFile;
			}
			set{_teamplateFile = value;}
		}

		public string TeamplateFilePath
		{
			get
			{
				if(!SkinPath.EndsWith("/"))
				{
					SkinPath+="/";
				}
				return SkinPath+SkinName+"/"+_teamplateFile;
			}
		}


		private string _skinCssFile;
		public string SkinCssFile
		{
			get{return _skinCssFile;}
			set{_skinCssFile = value;}
		}

		private string _skinCssText;
		public string SkinCssText
		{
			get{return _skinCssText;}
			set{_skinCssText = value;}
		}

		public bool HasSecondaryFile
		{
			get
			{
				return SkinCssFile != null && SkinCssFile.Trim().Length > 0;
			}
		}

		public bool HasSecondaryText
		{
			get
			{
				return SkinCssText != null && SkinCssText.Trim().Length > 0;
			}
		}

		//Subject to change. Do not rely on this for anything
		[System.Obsolete("This property is just a temporary placed holder. Very likely to go away in the next version",false)]
		public string SkinID
		{
			get
			{
				if(this.HasSecondaryFile)
				{
					return SkinName + "-" + SkinCssFile;
				}
				return SkinName;
			}
		}
	}
}
