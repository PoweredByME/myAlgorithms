using System;
using System.Collections.Generic;
namespace Algorithms
{
	public static class Utils<T>
	{
		public static void printArray(T[] array){
			Console.WriteLine ("Print Array - Start : \n");
			for (int i = 0; i < array.Length; i++) {
				Console.WriteLine ($"Element -> {i} = {array[i]}");
			}
			Console.WriteLine ("\nPrint Array - End -");
		}

		public static void fillArray(int[] array, int min = 0, int max = 1000){
			Random r = new Random ();
			for (int i = 0; i < array.Length; i++) {
				array [i] = r.Next (min,max);
			}
		}

	}
}

