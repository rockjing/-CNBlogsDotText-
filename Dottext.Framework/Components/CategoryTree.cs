using System;
using System.Data;
using System.Data.SqlClient;
using Dottext.Framework.Data;
using System.Collections;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// 
	/// </summary>
	public class CategoryTree:BuildTree
	{
		protected AbstractComponent rootnode;
		protected CategoryType _cateType=CategoryType.Global;
		protected bool _CateIsActiveOnly=true;
				
		public CategoryTree(int rootID)
		{
			
			LinkCategory lc=new LinkCategory();
			lc.CategoryID=rootID;
			lc.Title=Framework.Util.Globals.GetWebConfig("AggregateTitle","CNDottext");
			rootnode=new Composite(null,lc);
			
		}

		public CategoryTree(int rootID,CategoryType cateType,bool ActiveOnly):this(rootID)
		{
			_cateType=cateType;
			_CateIsActiveOnly=ActiveOnly;
		}

		public AbstractComponent Build()
		{
			CreateNode(rootnode);
			return rootnode;
		}

		
		private void CreateNode(AbstractComponent node)
		{
			LinkCategory lc=(LinkCategory)node.GetObject();
			LinkCategoryCollection lcc=Links.GetCategoriesByParentID(_cateType,lc.CategoryID,_CateIsActiveOnly);
			for(int i=0;i<lcc.Count;i++)
			{
				AbstractComponent childNode=new Composite(node,lcc[i]); 
				node.Add(childNode);
				CreateNode(childNode);
			}
		}
		
		public void Persistent()
		{
			string delsql="delete from blog_LinkCategories where CategoryType="+(int)CategoryType.Global;
			SqlConnection  conn=new SqlConnection(Dottext.Framework.Configuration.Config.Settings.BlogProviders.DbProvider.ConnectionString);
			conn.Open();
			SqlTransaction trans=conn.BeginTransaction();
			
			SqlHelper.ExecuteNonQuery(trans,CommandType.Text,delsql);
			Persistent(this.rootnode,trans);
			trans.Commit();
		}
		
		private void Persistent(AbstractComponent node,SqlTransaction transaction)
		{
			if(!node.isRoot())
			{
				LinkCategory lc=(LinkCategory)node.GetObject();
				SqlParameter[] p =
			{

				SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,150,lc.Title),
				SqlHelper.MakeInParam("@Active",SqlDbType.Bit,1,lc.IsActive),
				SqlHelper.MakeInParam("@CategoryType",SqlDbType.TinyInt,1,lc.CategoryType),
				SqlHelper.MakeInParam("@Description",SqlDbType.NVarChar,1000,DataHelper.CheckNull(lc.Description)),
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,-1),
				SqlHelper.MakeInParam("@ParentID",SqlDbType.Int,4,lc.ParentID),
				SqlHelper.MakeOutParam("@CategoryID",SqlDbType.Int,4)
			};
				SqlHelper.ExecuteNonQuery(transaction,"blog_InsertCategory",p);
			}
			while(node.GoNextChild())
			{
				Persistent(node.GetChild(),transaction);
			}
		}

		private void Traversal(AbstractComponent node)//深度优先前序遍历
		{
			
			Stack  stk = new Stack(); 
			AbstractComponent ctlCurrent = node; // 当前访问的控件 
			AbstractComponent ctlParent = null;  // 父控件 
			int index = 0; // 当前控件是父控件的第i个子控件 

			do 
			{ 
				System.Web.HttpContext.Current.Response.Write("hello<br>");
				if(node.GetParent()!=null)
				{
					LinkCategory lc=(LinkCategory)node.GetObject();
					Links.CreateLinkCategory(lc);
					
				}
				
				if(ctlCurrent.GoNextChild()) // 访问完当前控件，优先访问子控件 
				{ 
					stk.Push(index); 
					index = 0; 
					ctlParent = ctlCurrent;  
					ctlCurrent = ctlCurrent.GetChild();
				} 
				else if(ctlParent != null && ctlCurrent.GoNextChild())  // 存在下一个兄弟控件 
				{ 
					ctlCurrent = ctlParent.GetChild(); 
				} 
				else  // 没有子控件和下一个兄弟控件 
				{ 
					while(true) 
					{ 
						if(ctlParent == null || ctlParent.Equals(node)) 
						{ 
							ctlCurrent = node; 
							break; 
						} 

						ctlCurrent = ctlParent; 
						ctlParent = (AbstractComponent)ctlCurrent.GetParent(); 
						index = (int)stk.Pop(); 

						if(ctlParent != null && ctlParent.GoNextChild()) 
						{ 
							ctlCurrent = ctlParent.GetChild(); 
							break; 
						} 
					} 
				} 
			}while(!ctlCurrent.Equals(node)); 

		}



		
		
	}
}
