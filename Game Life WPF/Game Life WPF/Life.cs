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
	/// The class that makes the game itself
	/// </summary>
	class Life
    {
		/// <summary>
		/// array for new cell positions
		/// </summary>
		Rectangle[,] margins_life = null;
		/// <summary>
		/// array in which the cell neighbors are stored
		/// </summary>
		int[,] arrayStep = null;
		/// <summary>
		/// Constants for width and height
		/// </summary>
		const int x = MainWindow.x;
        const int y = MainWindow.y;

		/// <summary>
		/// property returning an array of new cells
		/// </summary>
		public Rectangle[,] Get_margins_life
        {
            get
            {
                return margins_life;
            }
        }

		/// <summary>
		/// default constructor
		/// </summary>
		public Life()
        {
            this.margins_life = new Rectangle[x, y];
            arrayStep = new int[x, y];
        }

		/// <summary>
		/// checks the field, to emulate the surface of the torus
		/// </summary>
		/// <param name="m"></param>
		/// <param name="ch"></param>
		public void Surface(Rectangle[,] m, bool ch)
        {
            this.margins_life = m;
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    int iTop = i - 1;
                    if (iTop < 0)
                    {
                        iTop = x - 1;
                    }

                    int iBelow = i + 1;
                    if (iBelow == x)
                    {
                        iBelow = 0;
                    }

                    int jLeft = j - 1;
                    if (jLeft < 0)
                    {
                        jLeft = y - 1;
                    }

                    int jRight = j + 1;
                    if (jRight == y)
                    {
                        jRight = 0;
                    }

                    this.arrayStep[i, j] = Count_Neighbors(i, j, iTop, iBelow, jLeft, jRight);

                }
            }
            if (ch == false)
                Ckeck_Step();
            else
                Make_Step();

        }


		/// <summary>
		/// Counts the number of neighbors
		/// </summary>
		/// <param name="i">the position of the cell in width</param>
		/// <param name="j">cell height position</param>
		/// <param name="iTop">the position of the cell from above</param>
		/// <param name="iBelow">bottom position of the cell</param>
		/// <param name="jLeft">the position of the cell on the left according to the widthе</param>
		/// <param name="jRight">the position of the cell from the right to the width</param>
		/// <returns></returns>
		private int Count_Neighbors(int i, int j, int iTop, int iBelow, int jLeft, int jRight)
        {

            int count = 0;
            if (margins_life[iTop, jLeft].Fill == Brushes.Green)
                count++;
            if (margins_life[iTop, j].Fill == Brushes.Green)
                count++;
            if (margins_life[iTop, jRight].Fill == Brushes.Green)
                count++;
            if (margins_life[i, jLeft].Fill == Brushes.Green)
                count++;
            if (margins_life[i, jRight].Fill == Brushes.Green)
                count++;
            if (margins_life[iBelow, jLeft].Fill == Brushes.Green)
                count++;
            if (margins_life[iBelow, j].Fill == Brushes.Green)
                count++;
            if (margins_life[iBelow, jRight].Fill == Brushes.Green)
                count++;
            return count;
        }

		/// <summary>
		/// draws the following stroke
		/// </summary>
		private void Make_Step()
        {
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (arrayStep[i, j] < 2 || arrayStep[i, j] > 3)
                    {
                        margins_life[i, j].Fill = Brushes.LightGray;
                    }
                    else if (arrayStep[i, j] == 3)
                    {
                        margins_life[i, j].Fill = Brushes.Green;
                    }
                }
            }
        }

		/// <summary>
		/// calculates the next move for comparison to life
		/// </summary>
		/// <returns></returns>
		public bool[,] Ckeck_Step()
        {
            bool[,] tmp = new bool[x, y];
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (arrayStep[i, j] < 2 || arrayStep[i, j] > 3)
                    {
                        tmp[i, j] = false;
                    }
                    else if (arrayStep[i, j] == 3)
                    {
                        tmp[i, j] = true;
                    }
                }
            }
            return tmp;
        }
    }
}
