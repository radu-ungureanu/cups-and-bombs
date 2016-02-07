using CupsAndBombs.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CupsAndBombs
{
    public sealed partial class Level : Page
    {
        private int counter, futureCounter, nextStateRandom;
        Random r = new Random();
        int[] positions = { 1, 2, 3 };
        Type[] moves;
        int movesNumber = 0;
        int levelCount;
        string playerName;
        int score;
        XmlDocument dom = new XmlDocument();
        XmlElement x;

        public enum Type { ONETWO = 12, TWOTHREE = 23, THREEONE = 31 }

        public Level()
        {
            this.InitializeComponent();

            nextButton.Visibility = Visibility.Collapsed;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;

            prima.Completed += prima_Completed;
            onewithtwo.Storyboard.Completed += onewithtwo_Completed;
            threewithone.Storyboard.Completed += threewithone_Completed;
            twowiththree.Storyboard.Completed += twowiththree_Completed;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as Parameters;
            this.levelCount = param.Level;
            this.playerName = param.Name;
            this.score = param.Score;
            this.counter = param.Counter;
            this.futureCounter = counter + 2;
            Title.Text = "Level " + levelCount;
            playerTextblock.Text = this.playerName;
            scoreTextblock.Text = "Score: " + this.score;
            moves =  new Type[2 * this.levelCount + 10];
            prima.Begin();
        }

        private void twowiththree_Completed(object sender, object e)
        {
            counter--;
            nextStateRandom = r.Next(1, 4);
            if (counter >= 0)
                switch (nextStateRandom)
                {
                    case 1:
                        moves[movesNumber++] = Type.ONETWO;
                        VisualStateManager.GoToState(this, "onewithtwo", false);
                        break;
                    case 2:
                        moves[movesNumber++] = Type.THREEONE;
                        VisualStateManager.GoToState(this, "threewithone", false);
                        break;
                    case 3:
                        moves[movesNumber++] = Type.THREEONE;
                        VisualStateManager.GoToState(this, "threewithone", false);
                        break;
                }
            if (counter < 0)
            {
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
            }
        }

        private void threewithone_Completed(object sender, object e)
        {
            counter--;
            nextStateRandom = r.Next(1, 4);
            if (counter >= 0)
                switch (nextStateRandom)
                {
                    case 1:
                        moves[movesNumber++] = Type.ONETWO;
                        VisualStateManager.GoToState(this, "onewithtwo", false);
                        break;
                    case 2:
                        moves[movesNumber++] = Type.TWOTHREE;
                        VisualStateManager.GoToState(this, "twowiththree", false);
                        break;
                    case 3:
                        moves[movesNumber++] = Type.ONETWO;
                        VisualStateManager.GoToState(this, "onewithtwo", false);
                        break;
                }
            if (counter < 0)
            {
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;

            }
        }

        private void onewithtwo_Completed(object sender, object e)
        {
            counter--;
            nextStateRandom = r.Next(1, 4);
            if (counter >= 0)
                switch (nextStateRandom)
                {
                    case 1:
                        moves[movesNumber++] = Type.THREEONE;
                        VisualStateManager.GoToState(this, "threewithone", false);
                        break;
                    case 2:
                        moves[movesNumber++] = Type.TWOTHREE;
                        VisualStateManager.GoToState(this, "twowiththree", false);
                        break;
                    case 3:
                        moves[movesNumber++] = Type.THREEONE;
                        VisualStateManager.GoToState(this, "threewithone", false);
                        break;
                }
            if (counter < 0)
            {
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
            }
        }
        
        public void rememberBall()
        {
            for (int i = 0; i < movesNumber; i++)
            {
                switch (moves[i])
                {
                    case Type.ONETWO:
                        if (positions[0] == 1)
                        {
                            positions[0] = positions[1];
                            positions[1] = 1;
                        }
                        else
                            if (positions[1] == 1)
                            {
                                positions[1] = positions[0];
                                positions[0] = 1;
                            }
                        break;
                    case Type.TWOTHREE:
                        if (positions[1] == 1)
                        {
                            positions[1] = positions[2];
                            positions[2] = 1;
                        }
                        else
                            if (positions[2] == 1)
                            {
                                positions[2] = positions[1];
                                positions[1] = 1;
                            }
                        break;
                    case Type.THREEONE:
                        if (positions[0] == 1)
                        {
                            positions[0] = positions[2];
                            positions[2] = 1;
                        }
                        else
                            if (positions[2] == 1)
                            {
                                positions[2] = positions[0];
                                positions[0] = 1;
                            }
                        break;
                }
            }
        }

        private void prima_Completed(object sender, object e)
        {
            moves[movesNumber++] = Type.ONETWO;
            VisualStateManager.GoToState(this, "onewithtwo", false);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rememberBall();
            if (positions[0] == 1)
            {
                positiononewin.Storyboard.Completed += searchBallWin;
                positiononewin.Storyboard.Begin();
            }
            else
            {
                positiononelost.Storyboard.Completed += searchBallLose;
                positiononelost.Storyboard.Begin();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            rememberBall();
            if (positions[1] == 1)
            {
                positiontwowin.Storyboard.Completed += searchBallWin;
                positiontwowin.Storyboard.Begin();
            }
            else
            {
                positiontwolost.Storyboard.Completed += searchBallLose;
                positiontwolost.Storyboard.Begin();
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            rememberBall();
            if (positions[2] == 1)
            {
                positionthreewin.Storyboard.Completed += searchBallWin;
                positionthreewin.Storyboard.Begin();
            }
            else
            {
                positionthreelost.Storyboard.Completed += searchBallLose;
                positionthreelost.Storyboard.Begin();
            }

        }

        void searchBallWin(object sender, object e)
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            nextButton.Visibility = Visibility.Visible;
        }

        void searchBallLose(object sender, object e)
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            nextButton.Content = "Exit";
            nextButton.Visibility = Visibility.Visible;
            media.Play();
            explosion.Storyboard.Begin();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void nextButton_Click_1(object sender, RoutedEventArgs e)
        {
            if ("Exit".Equals(nextButton.Content.ToString()))
            {
                StorageFile st = null;
                bool exists = true;
                XmlNodeList _names = null, _scores = null;
                try
                {
                    st = await ApplicationData.Current.LocalFolder.GetFileAsync("score.xml");
                    dom = await XmlDocument.LoadFromFileAsync(st);
                    _names = dom.GetElementsByTagName("name");
                    _scores = dom.GetElementsByTagName("highscore");
                }
                catch (Exception)
                {
                    exists = false;
                }

                if (!exists)
                {
                    st = await ApplicationData.Current.LocalFolder.CreateFileAsync("score.xml");
                }

                ObservableCollection<Player> playerTable = new ObservableCollection<Player>();
                if (_names != null)
                {
                    for (int i = 0; i < _names.Count; i++)
                    {
                        string tempName = _names.ElementAt(i).InnerText;
                        int tempScore = Int32.Parse(_scores.ElementAt(i).InnerText);
                        playerTable.Add(new Player(tempName, tempScore));
                    }
                }

                playerTable.Add(new Player(playerName, score));

                dom = new XmlDocument();
                x = dom.CreateElement("users");
                dom.AppendChild(x);
                foreach (var elem in playerTable)
                {
                    XmlElement x1 = dom.CreateElement("user");
                    XmlElement x11 = dom.CreateElement("name");
                    x11.InnerText = elem.Name;
                    x1.AppendChild(x11);
                    XmlElement x12 = dom.CreateElement("highscore");
                    x12.InnerText = elem.Score.ToString();
                    x1.AppendChild(x12);
                    x.AppendChild(x1);
                }

                await dom.SaveToFileAsync(st);

                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var param = new Parameters();
                param.Score = this.score + 10 + this.levelCount;
                param.Name = this.playerName;
                param.Level = this.levelCount + 1;
                param.Counter = this.futureCounter;
                Frame.Navigate(typeof(Level), param);
            }
        }
    }
}
