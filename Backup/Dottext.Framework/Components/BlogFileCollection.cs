using System;
using System.Collections;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// BlogFileCollection 的摘要说明。
	/// </summary>
	public class BlogFileCollection : CollectionBase	
	{
		public BlogFileCollection()
		{
			
		}
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BlogFileCollection">BlogFileCollection</see> class containing the elements of the specified source collection.
		/// </summary>
		/// <param name="value">A <see cref="BlogFileCollection">BlogFileCollection</see> with which to initialize the collection.</param>
		public BlogFileCollection(BlogFileCollection value)	
		{
			this.AddRange(value);
		}
		
		public long TotalSize
		{
			get
			{
				return CalTotalSize();
			}

		}

		private long CalTotalSize()
		{
			long total=0;
			foreach(BlogFile file in this)
			{
				total+=file.Size;
			}
			return total;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="BlogFileCollection">BlogFileCollection</see> class containing the specified array of <see cref="BlogFile">BlogFile</see> Components.
		/// </summary>
		/// <param name="value">An array of <see cref="BlogFile">BlogFile</see> Components with which to initialize the collection. </param>
		public BlogFileCollection(BlogFile[] value)
		{
			this.AddRange(value);
		}
		
		/// <summary>
		/// Gets the <see cref="BlogFileCollection">BlogFileCollection</see> at the specified index in the collection.
		/// <para>
		/// In C#, this property is the indexer for the <see cref="BlogFileCollection">BlogFileCollection</see> class.
		/// </para>
		/// </summary>
		public BlogFile this[int index] 
		{
			get	{return ((BlogFile)(this.List[index]));}
		}
		
		public int Add(BlogFile value) 
		{
			return this.List.Add(value);
		}
		
		/// <summary>
		/// Copies the elements of the specified <see cref="BlogFile">BlogFile</see> array to the end of the collection.
		/// </summary>
		/// <param name="value">An array of type <see cref="BlogFile">BlogFile</see> containing the Components to add to the collection.</param>
		public void AddRange(BlogFile[] value) 
		{
			for (int i = 0;	(i < value.Length); i = (i + 1)) 
			{
				this.Add(value[i]);
			}
		}
		
		/// <summary>
		/// Adds the contents of another <see cref="BlogFileCollection">BlogFileCollection</see> to the end of the collection.
		/// </summary>
		/// <param name="value">A <see cref="BlogFileCollection">BlogFileCollection</see> containing the Components to add to the collection. </param>
		public void AddRange(BlogFileCollection value) 
		{
			for (int i = 0;	(i < value.Count); i = (i +	1))	
			{
				this.Add((BlogFile)value.List[i]);
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the collection contains the specified <see cref="BlogFileCollection">BlogFileCollection</see>.
		/// </summary>
		/// <param name="value">The <see cref="BlogFileCollection">BlogFileCollection</see> to search for in the collection.</param>
		/// <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
		public bool Contains(BlogFile value) 
		{
			return this.List.Contains(value);
		}
		
		/// <summary>
		/// Copies the collection Components to a one-dimensional <see cref="T:System.Array">Array</see> instance beginning at the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array">Array</see> that is the destination of the values copied from the collection.</param>
		/// <param name="index">The index of the array at which to begin inserting.</param>
		public void CopyTo(BlogFile[] array, int index) 
		{
			this.List.CopyTo(array, index);
		}
		
		/// <summary>
		/// Gets the index in the collection of the specified <see cref="BlogFileCollection">BlogFileCollection</see>, if it exists in the collection.
		/// </summary>
		/// <param name="value">The <see cref="BlogFileCollection">BlogFileCollection</see> to locate in the collection.</param>
		/// <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
		public int IndexOf(BlogFile value) 
		{
			return this.List.IndexOf(value);
		}
		
		public void Insert(int index, BlogFile value)	
		{
			List.Insert(index, value);
		}
		
		public void Remove(BlogFile value) 
		{
			List.Remove(value);
		}
		
		/// <summary>
		/// Returns an enumerator that can iterate through the <see cref="BlogFileCollection">BlogFileCollection</see> instance.
		/// </summary>
		/// <returns>An <see cref="BlogFileCollectionEnumerator">BlogFileCollectionEnumerator</see> for the <see cref="BlogFileCollection">BlogFileCollection</see> instance.</returns>
		public new BlogFileCollectionEnumerator GetEnumerator()	
		{
			return new BlogFileCollectionEnumerator(this);
		}
		
		/// <summary>
		/// Supports a simple iteration over a <see cref="BlogFileCollection">BlogFileCollection</see>.
		/// </summary>
		public class BlogFileCollectionEnumerator : IEnumerator	
		{
			private	IEnumerator _enumerator;
			private	IEnumerable _temp;
			
			/// <summary>
			/// Initializes a new instance of the <see cref="BlogFileCollectionEnumerator">BlogFileCollectionEnumerator</see> class referencing the specified <see cref="BlogFileCollection">BlogFileCollection</see> object.
			/// </summary>
			/// <param name="mappings">The <see cref="BlogFileCollection">BlogFileCollection</see> to enumerate.</param>
			public BlogFileCollectionEnumerator(BlogFileCollection mappings)
			{
				_temp =	((IEnumerable)(mappings));
				_enumerator = _temp.GetEnumerator();
			}
			
			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			public BlogFile Current
			{
				get {return ((BlogFile)(_enumerator.Current));}
			}
			
			object IEnumerator.Current
			{
				get {return _enumerator.Current;}
			}
			
			/// <summary>
			/// Advances the enumerator to the next element of the collection.
			/// </summary>
			/// <returns><b>true</b> if the enumerator was successfully advanced to the next element; <b>false</b> if the enumerator has passed the end of the collection.</returns>
			public bool MoveNext()
			{
				return _enumerator.MoveNext();
			}
			
			bool IEnumerator.MoveNext()
			{
				return _enumerator.MoveNext();
			}
			
			/// <summary>
			/// Sets the enumerator to its initial position, which is before the first element in the collection.
			/// </summary>
			public void Reset()
			{
				_enumerator.Reset();
			}
			
			void IEnumerator.Reset() 
			{
				_enumerator.Reset();
			}


		}
	}
}
