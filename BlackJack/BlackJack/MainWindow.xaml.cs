﻿using DevExpress.Xpf.Editors;
using DevExpress.Xpf.LayoutControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
		static bool gameOver;
		static List<Cards> deck, PlayerHand, DealerHand;
		static int totalPlayed, wins, deckIndex, playerShown, dealerShown;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnNewGame_Click(object sender, RoutedEventArgs e)
		{
			playersCards.Children.Clear();
			dealersCards.Children.Clear();
			StartGame();
			totalPlayed++;
			txtTotal.Text = string.Format("{0}", totalPlayed);
			txtWon.Text = string.Format("{0}", wins);
		}

		private void StartGame()
		{
			gameOver = false;
			PlayerHand = new List<Cards>();
			DealerHand = new List<Cards>();
			deck = new List<Cards>();
			deckIndex = 0;
			ShuffleCards();
			DealHands();
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
			dealersCards.Children.Add(new TextEdit() {Name = "FaceDown" });
			DealCheck();

			if(!gameOver){btnHit.IsEnabled = true; btnStand.IsEnabled = true; }
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

		private void DisplayCard(FlowLayoutControl pField, Cards card)
		{
			pField.Children.Add(new TextEdit() {Text = string.Format("{0}{1}", card.Face, card.Suit)});
		}

		private void DealCheck()
		{
			int dealerTemp = 0, playerTemp = 0;
			DealerHand.ForEach(c => dealerTemp += c.Value);
			PlayerHand.ForEach(c => playerTemp += c.Value);

			if(dealerTemp == 21)
			{
				ShowFaceDown();
				dealerShown = dealerTemp;;
				playerShown = playerTemp;
				UpdateDealerShown();
				UpdatePlayerShown();
				
				if(dealerTemp == playerTemp){MessageBox.Show("Push");}
				else {MessageBox.Show("Dealer Wins");}

				gameOver = true;
			}
			else
			{
				dealerShown = DealerHand[0].Value;
				playerShown = playerTemp;

				UpdatePlayerShown();
				UpdateDealerShown();
				if(playerShown == 21) {MessageBox.Show("Blackjack"); wins++; gameOver = true;}
			}
		}

		private void ShowFaceDown()
		{
			var c = DealerHand.Last();
			(dealersCards.GetChildren(true).Find(cds => cds.Name.Equals("FaceDown")) as TextEdit).Text = string.Format("{0}{1}", c.Face, c.Suit);
			dealerShown += c.Value;
			UpdateDealerShown();
		}

		private void btnHit_Click(object sender, RoutedEventArgs e)
		{
			var crd = DealCard();
			PlayerHand.Add(crd);
			DisplayCard(playersCards, crd);
			playerShown += crd.Value;
			UpdatePlayerShown();

			if(playerShown < 21) return;
			else if(playerShown == 21)
			{
				btnHit.IsEnabled = false;
				btnStand_Click(sender, e);
				return;
			}
			else
			{
				if (PlayerHand.Where(pc => pc.Value == 11).Any())
				{
					PlayerHand.Where(pc => pc.Value == 11).First().Value = 1;
					playerShown -= 10;
					UpdatePlayerShown();
				}
				else
				{
					MessageBox.Show("Bust");
					btnHit.IsEnabled = false;
					btnStand.IsEnabled = false;
				}
			}
		}

		private void btnStand_Click(object sender, RoutedEventArgs e)
		{
			ShowFaceDown();

			if(dealerShown == 17 && DealerHand.Count() == 2)
			{
				var c = DealCard();
				DealerHand.Add(c);
				DisplayCard(dealersCards, c);
				dealerShown += c.Value;
				if(dealerShown > 21)
				{
					DealerHand.Where(dc => dc.Value == 11).First().Value = 1;
					dealerShown -= 10;
					UpdateDealerShown();
					//Thread.Sleep(2000);
				}
			}


			while (dealerShown < 17)
			{
				var c = DealCard();
				DealerHand.Add(c);
				DisplayCard(dealersCards, c);
				dealerShown += c.Value;
				UpdateDealerShown();
				//Thread.Sleep(2000);
			}

			if(dealerShown > 21){MessageBox.Show("Dealer Bust"); wins++; gameOver = true; return;}

			if (dealerShown <= 21 && playerShown < dealerShown){ MessageBox.Show("Dealer Wins"); gameOver = true; return;}
			if(dealerShown == playerShown){ MessageBox.Show("Push"); gameOver = true; return;}
			if(playerShown <= 21 && playerShown > dealerShown) { MessageBox.Show("Player Wins"); wins++; gameOver = true; return;}
		}

		private void UpdatePlayerShown()
		{
			txtPlayerHand.Text = string.Format("{0}", playerShown);
		}

		private void UpdateDealerShown()
		{
			txtDealerHand.Text = string.Format("{0}", dealerShown);
		}
	}
}
