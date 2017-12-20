using DevExpress.Xpf.Editors;
using DevExpress.Xpf.LayoutControl;
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
		static List<Cards> deck, PlayerHand, DealerHand;
		static int totalPlayed, wins, deckIndex, playerShown, dealerShown;

		public MainWindow()
		{
			InitializeComponent();
			txtTotal.Text = string.Format("{0}", totalPlayed);
		}

		private void btnNewGame_Click(object sender, RoutedEventArgs e)
		{
			StartGame();
			totalPlayed++;
		}

		private void StartGame()
		{
			PlayerHand = new List<Cards>();
			DealerHand = new List<Cards>();
			deck = new List<Cards>();
			deckIndex = 0;
			ShuffleCards();
			DealHands();
		}

		private void btnHit_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnStand_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnAceValue_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DealHands()
		{
			PlayerHand.Add(DealCard());
			DisplayCard(playersCards, PlayerHand.Last());

			DealerHand.Add(DealCard());
			DisplayCard(dealersCards, DealerHand.Last());


			PlayerHand.Add(DealCard());
			DisplayCard(playersCards, PlayerHand.Last());

			DealerHand.Add(DealCard());
			DisplayCard(dealersCards);
		}

		private void ShuffleCards()
		{
			Random rnd = new Random();
			deck.Add(GenCard(rnd));

			while(deck.Count() < 52)
			{
				var gc = GenCard(rnd);

				if(deck.Where(c => c.Equals(gc)).Any()) continue;
				
				deck.Add(gc);
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

		private static Cards DealCard()
		{
			var crd = deck[deckIndex];
			deckIndex++;
			return crd;
		}

		private void DisplayCard(FlowLayoutControl pField, Cards card = null)
		{
			if(card == null) pField.Children.Add(new TextEdit(){Name = "FaceDown" });
			else pField.Children.Add(new TextEdit() {Text = string.Format("{0}{1}", card.Face, card.Suit)});
		}

		private static void DealCheck()
		{
			int dealerTemp = 0, playerTemp = 0;
			DealerHand.ForEach(c => dealerTemp += c.Value);
			PlayerHand.ForEach(c => playerTemp += c.Value);

			if(dealerTemp == 21)
			if(dealerTemp == playerTemp){ }
			else{ }
		}

		private static void DealerCardCeck()
		{
			
		}

		private static void PlayerCardCheck()
		{
			if(PlayerHand.Last().Value == 11){ }

			PlayerHand.ForEach(ph => playerShown += ph.Value);


		}

	}
}
