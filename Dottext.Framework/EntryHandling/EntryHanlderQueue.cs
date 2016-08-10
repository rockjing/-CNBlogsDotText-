using System;
using System.Threading;
using System.Diagnostics;

using Dottext.Framework.Components;
using Dottext.Framework.Util;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Quick helper class for adding IEntryHandlers to the managed queue.
	/// </summary>
	public class EntryHanlderQueue
	{
		//Current factory and entry
		public EntryHanlderQueue(IEntryFactoryHandler factory, Entry e)
		{
			this._factory = factory;
			this._entry = e;
		}
		private IEntryFactoryHandler _factory = null;
		private Entry _entry = null;

		public void Enqueue(object state)
		{
			_factory.Process(_entry);
		}

		/// <summary>
		/// Creates an Instance of FactoryQueue and adds the Factory to the queue.
		/// </summary>
		/// <param name="factory"></param>
		/// <param name="e"></param>
		public static void Enqueue(IEntryFactoryHandler factory, Entry e)
		{
			EntryHanlderQueue ehq = new EntryHanlderQueue(factory,e);
			ManagedThreadPool.QueueUserWorkItem(new WaitCallback(ehq.Enqueue));
		}
	}
}
