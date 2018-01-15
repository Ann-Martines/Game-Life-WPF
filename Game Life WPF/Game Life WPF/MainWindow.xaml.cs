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

namespace Game_Life_WPF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Constant for the width
		/// </summary>
		public const int x = 30;
		/// <summary>
		/// Constant for the height
		/// </summary>
		public const int y = 30;

		/// <summary>
		/// Two-dimensional array of rectangles for drawing a field
		/// </summary>
		Rectangle[,] margins = null;
		/// <summary>
		/// Timer
		/// </summary>
		DispatcherTimer timer = null;
		/// <summary>
		/// The window initialization constructor
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// When the window is loaded, creates a field for the game and randomly fills it up.
		/// </summary>
		/// <param name="sender">объект</param>
		/// <param name="e">собитие</param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			margins = new Rectangle[x, y];
			Filling fill = new Filling();
			for (var i = 0; i < x; i++)
			{
				for (var j = 0; j < y; j++)
				{
					Rectangle r = new Rectangle();
					r.Width = polegame.ActualWidth / x - 1;
					r.Height = polegame.ActualHeight / y - 1;
					r.Fill = fill.Fill_Array(i, j, r);
					polegame.Children.Add(r);
					Canvas.SetLeft(r, j * polegame.ActualWidth / x);
					Canvas.SetTop(r, i * polegame.ActualHeight / y);
					r.MouseDown += R_MouseDown;
					margins[i, j] = r;

				}
			}
		}

		/// <summary>
		/// Event when you click on the mouse in the field of the playing field
		/// </summary>
		/// <param name="sender">объект</param>
		/// <param name="e">собитие</param>
		private void R_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				((Rectangle)sender).Fill = (((Rectangle)sender).Fill == Brushes.LightGray) ? Brushes.Green : Brushes.LightGray;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// When you click on the Start button, the timer starts and the game starts
		/// </summary>
		/// <param name="sender">объект</param>
		/// <param name="e">собитие</param>
		private void btnStart_Click(object sender, RoutedEventArgs e)
		{
			timer = new DispatcherTimer();
			timer.Tick += Timer_Tick;
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Start();
		}
		/// <summary>
		/// When you click the Restart button, the game starts anew
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRestart_Click(object sender, RoutedEventArgs e)
		{
            Window_Loaded(sender, e);
		}

		/// <summary>
		/// By the timer, the next move is executed, if there are no more moves, the timer stops
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
            CheckingLife check = new CheckingLife();           
            bool ch = check.Presence_On_Life(margins);

            if (ch == true)
            {
                timer.Stop();
               var mess =  MessageBox.Show("It all ended / Everything was hanging", "Finish", MessageBoxButton.OK);
                if(mess == MessageBoxResult.OK)
                {
                    for (var i = 0; i < x; i++)
                    {
                        for (var j = 0; j < y; j++)
                        {
                            margins[i, j].Fill = Brushes.LightGray;
                        }
                    }
                }
            }
            else
            {
                Life l = new Life();
                l.Surface(margins, true);
               // var c = l.Get_margins_life;
            }
        }
	}
}
