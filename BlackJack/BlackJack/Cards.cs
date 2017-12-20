using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
	public enum CardSuit{H = 1, C = 2, D = 3, S = 4};

	public class Cards
	{
		public string Face{get; set;}
		public int Value{get; set;}
		public int FaceID {get; set;}
		public CardSuit Suit{get; set;}

		public override bool Equals(object obj)
		{
			if(obj == null) return false;
			return obj.ToString() == this.ToString();
		}

		public override string ToString()
		{
			return string.Format("[Suit:{0}; FaceID:{1}]", (int)Suit, FaceID);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
