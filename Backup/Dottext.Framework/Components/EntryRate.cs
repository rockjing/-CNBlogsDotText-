using System;

namespace Dottext.Framework.Components
{
	/// <summary>
	/// EntryRate 的摘要说明。
	/// </summary>
	public class EntryRate
	{
		private const int RateLevel=9; 

		public EntryRate()
		{		
			_ratingList=new int[RateLevel]{0,0,0,0,0,0,0,0,0};
		}
		
		public EntryRate(int entryID)
		{		
			this._entryID=entryID;
			_ratingList=new int[RateLevel]{0,0,0,0,0,0,0,0,0};
		}

		private int _entryID;
		public int EntryID
		{
			get {return this._entryID;}
			set {this._entryID = value;}
		}

		private string _clientID;
		public string ClientID
		{
			get {return this._clientID;}
			set {this._clientID = value;}
		}

		private int _score;
		public int Score
		{
			get {return this._score;}
			set {this._score = value;}
		}
		
		private int[] _ratingList;
		public int[] RatingList
		{
			get 
			{
				return this._ratingList;
			}
			set
			{
				this._ratingList=value;
			}
		}

		private int _rateCount=0;
		public int RateCount
		{
			get 
			{
				this._rateCount=0;
				foreach(int count in this._ratingList)
				{
					this._rateCount+=count;
				}
				return this._rateCount;
			}
			
		}
		
		private int _averageRating=0;
		public int  AverageRating
		{
			get 
			{
				int total=0;
				for(int i=0;i<this.RatingList.Length;i++)
				{
					total+=(i+1)*this._ratingList[i];
				}
				this._averageRating=(int)System.Math.Round((double)(total/this.RateCount));
				return this._averageRating;
			}

		}

		private int _maxPeople=0;
		public int MaxPeople
		{
			get 
			{
				this._maxPeople=0;
				for(int i=0;i<this.RatingList.Length;i++)
				{
					this._maxPeople=System.Math.Max(this._maxPeople,this._ratingList[i]);
				}
				if(this._maxPeople==0)
				{
					this._maxPeople=1;
				}
				return this._maxPeople;
			}

		}




	}
}
