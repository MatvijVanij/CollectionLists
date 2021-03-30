using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLists
{
    public class DoubleLinkedList
    {
        private DoubleNode _root;

        private DoubleNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _root;
        }

        private DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                DoubleNode node = new DoubleNode(values[0]);
                _root = node;
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    DoubleNode current = new DoubleNode(values[i]);
                    _tail.Next = current;
                    current.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _tail = null;
                _root = null;

            }
        }

        public static DoubleLinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new DoubleLinkedList(values);
            }
            else
            {
                throw new NullReferenceException("Double List is null");
            }
        }

        public void AddLast(int value)
        {
            if (Length != 0)
            {
                DoubleNode node = new DoubleNode(value);

                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
                Length++;
            }
            else
            {
                Length = 1;
                _root = new DoubleNode(value);
                _tail = _root;
            }
        }

        public void AddLast(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    AddLast(list[i]);
                }
            }
            else
            {
                throw new ArgumentException("null is list for add");
            }

        }

        public void AddFirst(int value)
        {
            if (Length != 0)
            {
                Length++;
                DoubleNode node = new DoubleNode(value);

                _root.Previous = node;
                node.Next = _root;

                _root = node;
            }
            else
            {
                Length = 1;
                _root = new DoubleNode(value);
                _tail = _root;
            }

        }

        public void AddFirst(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                for (int i = list.Length - 1; i >= 0; i--)
                {
                    AddFirst(list[i]);
                }
            }
            else
            {
                throw new ArgumentException("null is list for add");
            }

        }

        public void AddByIndex(int index, int value)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (Length != 0)
                    {
                        DoubleNode node = new DoubleNode(value);
                        DoubleNode current = GetNodeByIndex(index - 1);

                        node.Next = current.Next;
                        current.Next = node;
                        node.Previous = current;

                        node.Next.Previous = node;

                        Length++;

                    }
                    else
                    {
                        Length = 1;
                        _root = new DoubleNode(value);
                        _tail = _root;
                    }
                }
                else
                {
                    AddFirst(value);
                }

            }
            else
            {
                throw new IndexOutOfRangeException(" ");
            }
        }

        public void AddByIndex(int index, DoubleLinkedList list)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (Length != index)
                    {
                        if (list.Length != 0 && !(list is null))
                        {

                            DoubleNode current = GetNodeByIndex(index);

                            list._tail.Next = current.Next;
                            current.Next = list._root;
                            list._root.Previous = current;
                            current.Next.Previous = list._tail;

                            Length += list.Length;

                        }
                    }
                    else
                    {
                        AddLast(list);
                    }
                }
                else
                {
                    AddFirst(list);
                }

            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                Length--;
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (Length != 0)
            {
                if (Length > nElements)
                {
                    _root = GetNodeByIndex(nElements);
                    Length -= nElements;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                if (Length != 1)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    Length--;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;

                }

            }
        }

        public void RemoveLast(int nElements)
        {
            if (Length != 0 && nElements != 0)
            {
                if (Length > nElements)
                {
                    _tail = GetNodeByIndex(Length - nElements - 1);
                    _tail.Next = null;
                    Length -= nElements;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }

            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (index != Length - 1)
                    {
                        DoubleNode current = GetNodeByIndex(index);
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                    }
                    else
                    {
                        RemoveLast();
                    }

                }
                else
                {
                    RemoveFirst();
                }
            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if (index >= 0 && index < Length)
            {
                if (Length > nElements)
                {
                    if (Length > index + nElements)
                    {
                        if (index != 0)
                        {
                            DoubleNode currentFirst = GetNodeByIndex(index);
                            DoubleNode currentSecond = GetNodeByIndex(index + nElements);

                            currentFirst.Previous.Next = currentSecond;
                            currentSecond.Previous = currentFirst.Previous;
                            Length -= nElements;
                        }
                        else
                        {
                            RemoveFirst(nElements);
                        }
                    }
                    else
                    {
                        RemoveLast(nElements);
                    }
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public int GetIndexByValue(int value)
        {
            DoubleNode current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            GetNodeByIndex(index).Value = value;
        }

        public int FindMaxElement()
        {
            if (Length != 0)
            {
                int max = _root.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (GetNodeByIndex(i).Value > max)
                    {
                        max = GetNodeByIndex(i).Value;
                    }
                }
                return max;
            }
            throw new ArgumentException("Length list is  zero");
        }

        public int FindMaxIndex()
        {
            if (true)
            {
                int index = GetIndexByValue(FindMaxElement());

                return index;
            }
            throw new ArgumentException("Length list is  zero");
        }

        public int FindMinElement()
        {
            if (Length != 0)
            {
                int min = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (min > GetNodeByIndex(i).Value)
                    {
                        min = GetNodeByIndex(i).Value;
                    }
                }
                return min;
            }
            throw new ArgumentException("Length list is  zero");
        }

        public int FindMinIndex()
        {
            if (Length != 0)
            {
                int index = GetIndexByValue(FindMinElement());
                return index;
            }
            throw new ArgumentException("Length list is  zero");
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                break;
            }

        }

        public void RemoveAllByValue(int value)
        {
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
            }
        }

        //public void Reverse()
        //{
        //    DoubleNode current = _root;
        //    DoubleNode tmp = _root;

        //    for (int i = 1; i < Length - 1; i++)
        //    {
        //        tmp = current.Next;
        //        current.Next = current.Previous;
        //        current.Previous = tmp;

        //        current = current.Previous;
        //    }
        //    _root = _tail;
        //    _tail = current;
        //}

        public void Sort(bool increaseTrueDecreaseFalse)
        {
            DoubleNode new_root = null;

            if (increaseTrueDecreaseFalse)
            {
                while (_root != null)
                {

                    DoubleNode node = _root;

                    _root = _root.Next;

                    if (new_root == null || node.Value < new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        DoubleNode current = new_root;
                        while (current.Next != null && !(node.Value < current.Next.Value))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;

                        current.Next = node;
                    }
                }
                _root = new_root;
            }
            else
            {
                while (_root != null)
                {

                    DoubleNode node = _root;

                    _root = _root.Next;

                    if (new_root == null || node.Value > new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        DoubleNode current = new_root;
                        while (current.Next != null && !(node.Value > current.Next.Value))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;

                        current.Next = node;
                    }
                }
                _root = new_root;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DoubleLinkedList || obj is null)
            {
                DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;
                bool isflag = false;
                if (this.Length == doubleLinkedList.Length)
                {
                    isflag = true;

                    DoubleNode currentThis = this._root;
                    DoubleNode currentList = doubleLinkedList._root;
                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isflag = false;
                            break;
                        }
                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }
                return isflag;
            }
            throw new ArgumentException("obj is null");
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DoubleNode current = _root;
                StringBuilder stringBuilder = new StringBuilder($"{current.Value}");

                while (!(current.Next is null))
                {
                    current = current.Next;
                    stringBuilder.Append($"{current.Value}");
                }
                return stringBuilder.ToString().Trim();
            }

            return String.Empty;
        }

        private DoubleNode GetNodeByIndex(int index)
        {
            DoubleNode current;

            if (index <= Length / 2)
            {
                current = _root;

                for (int i = 1; i < index + 1; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _tail;

                for (int i = Length - 1; i > index; --i)
                {
                    current = current.Previous;
                }
            }
            return current;
        }

    }
}

