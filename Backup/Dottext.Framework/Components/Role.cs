using System;

namespace Dottext.Framework.Components
{
	
	/// <summary>
	/// Role ��ժҪ˵����
	/// </summary>
	public class Role
	{
		public Role()
		{
			
		}
		
		private int _RoleID;
		public int RoleID
		{
			get
			{
				return _RoleID;
			}
			set
			{
				_RoleID=value;
			}
		}

		private string  _Name;
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name=value;
			}
		}

		private string  _Description;
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description=value;
			}
		}

		
	}
}
