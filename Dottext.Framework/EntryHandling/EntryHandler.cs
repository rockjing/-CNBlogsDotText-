using System;
using System.Xml.Serialization;
using Dottext.Framework;
using Dottext.Framework.Components;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Summary description for EntryFactoryItem.
	/// </summary>
	[Serializable]
	public class EntryHandler
	{
		public EntryHandler()
		{

		}

		private IEntryFactoryHandler ihandler = null;

		[XmlIgnoreAttribute]
		public IEntryFactoryHandler IEntryFactoryHandlerInstance
		{
			get
			{
				LoadIEntryFactoryHandler();
				return ihandler;
			}
		}

	
		private void LoadIEntryFactoryHandler()
		{
			if(ihandler == null)
			{
				if(this.ItemType == null)
				{
					throw new BlogProviderException("An EntryHandler (IEntryFactoryHandler) does not have its type property defined");
				}
				ihandler = (IEntryFactoryHandler)Activator.CreateInstance(Type.GetType(this.ItemType));
				if(ihandler == null)
				{
					throw new BlogProviderException(string.Format("The EntryHandler {0} could not be loaded",this.ItemType));
				}
			}
		}

		private PostType _postType = PostType.Undeclared;
		
		/// <summary>
		/// Property PostType (PostType)
		/// </summary>
		[XmlAttribute("postType")]
		public PostType PostType
		{
			get {return this._postType;}
			set {this._postType = value;}
		}

		private ProcessState _processState = ProcessState.Undefined;
		
		/// <summary>
		/// Property ProcessState (ProcessState)
		/// </summary>
		[XmlAttribute("processState")]
		public ProcessState ProcessState
		{
			get {return this._processState;}
			set {this._processState = value;}
		}

		private bool _isAsync;
		
		/// <summary>
		/// Property IsAsync (bool)
		/// </summary>
		[XmlAttribute("isAsync")]
		public bool IsAsync
		{
			get {return this._isAsync;}
			set {this._isAsync = value;}
		}


		private ProcessAction _processAction = ProcessAction.None;
		
		/// <summary>
		/// Property ProcessAction (ProcessAction)
		/// </summary>
		[XmlAttribute("processAction")]
		public ProcessAction ProcessAction
		{
			get {return this._processAction;}
			set {this._processAction = value;}
		}

		private string _itemType;
		
		/// <summary>
		/// Property ItemType (string)
		/// </summary>
		[XmlAttribute("type")]
		public string ItemType
		{
			get {return this._itemType;}
			set {this._itemType = value;}
		}

		
	}
}
