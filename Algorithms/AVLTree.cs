using System;

namespace Algorithms
{
	public class AVLTree<T>
	{
		public class Node
		{
			public T record;
			public Node right = null;
			public Node left = null;
			public int height = 0;
		}

		int height(Node node){ return node == null ? -1 : node.height;}

		public AVLTree(){}

		public void Add(){
		
		}



	}
}

