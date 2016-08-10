using System;
using Dottext.Framework.Components;
using Dottext.Framework.Providers;
using Dottext.Framework.Configuration;

namespace Dottext.Framework
{
	/// <summary>
	/// SkinControls ��ժҪ˵����
	/// </summary>
	public class SkinControls
	{
		public SkinControls()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static SkinControlCollection GetSkinControlCollection(int BlogID)
		{
			return DTOProvider.Instance().GetSkinControlCollection(BlogID);
		}

		public static void UpdateSkinControl(SkinControlCollection scc)
		{
			foreach(SkinControl sc in scc)
			{
				DTOProvider.Instance().UpateSkinControl(sc);
			}
			//return DTOProvider.Instance().GetSkinControlCollection(BlogID);
		}

		public static bool UpdateSingleSkinControl(int ControlID,bool visible,int BlogID)
		{
			return DTOProvider.Instance().UpdateSingleSkinControl(ControlID,visible,BlogID);
		
		}




	}
}
