using System;

namespace Algorithms
{
	public class tArrayNode<T>{

		class tArrayNode_listNode<t>{
			T item;
			tArrayNode_listNode<t> next;
			public tArrayNode_listNode(t item, tArrayNode_listNode<t> next){
				this.next = next;
				this.item = item;
			}
			public t Item(){ return item;}
			public tArrayNode_listNode<t> Next(){return next;}
		}

		T item;
		tArrayNode_listNode<T> head;
		tArrayNode<T>[] table;
		public tArrayNode(){}

	}

	public class tArray
	{
		public tArray ()
		{
		}
	}
}

