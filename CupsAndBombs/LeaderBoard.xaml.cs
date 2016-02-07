using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml;
using Windows.Data.Xml.Dom;
using System.Xml.Linq;
using Windows.Storage;
using System.Xml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CupsAndBombs.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CupsAndBombs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeaderBoard : Page
    {
        XmlDocument dom = new XmlDocument();
        ObservableCollection<Player> playerTable;

        public LeaderBoard()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            XmlNodeList _names = null, _scores = null;
            bool fileExists = true;
            try
            {
                StorageFile st = await ApplicationData.Current.LocalFolder.GetFileAsync("score.xml");
                dom = await XmlDocument.LoadFromFileAsync(st);

                _names = dom.GetElementsByTagName("name");
                _scores = dom.GetElementsByTagName("highscore");
            }
            catch (Exception)
            {
                fileExists = false;
            }

            playerTable = new ObservableCollection<Player>();

            if (fileExists)
            {                
                for (int i = 0; i < _names.Count; i++)
                {
                    string name = _names.ElementAt(i).InnerText;
                    int score = Int32.Parse(_scores.ElementAt(i).InnerText);
                    playerTable.Add(new Player(name, score));
                }
            }

            playerTable = new ObservableCollection<Player>(playerTable.OrderByDescending(player => player.Score));
            playerTable = new ObservableCollection<Player>(playerTable.Take(10));

            foreach (var elem in playerTable)
            {
                LeaderBoardControl control = new LeaderBoardControl(elem.Name, elem.Score);
                leaderBoardList.Items.Add(control);
            }

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
