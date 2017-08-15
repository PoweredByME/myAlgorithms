using System;

namespace Algorithms
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			N_Queens q = new N_Queens (9);
			q.Solve ();
		}
	}
}
