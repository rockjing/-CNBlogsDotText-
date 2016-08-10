using System;
using System.Text;
using System.Web;
using Dottext.Framework.Providers;
using Dottext.Framework.Configuration;

namespace Dottext.Framework.Logger
{
	/// <summary>
	/// Summary description for LogManager.
	/// </summary>
	public class LogManager
	{
		private LogManager()
		{
		}

		public static int Create(Log blogLog)
		{
			//string logfile=HttpContext.Current.Server.MapPath("~/Logs/log.xml");
			//Util.SerializationHelper.AppendAndSave(blogLog,logfile);
			//return 1;
			return DbProvider.Instance().CreateLog(blogLog);
		}

		public static void Log(string title, string message)
		{
			Log log = new Log();
			log.Title = title;
			log.Message = message;
			Create(log);
		}

		private static string BuildExceptionMessage(Exception ex)
		{
			StringBuilder exceptionMsgs = new StringBuilder();
			while (null != ex) // this is obsolete since we're grabbing base...
			{
				exceptionMsgs.AppendFormat("\n{0}\n{1}\n{2} Soure:{3}", ex.GetType().Name, ex.Message,ex.StackTrace,ex.Source);
				ex = ex.InnerException;
			}
			return  exceptionMsgs.ToString();
		}

		public static int CreateExceptionLog(Exception ex, string title)
		{
			Log log = new Log();
			log.Title = title;
			log.Message = BuildExceptionMessage(ex);
			return Create(log);
		}

		public static int CreateWebExceptionLog(HttpContext Context)
		{
			Exception ex = Context.Server.GetLastError().GetBaseException();
			if(ex is System.IO.FileNotFoundException)
			{
				return 0;
			}
			BlogConfig config = null;
			try
			{				
				//we need a safer way to do this look up. Its a waste to throw an exception here.
				config = Config.CurrentBlog(Context);
			}
			catch
			{
			}

			Log log = new Log();

			if(config != null)
			{
				log.BlogID = config.BlogID;
			}

			log.Url = Context.Request.Url.ToString();

			log.Title = "Web Exception";
			
			log.Message = BuildExceptionMessage(ex);

			if(Context.Request.IsAuthenticated)
			{
				log.UserName = Context.User.Identity.Name;
			}
			
			return Create(log);
		}
	}
}
