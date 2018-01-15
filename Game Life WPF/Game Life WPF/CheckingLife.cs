using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Game_Life_WPF
{
	/// <summary>
	/// A class that will test whether there are more moves or not
	/// </summary>
	class CheckingLife
	{
		/// <summary>
		/// array of source position
		/// </summary>
		bool[,] checkOldLife = null;
		/// <summary>
		/// array of next move positions
		/// </summary>
		bool[,] checkNewLife = null;
		bool check = false;
		/// <summary>
		/// default constructor
		/// </summary>
		public CheckingLife()
		{
			checkOldLife = new bool[MainWindow.x, MainWindow.y];
			checkNewLife = new bool[MainWindow.x, MainWindow.y];
		}

		/// <summary>
		///compares if the original life is the same as the position of the next move then the game is over
		/// </summary>
		/// <param name="m">source array</param>
		/// <returns></returns>
		public bool Presence_On_Life(Rectangle[,] m)
		{
			checkOldLife = Get_array_life(m);

            Life l = new Life();

			l.Surface(m,false);
            checkNewLife = l.Ckeck_Step();

			Get_Live_Count();
			if (check)
				return true;

			for (var i = 0; i < MainWindow.x; i++)
			{
				for (var j = 0; j < MainWindow.y; j++)
				{
                    if(checkOldLife[i,j] != checkNewLife[i,j])
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// return the number of living cells.
		/// </summary>
		private void Get_Live_Count()
		{
			int count = 0;
			for (var i = 0; i < MainWindow.x; i++)
			{
				for (var j = 0; j < MainWindow.y; j++)
				{
					if (checkOldLife[i, j] == false)
						count++;
				}
			}
			if (count == 0)
				check = true;
			else
				check = false;
		}

		/// <summary>
		/// Returns an array of type bool for comparison
		/// </summary>
		/// <param name="m">source array</param>
		/// <returns></returns>
		private bool[,] Get_array_life(Rectangle[,] m)
        {
            bool[,] array = new bool[MainWindow.x, MainWindow.y];
            for (var i = 0; i < MainWindow.x; i++)
            {
                for (var j = 0; j < MainWindow.y; j++)
                {
                    if (m[i, j].Fill == Brushes.Green)
                        array[i, j] = true;
                    else
                        array[i, j] = false;
                }
            }
            return array;
        }
    }
}
