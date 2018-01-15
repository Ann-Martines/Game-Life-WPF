using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_Life_WPF
{
	/// <summary>
	/// The class that fills the field
	/// </summary>
	class Filling
	{
		/// <summary>
		/// array for filling
		/// </summary>
		bool[,] ArrayForFill = null;
		/// <summary>
		/// Random
		/// </summary>
		Random rand = null;

		/// <summary>
		/// default constructor
		/// </summary>
		public Filling()
		{
			ArrayForFill = new bool[MainWindow.x, MainWindow.y];
			rand = new Random();
		}

		/// <summary>
		/// Randomly fill an array
		/// </summary>
		/// <param name="i">position i</param>
		/// <param name="j">position j</param>
		/// <param name="r">square</param>
		/// <returns></returns>
		public Brush Fill_Array(int i, int j, Rectangle r)
		{

			ArrayForFill[i, j] = Rand();
			Fill_Form(i, j, r);
			return r.Fill;
		}

		/// <summary>
		/// Paint specific squares depending on whether he is alive or dead
		/// </summary>
		/// <param name="i">position i</param>
		/// <param name="j">position j</param>
		/// <param name="r">square</param>
		/// <returns></returns>
		public Brush Fill_Form(int i, int j, Rectangle r)
		{
			if (ArrayForFill[i, j] == true)
				return r.Fill = Brushes.Green;

			else
				return r.Fill = Brushes.LightGray;
		}

		/// <summary>
		/// random filling
		/// </summary>
		/// <returns></returns>
		private bool Rand()
		{

			int b = rand.Next(0, 2);
			if (b == 1)
				return true;
			return false;
		}
	}
}
