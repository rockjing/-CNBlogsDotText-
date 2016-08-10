using System;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;
using System.Reflection;
using Dottext.Framework.EntryHandling;


namespace Dottext.Framework.Components
{
	public interface IFilterRealProxy
	{
		object Target
		{
			get;
		}
	}
	/// <summary>
	/// ValidateRealProxy ��ժҪ˵����
	/// </summary>
	public class FilterRealProxy:RealProxy,IRemotingTypeInfo
	{
		//private MarshalByRefObject target;
		private object _target;
		private	Type _targetType; 

		public FilterRealProxy(object target):base(target.GetType())
		{
			this._target=target;	
			this._targetType=target.GetType();
		}

		/*public static object Wrap(object target)
		{
			RealProxy realProxy = new FilterRealProxy(target);
			return realProxy.GetTransparentProxy();
		}*/

		public override ObjRef CreateObjRef( Type requestedType )
		{
			// We don't support marshaling objects wrapped in a 
			// Interposer, mainly because objects wrapped 
			// by this proxy may not be marshalable.  That is they
			// may not extend System.MarshalByRefObject.
			throw new NotSupportedException( 
				"Remoting of an interposed object is not supported." );
		}


		public override IMessage Invoke(IMessage msg)
		{
			
			
			IMethodCallMessage callMsg=msg as IMethodCallMessage;//�ο�JGTM'2004[MVP]������
			System.Runtime.Remoting.Messaging.IMethodCallMessage methodMessage=new MethodCallMessageWrapper(callMsg);
			System.Reflection.MethodBase method=methodMessage.MethodBase;
			object returnValue=method.Invoke(this._target,methodMessage.Args);
			
			//IMethodReturnMessage returnMsg = RemotingServices.ExecuteMessage(target,callMsg);//�ο�JGTM'2004[MVP]������
			if(this.IsMatchType(returnValue))//��鷵��ֵ�Ƿ�ΪString,�������String,��û��Ҫ���й���
			{
				string strReturnValue=this.Filter(returnValue.ToString(),methodMessage.MethodName);//returnMsg.MethodName);			
				return new ReturnMessage(strReturnValue,null,0,null,callMsg);//�ο�JGTM'2004[MVP]������
			}
			ReturnMessage returnMsg=new ReturnMessage(returnValue,methodMessage.Args,methodMessage.ArgCount,methodMessage.LogicalCallContext,methodMessage);
			return returnMsg;
			
			

		}

		protected string  Filter(string ReturnValue,string MethodName)
		{
			MethodInfo methodInfo=_target.GetType().GetMethod(MethodName);
			object[] attributes=methodInfo.GetCustomAttributes(typeof(StringFilter),true);
			foreach (object attrib in attributes)
			{
				return FilterHandler.Process(((StringFilter)attrib).FilterType,ReturnValue);
				
			}
			return ReturnValue;
		}
	
		public bool CanCastTo( Type type, object o )
		{
			// Allow a cast to IIinterposed or to any type supported by the 
			// underlying target object.
			bool valid = type == typeof( IFilterRealProxy ) || 
				type.IsAssignableFrom(_targetType);

			return valid;
		}

		public string TypeName
		{
			get 
			{
				throw new NotSupportedException();
			}

			set 
			{ 
				throw new NotSupportedException();
			}
		}

		protected bool IsMatchType(object obj)
		{
			return obj is System.String;
		}

		public object Target
		{
			get
			{
				return _target;
			}
		}
		/*protected bool IsMathMethod(string MethodName)
		{
			MethodInfo methodInfo=target.GetType().GetMethod(MethodName);
			
			object[] attributes=methodInfo.GetCustomAttributes(typeof(StringFilter),true);
			foreach (object attrib in attributes)
			{
				return ((StringFilter)attrib).FilterType
				//Console.WriteLine("attribName:{0}",((StringFilter)attrib).FilterType);
			}
			return false;
		}*/
	}
}
