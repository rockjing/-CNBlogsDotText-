using System;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;

using System.Diagnostics;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Wrapper around proccessing of each EntryHandler
	/// </summary>
	public class HandlerManager
	{
		public HandlerManager()
		{

		}

		/// <summary>
		/// Pass along the current entry to any PreCommit IEntryFactoryHandler
		/// </summary>
		/// <param name="e">Current Entry</param>
		/// <param name="pa">State of entry (Insert or Update)</param>
		public static void PreCommit(Entry e, ProcessAction pa)
		{
			Process(ProcessState.PreCommit,e,pa);
		}

		/// <summary>
		/// Pass along the current entry to any PostCommit IEntryFactoryHandler. These items 
		/// usually happen asynchronously.
		/// </summary>
		/// <param name="e">Current Entry</param>
		/// <param name="pa">State of entry (Insert or Update)</param>
		public static void PostCommit(Entry e, ProcessAction pa)
		{
			Process(ProcessState.PostCommit,e,pa);
		}

		public static void Process(ProcessState ps, Entry e, ProcessAction pa)
		{
			//Do we have factories?
			EntryHandler[] hanlers = Config.Settings.EntryHandlers;
			if(e != null && hanlers != null)
			{
				//walk the entries
				for(int i = 0; i<hanlers.Length; i++)
				{
					EntryHandler handler = hanlers[i];
					//System.IO.File.Create("f:\\"+i+"_"+(int)hanlers[i].PostType);
					//Are we at the correct state to process?
					if(ShouldProcess(ps,handler,e.PostType,pa))
					{
						IEntryFactoryHandler ihandler = handler.IEntryFactoryHandlerInstance;
						
						//Call the IEntryFactoryHandler configure method. This gives async items a chance to "ready" themselves 
						//before leaving the main thread and entering the managed queue.
						ihandler.Configure();

						if(handler.IsAsync)
						{
							//Add factory to managed queue.
							EntryHanlderQueue.Enqueue(ihandler,e);
						}
						else
						{
							ihandler.Process(e);
						}
					}
					
				}
			}
		}


		/// <summary>
		/// Quick helper to decide if we need to process the current EntryFactoryItem and Entry
		/// </summary>
		private static bool ShouldProcess(ProcessState ps, EntryHandler handler, PostType pt, ProcessAction pa)
		{
			//Correct State? PreCommit or PostCommit?
			if(ps ==handler.ProcessState)
			{
				//Correct Action? Insert? and/or Delete?
				if(ValidateProcessAction(pa,handler.ProcessAction))
				{
					//Do we process this kind of Entry?
					 return ValidatePostType(pt,handler.PostType);					
				}
			}
			return false;
		}

		private static bool ValidatePostType(PostType EntryPostType, PostType ConfigPostType)
		{
			//return //EntryPostType==ConfigPostType; 
			return	(EntryPostType & ConfigPostType) == EntryPostType;
		}

		private static bool ValidateProcessAction(ProcessAction EntryProccessAction, ProcessAction ConfigProcessAction)
		{
			return (EntryProccessAction & ConfigProcessAction) == EntryProccessAction;
		}
	}
}
