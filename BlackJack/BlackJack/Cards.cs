﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
	public enum CardSuit{H, C, D, S};

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
			return string.Format("[Suit:{0}; Value:{1}]", (int)Suit, Value);
		}
	}
}
