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
		}

		private void StartGame()
		{
			cards = new List<Cards>();
			ShuffleCards();
		}

		private void ShuffleCards()
		{
			Random rnd = new Random();
			while(cards.Count() <= 52)
			{

			}
		}

		private Cards GenCard(Random rnd)
		{
			var fid = rnd.Next(1, 14);
			var suit = (CardSuit)rnd.Next(1, 5);

			if(fid > 1 && fid < 11) { }
			else { }

		}
	}
}
