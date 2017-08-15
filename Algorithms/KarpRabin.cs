using System;

namespace Algorithms
{
	public static class KarpRabin
	{
		/// <summary>
		/// Searches the given trace in the target string using the
		/// KarpRabin Algorithm.
		/// Complexity of
		/// O(m + n + m`)
		/// </summary>
		/// <returns>The starting index of the given trace in the target string</returns>
		/// <param name="target">String from which the trace string is to search</param>
		/// <param name="trace">String that is to be search in the target</param>
		public static long StringSearch(string target, string trace){
			long traceHash = hash (trace);
			int loopLimit = target.Length - trace.Length;
			for (int i = 0; i < loopLimit; i++) {
				string rollingString = target.Substring (i, trace.Length);
				long rollingStringHash = hash (rollingString);
				if (rollingStringHash == traceHash) {
					if (rollingString == trace) {
						return i;
					}
				}
			}
			return -1;
		}

		static int hashMultiplicationFactor = 3;    // must be prime for less collisions

		static long hash(string s){
			long value = 0;
			for (int i = 0; i < s.Length; i++) {
				value += (long)Math.Pow(hashMultiplicationFactor, i) * (long)s[i];
			}
			return value;
		}
	}
}

