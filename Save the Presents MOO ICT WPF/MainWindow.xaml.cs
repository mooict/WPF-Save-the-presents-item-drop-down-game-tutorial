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

using System.Windows.Threading;

namespace Save_the_Presents_MOO_ICT_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int maxItems = 5;
        int currentItems = 0;

        Random rand = new Random();

        int score = 0;
        int missed = 0;

        Rect playerHitBox;

        DispatcherTimer gameTimer = new DispatcherTimer();

        List<Rectangle> itemstoRemove = new List<Rectangle>();

        ImageBrush playerImage = new ImageBrush();
        ImageBrush backgroundImage = new ImageBrush();

        int itemSpeed = 10;

        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus();

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/netLeft.png"));
            player1.Fill = playerImage;

            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.jpg"));
            MyCanvas.Background = backgroundImage;
        }

        private void GameEngine(object sender, EventArgs e)
        {
            scoreText.Content = "Caught: " + score;
            missedText.Content = "Missed " + missed;


            if (currentItems < maxItems)
            {
                MakePresents();
                currentItems++;
                itemstoRemove.Clear();
            }


            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "drops")
                {

                    Canvas.SetTop(x, Canvas.GetTop(x) + itemSpeed);

                    if (Canvas.GetTop(x) > 720)
                    {
                        itemstoRemove.Add(x);
                        currentItems--;
                        missed++;
                    }

                    Rect presentsHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    playerHitBox = new Rect(Canvas.GetLeft(player1), Canvas.GetTop(player1), player1.Width, player1.Height);

                    if (playerHitBox.IntersectsWith(presentsHitBox))
                    {
                        itemstoRemove.Add(x);
                        currentItems--;
                        score++;
                    }




                }
            }


            foreach (var i in itemstoRemove)
            {
                MyCanvas.Children.Remove(i);
            }

            if (score > 10)
            {
                itemSpeed = 20;
            }

            if (missed > 6)
            {
                gameTimer.Stop();
                MessageBox.Show("You Lost!" + Environment.NewLine + "You Scored: " + score + Environment.NewLine + "Click ok to play again", "Save the presents game MOO ICT");
                ResetGame();
            }


        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

            Point position = e.GetPosition(this);

            double pX = position.X;

            Canvas.SetLeft(player1, pX - 10);

            if (Canvas.GetLeft(player1) < 260)
            {
                playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/netLeft.png"));
            }
            else
            {
                playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/netRight.png"));
            }

        }

        private void ResetGame()
        {

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            Environment.Exit(0);


        }

        private void MakePresents()
        {

            ImageBrush presents = new ImageBrush();

            int i = rand.Next(1, 6);

            switch (i)
            {
                case 1:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_01.png"));
                    break;
                case 2:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_02.png"));
                    break;
                case 3:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_03.png"));
                    break;
                case 4:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_04.png"));
                    break;
                case 5:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_05.png"));
                    break;
                case 6:
                    presents.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/present_06.png"));
                    break;

            }

            Rectangle newRec = new Rectangle
            {
                Tag = "drops",
                Width = 50,
                Height = 50,
                Fill = presents
            };

            Canvas.SetLeft(newRec, rand.Next(10, 450));
            Canvas.SetTop(newRec, rand.Next(60, 150) * -1);

            MyCanvas.Children.Add(newRec);

        }
    }
}
