using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// 
	/// </summary>
	public interface BuildTree
	{
		AbstractComponent Build();
		void Persistent();
	 	
	}

}
