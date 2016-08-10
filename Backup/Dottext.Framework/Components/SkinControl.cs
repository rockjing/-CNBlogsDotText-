using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// SkinControl ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class SkinControl: IBlogIdentifier
	{
		public SkinControl()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
