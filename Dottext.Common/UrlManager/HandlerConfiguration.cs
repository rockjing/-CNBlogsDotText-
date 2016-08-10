using System;
using System.Web;
using System.Configuration;
using System.Xml.Serialization;

namespace Dottext.Common.UrlManager
{
	/// <summary>
	/// Summary description for HandlerConfiguration.
	/// </summary>
	public class HandlerConfiguration
	{

		public static void SetControls(HttpContext context, string[] controls)
		{
			if(controls != null)
			{
				context.Items.Add("Dottext.Common.UrlManager.ControlContext",controls);
			}
		}

		public static string[] GetControls(HttpContext context)
		{
			return (string[])context.Items["Dottext.Common.UrlManager.ControlContext"];
		}

		public HandlerConfiguration()
		{

		}

		private HttpHandler[] _httpHandlers;
		[XmlArray("HttpHandlers")]
		public HttpHandler[] HttpHandlers
		{
			get {return this._httpHandlers;}
			set {this._httpHandlers = value;}
		}

		private string _defaultPageLocation;
		[XmlAttribute("defaultPageLocation")]
		public string DefualtPageLocation
		{
			get {return this._defaultPageLocation;}
			set {this._defaultPageLocation = value;}
		}

		private string _fullPageLocation;
		public string FullPageLocation
		{
			get {
				if(this._fullPageLocation == null)
				{
					this._fullPageLocation = HttpContext.Current.Server.MapPath("~/" + DefualtPageLocation);
				}
				return this._fullPageLocation;
			}
		}



		public static HandlerConfiguration Instance()
		{
			return ((HandlerConfiguration)ConfigurationSettings.GetConfig("HandlerConfiguration"));
		}
	}
}
