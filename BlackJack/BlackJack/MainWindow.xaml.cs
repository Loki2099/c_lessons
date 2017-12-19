using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Cards> cards;
		public MainWindow()
		{
			InitializeComponent();
			StartGame();
		}

		private void StartGame()
		{
			cards = new List<Cards>();
			ShuffleCards();
		}

		private void ShuffleCards()
		{
			Random rnd = new Random();
			while(cards.Count() < 52)
			{
				var gc = GenCard(rnd);

				if(cards.Where(c => c.Equals(gc)).Any()) continue;
				
				cards.Add(gc);
			}
		}

		private Cards GenCard(Random rnd)
		{
			var fid = rnd.Next(1, 14);
			var suit = (CardSuit)rnd.Next(1, 5);
			var crd = new Cards(){Suit = suit, FaceID = fid};
			if(fid > 1 && fid < 11) {crd.Face = fid.ToString(); crd.Value = fid;}
			else 
			{
				switch (fid)
				{
					case 1:
						crd.Face = "A";
						crd.Value = 11;
						break;
					case 11:
						crd.Face = "J";
						goto case 21;
					case 12:
						crd.Face = "Q";
						goto case 21;
					case 13:
						crd.Face = "K";
						goto case 21;
					case 21:
						crd.Value = 10;
						break;
					default:
						break;
				}
			}
			return crd;
		}
	}
}
