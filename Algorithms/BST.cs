using System;
using System.Collections.Generic;

namespace Algorithms
{
	/// <summary>
	/// This is the Binary Search Tree structure.
	/// </summary>
	public class BST<T>
	{
		public class Node{
			public T record;
			public Node left;
			public Node right;
		}

		Node head = null;

		public Node Head {
			get {
				return head;
			}
		}

		int size = 0;
		Node createNode(T item){
			Node n = new Node();
			n.record = item;

			n.left = null;
			n.right = null;
			return n;
		}
		void addNode(ref Node n, T item){
			if (n == null) {
				n = createNode (item);
				return;
			}
			if (onAddCompare (n.record, item)) {
				addNode (ref n.right, item);

			} else {
				addNode (ref n.left, item);

			}
		}
		T searchNode(Node n, T item){
			if (n == null) {
				throw new Exception ("Item does not exist.");
			}
			if (onSearchCompare (n.record, item)) {
				return n.record;
			}
			if (onAddCompare (n.record, item)) {
				return searchNode (n.right, item);
			} else {
				return searchNode (n.left, item);
			}
		}
		void displayTree(Node root)
		{
			Node temp;
			temp = root;
			if (temp == null)
				return;
			displayTree(temp.left);
			System.Console.Write(temp.record + " ");
			displayTree(temp.right);
		}
		void do_BSTSort(Node root, ref List<T> list)
		{
			Node temp;
			temp = root;
			if (temp == null)
				return;
			do_BSTSort (temp.right, ref list);
			list.Add (temp.record);
			do_BSTSort (temp.left, ref list);
		}

		public delegate bool BSTComparisonFunc(T parent, T item);
		public BSTComparisonFunc onAddCompare = null;
		public BSTComparisonFunc onSearchCompare = null;
		public BST () {}

		public void Add(T item){
			if (onAddCompare == null) {
				throw new Exception ("BST Error : No onAddCompare handler provided. \n (Occured in Add() function)");
			}
			addNode (ref head, item);
			size++;
		}

		public T Search(T item){
			if (onSearchCompare == null) {
				throw new Exception ("BST Error : No onSearchCompare handler provided. \n (Occured in Search() function)");
			}
			return searchNode (head, item);
		}

		public void printTree(){
			displayTree (head);
		}

		public List<T> BSTSort(){
			List<T> l = new List<T> ();
			do_BSTSort (head, ref l);
			return l;
		}

	}
}

