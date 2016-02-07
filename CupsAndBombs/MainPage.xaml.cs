using CupsAndBombs.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CupsAndBombs
{
    public sealed partial class MainPage : Page
    {
        TextGenerator tg = new TextGenerator();

        public MainPage()
        {
            this.InitializeComponent();
            txtBlock.Text = tg.GetRandomQuote();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            var p = new Parameters();
            p.Level = 1;
            p.Name = playerNameTxt.Text;
            p.Score = 0;
            p.Counter = 5;
            Frame.Navigate(typeof(Level), p);
        }

        private void leadeboard_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LeaderBoard));
        }

        private void howToPlay_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HowToPlay));
        }
    }
}
