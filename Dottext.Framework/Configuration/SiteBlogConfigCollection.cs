using System;
using System.Collections;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// SiteBlogConfigCollection 的摘要说明。
	/// </summary>
    [Serializable]
	public class SiteBlogConfigCollection : CollectionBase
	{
		public SiteBlogConfigCollection()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public SiteBlogConfigCollection(SiteBlogConfigCollection value)	
		{
			if(value != null)
			{
				this.AddRange(value);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> class containing the specified array of <see cref="SiteBlogConfig">SiteBlogConfig</see> Components.
		/// </summary>
		/// <param name="value">An array of <see cref="SiteBlogConfig">SiteBlogConfig</see> Components with which to initialize the collection. </param>
		public SiteBlogConfigCollection(SiteBlogConfig[] value)
		{
			if(value != null)
			{
				this.AddRange(value);
			}
		}
		
		/// <summary>
		/// Gets the <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> at the specified index in the collection.
		/// <para>
		/// In C#, this property is the indexer for the <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> class.
		/// </para>
		/// </summary>
		public SiteBlogConfig this[int index] 
		{
			get	{return ((SiteBlogConfig)(this.List[index]));}
		}
		
		public int Add(SiteBlogConfig value) 
		{
			if(value != null)
			{
				return this.List.Add(value);
			}
			return -1;
		}
		
		/// <summary>
		/// Copies the elements of the specified <see cref="SiteBlogConfig">SiteBlogConfig</see> array to the end of the collection.
		/// </summary>
		/// <param name="value">An array of type <see cref="SiteBlogConfig">SiteBlogConfig</see> containing the Components to add to the collection.</param>
		public void AddRange(SiteBlogConfig[] value) 
		{
			if(value != null)
			{
				for (int i = 0;	(i < value.Length); i = (i + 1)) 
				{
					this.Add(value[i]);
				}
			}
		}
		
		/// <summary>
		/// Adds the contents of another <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> to the end of the collection.
		/// </summary>
		/// <param name="value">A <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> containing the Components to add to the collection. </param>
		public void AddRange(SiteBlogConfigCollection value) 
		{
			if(value != null)
			{
				for (int i = 0;	(i < value.Count); i = (i +	1))	
				{
					this.Add((SiteBlogConfig)value.List[i]);
				}
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the collection contains the specified <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see>.
		/// </summary>
		/// <param name="value">The <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> to search for in the collection.</param>
		/// <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
		public bool Contains(SiteBlogConfig value) 
		{
			return this.List.Contains(value);
		}
		
		/// <summary>
		/// Copies the collection Components to a one-dimensional <see cref="T:System.Array">Array</see> instance beginning at the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array">Array</see> that is the destination of the values copied from the collection.</param>
		/// <param name="index">The index of the array at which to begin inserting.</param>
		public void CopyTo(SiteBlogConfig[] array, int index) 
		{
			this.List.CopyTo(array, index);
		}
		
		/// <summary>
		/// Gets the index in the collection of the specified <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see>, if it exists in the collection.
		/// </summary>
		/// <param name="value">The <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> to locate in the collection.</param>
		/// <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
		public int IndexOf(SiteBlogConfig value) 
		{
			return this.List.IndexOf(value);
		}
		
		public void Insert(int index, SiteBlogConfig value)	
		{
			List.Insert(index, value);
		}
		
		public void Remove(SiteBlogConfig value) 
		{
			List.Remove(value);
		}

		public void Sort()
		{
			this.InnerList.Sort(new SortListCategoryComparer());
		}

		private sealed class SortListCategoryComparer : IComparer 
		{
			public int Compare(object x, object y)
			{
				SiteBlogConfig first = (SiteBlogConfig) x;
				SiteBlogConfig second = (SiteBlogConfig) y;
				return first.BlogID.CompareTo(second.BlogID);
			}
		}

		
		/// <summary>
		/// Returns an enumerator that can iterate through the <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> instance.
		/// </summary>
		/// <returns>An <see cref="SiteBlogConfigCollectionEnumerator">SiteBlogConfigCollectionEnumerator</see> for the <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> instance.</returns>
		public new SiteBlogConfigCollectionEnumerator GetEnumerator()	
		{
			return new SiteBlogConfigCollectionEnumerator(this);
		}
		
		/// <summary>
		/// Supports a simple iteration over a <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see>.
		/// </summary>
		public class SiteBlogConfigCollectionEnumerator : IEnumerator	
		{
			private	IEnumerator _enumerator;
			private	IEnumerable _temp;
			
			/// <summary>
			/// Initializes a new instance of the <see cref="SiteBlogConfigCollectionEnumerator">SiteBlogConfigCollectionEnumerator</see> class referencing the specified <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> object.
			/// </summary>
			/// <param name="mappings">The <see cref="SiteBlogConfigCollection">SiteBlogConfigCollection</see> to enumerate.</param>
			public SiteBlogConfigCollectionEnumerator(SiteBlogConfigCollection mappings)
			{
				_temp =	((IEnumerable)(mappings));
				_enumerator = _temp.GetEnumerator();
			}
			
			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			public SiteBlogConfig Current
			{
				get {return ((SiteBlogConfig)(_enumerator.Current));}
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
