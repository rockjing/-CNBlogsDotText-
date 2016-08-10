using System;
using System.Collections;
namespace Dottext.Framework.Components
{
	/// <summary>
	///存储树形数据的类 
	/// </summary>
	public interface AbstractComponent
	{
		object GetObject();
		object GetParent();
		bool isLeaf();
		bool isRoot();
		void Add(AbstractComponent c);
	    AbstractComponent GetChild();
		bool GoNextChild();
		
	}

	/// <summary>
	/// 
	/// </summary>
	public class Leaf: AbstractComponent
	{
		protected ArrayList ChildComponentsList;
		protected object _component;		
		protected object _parent;

		public Leaf(object parent,object component)
		{
			ChildComponentsList =new ArrayList();
			_parent=parent;
			_component=component;
		}
		public virtual void Add(AbstractComponent c)
		{
			throw new Exception("已达叶节点");
		}
		public object GetObject()
		{
			return _component;
		}
		
		public bool isLeaf()
		{
			return ChildComponentsList.Count==0;
		}
		
		public bool isRoot()
		{
			return _parent==null;
		}

		public virtual AbstractComponent GetChild()
		{
			return null;
		}
		public virtual bool GoNextChild()
		{
			return false;
		}

		public virtual object GetParent()
		{
			return _parent;
		}
	}
	
	

	/// <summary>
	/// 
	/// </summary>
	public class Composite:Leaf
	{
		private int count;

		public Composite(object parent,object component):base(parent,component)
		{
			count=0;
		}

		public override void Add(AbstractComponent c)
		{
			ChildComponentsList.Add(c);
		}
		public override AbstractComponent GetChild()
		{
			if(count<ChildComponentsList.Count)
			{
				return (AbstractComponent)ChildComponentsList[count++];
			}
			return null;
		}
		public override bool GoNextChild()
		{
			if(count==ChildComponentsList.Count||ChildComponentsList.Count==0)
			{
				return false;
			}
			return true;

		}
	}

}
	

