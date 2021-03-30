using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLists
{
    public class LinkedList
    {
        private Node _root;

        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index >= 0 && index <= Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        private LinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {

                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public static LinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new LinkedList(values);
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
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root;
            }
        }

        public void AddLast(LinkedList list)
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
            Length++;
            Node node = new Node(value);
            node.Next = _root;
            _root = node;
        }

        public void AddFirst(LinkedList list)
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
            if (index >= 0 && index <= Length)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else
                {
                    if (Length != 0)
                    {
                        Node node = new Node(value);
                        Node current = GetNodeByIndex(index - 1);

                        node.Next = current.Next;
                        current.Next = node;
                    }
                    else
                    {
                        _root = new Node(value);
                        _tail = _root;
                    }
                    Length++;
                }
            }
            else
            {
                throw new IndexOutOfRangeException(" ");
            }
        }

        public void AddByIndex(int index, LinkedList list)
        {
            if (index >= 0 && index <= Length)
            {
                if (index != 0)
                {
                    if (list.Length != 0)
                    {

                        Node current = GetNodeByIndex(index - 1);

                        list._tail.Next = current.Next;
                        list._tail = _tail;
                        _tail = current;

                        int newLengthList = list.Length + Length - index;
                        Length = index;

                        for (int i = 0; i < newLengthList; i++)
                        {
                            AddLast(list[i]);
                        }
                        list._tail.Next = null;
                    }
                }
                else
                {
                    AddFirst(list);
                }
            }
            else
            {
                throw new IndexOutOfRangeException(" ");
            }
        }

        public void RemoveLast()
        {
            RemoveByIndex(Length - 1);
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    if (Length != 0)
                    {
                        if (Length != 1)
                        {
                            Node current = GetNodeByIndex(index - 1);
                            current.Next = current.Next.Next;

                        }
                        else
                        {
                            _root = null;
                            _tail = null;
                        }
                        Length--;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException(" ");
            }
        }

        public void RemoveLast(int nElements)
        {
            if (Length != 0 && nElements != 0)
            {
                if (Length > nElements)
                {
                    _tail = GetNodeByIndex(Length - nElements);
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

        public void RemoveByIndex(int index, int nElements)
        {
            if ((index >= 0 && index < Length) && nElements >= 0)
            {
                if (Length != 0 || nElements != 0)
                {
                    if (index != 0)
                    {
                        if (Length - index - nElements > 0)
                        {
                            Node sectionStart = GetNodeByIndex(index - 1);
                            Node sectionEnd = GetNodeByIndex(index + nElements);

                            sectionStart.Next = sectionEnd;
                            Length -= nElements;
                        }
                        else
                        {
                            Node sectionStart = GetNodeByIndex(index - 1);
                            sectionStart.Next = null;
                            _tail = sectionStart;
                            Length = index;
                        }
                    }
                    else
                    {
                        RemoveFirst(nElements);
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Wrong arguments");
            }
        }

        public int GetIndexByValue(int value)
        {
            Node currentNode = _root;

            for (int i = 0; i < Length; i++)
            {
                if (currentNode.Value == value)
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            GetNodeByIndex(index).Value = value;
        }

        public void Revers()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    _tail.Next = _root;
                    Node tmpFisrt = _root.Next;
                    Node tmpSecond = _root.Next.Next;
                    _root.Next.Next = _root.Next;
                    _root.Next = null;

                    while (!(tmpSecond is null))
                    {
                        tmpFisrt.Next = _root;
                        _root = tmpFisrt;
                        tmpFisrt = tmpSecond;
                        tmpSecond = tmpSecond.Next;
                    }
                }
            }
            else
            {
                throw new NullReferenceException(" List is null!");
            }
        }

        public int FindMaxIndex()
        {
            if (Length != 0)
            {
                int index = GetIndexByValue(FindMaxElement());
                return index;
            }
            else
            {
                throw new ArgumentException("Length is 0 , no elements");
            }
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
            else
            {
                throw new ArgumentException("Length is 0 , no elements");
            }
        }

        public int FindMinIndex()
        {
            if (Length != 0)
            {
                int index = GetIndexByValue(FindMinElement());

                return index;
            }
            else
            {
                throw new ArgumentException("Length is 0 , no elements");
            }
        }

        public int FindMinElement()
        {
            if (Length != 0)
            {
                int min = _root.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (GetNodeByIndex(i).Value < min)
                    {
                        min = GetNodeByIndex(i).Value;
                    }
                }
                return min;
            }
            else
            {
                throw new ArgumentException("Length is 0 , no elements");
            }
        }

        public void Sort(bool increaseTrueDecreaseFalse)
        {
            Node new_root = null;

            if (increaseTrueDecreaseFalse)
            {
                while (_root != null)
                {
                    Node node = _root;
                    _root = _root.Next;

                    if (new_root == null || node.Value < new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        Node current = new_root;
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
                    Node node = _root;
                    _root = _root.Next;

                    if (new_root == null || node.Value > new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        Node current = new_root;
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

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if (index != -1)
            {
                RemoveByIndex(index);
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

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string str = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    str += current.Value + " ";
                }
                return str;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is LinkedList || obj is null)
            {

                LinkedList list = (LinkedList)obj;
                bool iseqvel = false;

                if (this.Length == list.Length)
                {
                    iseqvel = true;

                    Node currentThis = this._root;
                    Node currentList = list._root;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            iseqvel = false;
                            break;
                        }
                        currentList = currentList.Next;
                        currentThis = currentThis.Next;

                    }
                }
                return iseqvel;
            }
            throw new ArgumentException("obj is null");
        }

        private Node GetNodeByIndex(int index)
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }

}


