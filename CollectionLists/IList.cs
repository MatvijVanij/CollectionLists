using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLists
{
    interface IList
    {
        public ArrayList()
        { }
        public ArrayList(int el)
        { }

        private ArrayList(int[] initArray)
        { }

        public static ArrayList Create(int[] initArray)
        { }

        public int this[int index]
        { }

        public void AddLast(int value)
        { }

        public void AddLast(ArrayList list)
        { }

        public void AddFirst(int value)
        { }

        public void AddFirst(ArrayList list)
        { }

        public void AddByIndex(int index, int value)
        { }

        public void AddByIndex(int index, ArrayList list)
        { }

        public void RemoveLast()
        { }

        public void RemoveFirst()
        { }

        public void RemoveByIndex(int index)
        { }

        public void RemoveLast(int nElelements)
        { }

        public void RemoveFirst(int nElelements)
        { }

        public void RemoveByIndex(int index, int nElelements)
        { }

        public int GetIndexByValue(int value)
        { }

        public void Reverse()
        { }

        public int FindMaxIndex()
        { }

        public int FindMinIndex()
        { }

        public int FindMaxElement()
        { }
        public int FindMinElement()
        { }

        public void RemoveByValue(int value)
        { }

        public void RemoveAllByValue(int value)
        { }

        public void Sort(bool increaseTrueDecreaseFalse)
        { }

        public override string ToString()
        { }

        public override bool Equals(object obj)
        { }





    }





}
}
