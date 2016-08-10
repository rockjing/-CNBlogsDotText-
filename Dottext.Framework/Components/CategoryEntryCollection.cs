#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections;
using System.Xml;
using Dottext.Framework.Components;


namespace Dottext.Framework.Components
{
	/// <summary>
	/// Represents a collection of <see cref="CategoryEntry">CategoryEntry</see> Components.
	/// </summary>
	[Serializable]
	public class CategoryEntryCollection: CollectionBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> class.
		/// </summary>
		public CategoryEntryCollection() 
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> class containing the specified array of <see cref="CategoryEntry">CategoryEntry</see> Components.
		/// </summary>
		/// <param name="value">An array of <see cref="CategoryEntry">CategoryEntry</see> Components with which to initialize the collection. </param>
		public CategoryEntryCollection(CategoryEntry[] value)
		{
			this.AddRange(value);
		}
		
		/// <summary>
		/// Gets the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> at the specified index in the collection.
		/// <para>
		/// In C#, this property is the indexer for the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> class.
		/// </para>
		/// </summary>
		public CategoryEntry this[int index] 
		{
			get	{return ((CategoryEntry)(this.List[index]));}
		}
		
		public int Add(CategoryEntry value) 
		{
			return this.List.Add(value);
		}
		
		/// <summary>
		/// Copies the elements of the specified <see cref="CategoryEntry">CategoryEntry</see> array to the end of the collection.
		/// </summary>
		/// <param name="value">An array of type <see cref="CategoryEntry">CategoryEntry</see> containing the Components to add to the collection.</param>
		public void AddRange(CategoryEntry[] value) 
		{
			for (int i = 0;	(i < value.Length); i = (i + 1)) 
			{
				this.Add(value[i]);
			}
		}
		
		/// <summary>
		/// Adds the contents of another <see cref="CategoryEntryCollection">CategoryEntryCollection</see> to the end of the collection.
		/// </summary>
		/// <param name="value">A <see cref="CategoryEntryCollection">CategoryEntryCollection</see> containing the Components to add to the collection. </param>
		public void AddRange(CategoryEntryCollection value) 
		{
			for (int i = 0;	(i < value.Count); i = (i +	1))	
			{
				this.Add((CategoryEntry)value.List[i]);
			}
		}
		
		/// <summary>
		/// Gets a value indicating whether the collection contains the specified <see cref="CategoryEntryCollection">CategoryEntryCollection</see>.
		/// </summary>
		/// <param name="value">The <see cref="CategoryEntryCollection">CategoryEntryCollection</see> to search for in the collection.</param>
		/// <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
		public bool Contains(CategoryEntry value) 
		{
			return this.List.Contains(value);
		}
		
		/// <summary>
		/// Copies the collection Components to a one-dimensional <see cref="T:System.Array">Array</see> instance beginning at the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array">Array</see> that is the destination of the values copied from the collection.</param>
		/// <param name="index">The index of the array at which to begin inserting.</param>
		public void CopyTo(CategoryEntry[] array, int index) 
		{
			this.List.CopyTo(array, index);
		}
		
		/// <summary>
		/// Gets the index in the collection of the specified <see cref="CategoryEntryCollection">CategoryEntryCollection</see>, if it exists in the collection.
		/// </summary>
		/// <param name="value">The <see cref="CategoryEntryCollection">CategoryEntryCollection</see> to locate in the collection.</param>
		/// <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
		public int IndexOf(CategoryEntry value) 
		{
			return this.List.IndexOf(value);
		}
		
		public void Insert(int index, CategoryEntry value)	
		{
			List.Insert(index, value);
		}
		
		public void Remove(CategoryEntry value) 
		{
			List.Remove(value);
		}
		
		/// <summary>
		/// Returns an enumerator that can iterate through the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> instance.
		/// </summary>
		/// <returns>An <see cref="BlogPostDayEnumerator">BlogPostDayEnumerator</see> for the <see cref="CategoryEntryCollection">CategoryEntryCollection</see> instance.</returns>
		public new BlogPostDayEnumerator GetEnumerator()	
		{
			return new BlogPostDayEnumerator(this);
		}
		
		/// <summary>
		/// Supports a simple iteration over a <see cref="CategoryEntryCollection">CategoryEntryCollection</see>.
		/// </summary>
		public class BlogPostDayEnumerator : IEnumerator	
		{
			private	IEnumerator _enumerator;
			private	IEnumerable _temp;
			
			/// <summary>
			/// Initializes a new instance of the <see cref="BlogPostDayEnumerator">BlogPostDayEnumerator</see> class referencing the specified <see cref="CategoryEntryCollection">CategoryEntryCollection</see> object.
			/// </summary>
			/// <param name="mappings">The <see cref="CategoryEntryCollection">CategoryEntryCollection</see> to enumerate.</param>
			public BlogPostDayEnumerator(CategoryEntryCollection mappings)
			{
				_temp =	((IEnumerable)(mappings));
				_enumerator = _temp.GetEnumerator();
			}
			
			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			public CategoryEntry Current
			{
				get {return ((CategoryEntry)(_enumerator.Current));}
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

