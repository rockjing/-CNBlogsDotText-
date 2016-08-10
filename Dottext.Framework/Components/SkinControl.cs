using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// SkinControl 的摘要说明。
	/// </summary>
	[Serializable]
	public class SkinControl: IBlogIdentifier
	{
		public SkinControl()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		private int _id;
		public int ID
		{
			get {return this._id;}
			set {this._id = value;}
		}

		private int _blogID;
		public int BlogID
		{
			get {return this._blogID;}
			set {this._blogID = value;}
		}
		
		private string _name;
		public string Name
		{
			get {return this._name;}
			set {this._name = value;}
		}

		private string _control;
		public string Control
		{
			get {return this._control;}
			set {this._control = value;}
		}
		
		private bool _visible;
		public bool Visible
		{
			get {return this._visible;}
			set {this._visible = value;}
		}

	}
}
