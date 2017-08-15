using System;
using System.Collections.Generic;
namespace Algorithms
{
	/// <summary>
	/// It is a class that uses the Heap structure to 
	/// sort the given array.
	/// The onCompare delegate must be given a function to
	/// compare the two items and the sorting is achieved.
	/// 
	/// onCompare += (T element1_parent, T element2_child) => {return (bool);};
	///  
	/// </summary>
	public class Heap<T>
	{
		
		T[] array;
		int heapsize;

		public delegate bool HeapComparisonFunc(T e1, T e2);
		public HeapComparisonFunc onCompare = null;
		int left(int i){return 2 * i;}
		int right(int i){return 2 * i + 1;}
		int parent(int i){return i / 2;}
		void swap(ref T e1, ref T e2){
			T temp = e1;
			e1 = e2;
			e2 = temp;
		}
		void Heapify(int i, int alength){
			if (onCompare == null) {

				throw new Exception ("Heap Error : No onCompare handler provided. \n (Occured in Heapify() function)");
			} else {
				int li = left (i);
				int ri = right (i);
				int gi = i;
				if (li < alength && onCompare(array [li] , array [gi])) {
					gi = li;
				}
				if (ri < alength && onCompare(array [ri] , array [gi])) {
					gi = ri;
				}
				if (gi != i) {
					swap (ref array [gi], ref array [i]);
					Heapify (gi, alength);
				}
			}
		}
		public void buildHeap(){
			for (int c = this.heapsize / 2; c >= 0; c--) {
				Heapify (c, this.heapsize);
			}
		}
		void do_heapSort(){
			this.buildHeap ();
			T[] na = new T[this.heapsize];
			int tempsize = this.heapsize - 1;
			int naIndex = 0;
			while (tempsize >= 0) {
				swap (ref array [0], ref array [tempsize]);
				na [naIndex] = array [tempsize];
				naIndex++;
				tempsize--;
				Heapify (0, tempsize);
			}
			for (int i = 0; i < this.heapsize; i++) {
				array [i] = na [i];
			}
			if (!onCompare (array [this.heapsize - 2], array [this.heapsize - 1])) {
				swap (ref array [this.heapsize - 1], ref array [this.heapsize - 2]);
			}
		}

		public Heap (){
			this.array = null;
			this.heapsize = 0;
		}

		public Heap(T[] array){
			this.array = array;
			this.heapsize = this.array.Length;
		}

		public void setArray(T[] array){
			this.array = array;
			this.heapsize = this.array.Length;
		}

		public void HeapSort(){
			do_heapSort ();
		}

	}
}

