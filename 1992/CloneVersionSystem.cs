using System;
using System.Collections.Generic;

namespace Clones
{
	class Clone
	{
		LinkedStack<int> programs = new LinkedStack<int>();

		LinkedStack<int> rollbacks = new LinkedStack<int>();

		public void Rollback()
		{
			rollbacks.Push(programs.Pop());
		}

		public void Learn(int program)
		{
			programs.Push(program);
			rollbacks = new LinkedStack<int>();
		}

		public void Relearn()
		{
			programs.Push(rollbacks.Pop());
		}

		public string Check()
		{
			return programs.Count > 0 ? programs.PeekLastItem().Value.ToString() : "basic";
		}

		public Clone CreateClone()
		{
			var newClone = new Clone();
			if (programs.Count != 0)
				newClone.programs.CopyLinkedStack(programs.PeekLastItem(),programs.Count);
			if (rollbacks.Count != 0)
				newClone.rollbacks.CopyLinkedStack(rollbacks.PeekLastItem(), rollbacks.Count);
			return newClone;
		}
	}

	public class CloneVersionSystem : ICloneVersionSystem
	{
		public CloneVersionSystem()
		{
			clones.Add(new Clone());
		}

		private List<Clone> clones = new List<Clone>();

		public string Execute(string query)
		{
			var input = query.Split();
			var cloneNumber = int.Parse(input[1]) - 1;
			switch (input[0])
			{
				case "learn":
					clones[cloneNumber].Learn(int.Parse(input[2]));
					return null;
				case "rollback":
					clones[cloneNumber].Rollback();
					return null;
				case "relearn":
					clones[cloneNumber].Relearn();
					return null;
				case "clone":
					clones.Add(clones[cloneNumber].CreateClone());
					return null;
				case "check":
					return clones[cloneNumber].Check();
				default:
					return "Unknown command";
			}
		}
	}

	class LinkedStackItem<T>
	{
		public LinkedStackItem(T item)
		{
			Value = item;
		}

		public LinkedStackItem<T> PreviosItem;
		public LinkedStackItem<T> NextItem;
		public T Value;
	}

	class LinkedStack<T>
	{
		LinkedStackItem<T> LastItem { get; set; }

		public int Count { get; private set; }

		public void Push(T item)
		{
			var newItem = new LinkedStackItem<T>(item);
			if (Count == 0)
			{
				LastItem = newItem;
			}
			newItem.PreviosItem = LastItem;
			LastItem.NextItem = newItem;
			LastItem = newItem;
			Count++;
		}

		public T Pop()
		{
			if (Count == 0)
				throw new Exception();
			var value = LastItem.Value;
			if (Count == 1)
			{
				LastItem = null;
			}
			else
			{
				LastItem = LastItem.PreviosItem;
				LastItem.NextItem = null;
			}
			Count--;
			return value;
		}

		public void CopyLinkedStack(LinkedStackItem<T> item, int count)
		{
			LastItem = item;
			Count = count;
		}

		public LinkedStackItem<T> PeekLastItem()
		{
			return LastItem;
		}
	}
}
