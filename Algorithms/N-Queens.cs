using System;

// THIS CODE USES THE BACKTRACKING ALGORITHM 
// TO FINE HOW CAN N-Queens CAN BE PLACED ON 
// N X N CHESS BOARD WITHOUT BEING ATTACKED.

namespace Algorithms
{
	public class N_Queens
	{
		int n;  // number of boxes on chess board.
		int printCount; 	// number of queens to be placed
		bool[,] board;
		public N_Queens (){}
		public N_Queens (int n){
			this.n = n;
			this.printCount = 0;
			makeBoard ();
		}
		public void Solve(){
			if (!placeQueen (n)) {
				Console.WriteLine ("Sorry it is impossible to solve the problem");
			}
		}

		void makeBoard(){
			board = new bool[this.n, this.n];
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					board [i, j] = false;
				}
			}
		}

		bool is_attacked_via_row(int i, int j){
			int count = 0;
			for (int col = 0; col < n; col++) {

				if (board [i, col]) {
					count++;
				}
			}
			if (count > 1) {
				return true;
			}
			return false;
		}

		bool is_attacked_via_col(int i, int j){
			int count = 0;
			for (int row = 0; row < n; row++) {
				if (board [row, j]) {
					count++;
				}
			}
			if (count > 1) {
				return true;
			}
			return false;
		}

		bool is_attacked_via_left_diagonal(int i, int j){
			int count = 0;
			int r = i, c = j;
			while (r >= 0&&c >= 0) {
				if (board [r, c]) {
					count++;
				}
				r--;
				c--;
			}
			r = i + 1; c = j + 1;
			while (r < n && c < n) {
				if (board [r, c]) {
					count++;
				}
				r++;
				c++;
			}
			if (count > 1) {
				return true;
			}
			return false;
		}

		bool is_attacked_via_rigth_diagonal(int i, int j){
			int count = 0;
			int r = i, c = j;
			while (r>=0&&c<n) {
				if (board [r, c]) {
					count++;
				}
				r--;
				c++;
			}
			r = i + 1;
			c = j - 1;
			while (r<n&&c>=0) {

				if (board [r, c]) {
					count++;
				}
				c--;
				r++;
			}
			if (count > 1) {
				return true;
			}
			return false;
		}

		bool is_attacked(int i, int j){
			if (is_attacked_via_col (i, j)) {
				return true;
			}
			if (is_attacked_via_row (i, j)) {
				return true;
			}
			if (is_attacked_via_left_diagonal (i, j)) {
				return true;
			}
			if (is_attacked_via_rigth_diagonal (i, j)) {
				return true;
			}
			return false;
		}

		bool placeQueen(int nq){
			Console.WriteLine ("-------------------------------\nEntring the playQueen");
			printBoard ();
			if (nq <= 0) {
				return true;
			}
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					if (!board [i, j]) {
						board [i, j] = true;
						if (!is_attacked (i, j)) {
							board [i, j] = true;
							if (placeQueen (nq - 1)) {
								Console.WriteLine ("-------------------------------\nreturn true the playQueen");
								printBoard ();
								return true;	
							}
							board [i, j] = false;
						}
						board [i, j] = false;
					}
				}
			}
			return false;
		}

		void printBoard(){
			Console.WriteLine ("Print Count = " + printCount);
			printCount++;
			for (int i = 0; i < n; i++) {
				Console.Write("\t");
				for (int j = 0; j < n; j++) {
					if (board [i, j]) {
						Console.Write ("1 ");
					} else {
						Console.Write ("0 ");
					}
				}
				Console.WriteLine ();
			}
		}


	}
}

