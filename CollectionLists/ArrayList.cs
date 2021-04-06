using System;
using System.Text;

namespace CollectionLists
{
    public class ArrayList
    {
        public const int firstValue = 10;
        private const string IndexOutOfRangeMessage = "Index Out Of Range";
        private int[] _array;

        public int Length { get; private set; }

        public ArrayList()
        {
            Length = 0;
            _array = new int[firstValue];
        }

        public ArrayList(int el)
        {
            Length = 0;
            _array = new int[firstValue];

            AddFirst(el);
        }

        private ArrayList(int[] initArray)
        {
            Length = 0;
            _array = new int[initArray.Length];

            foreach (var item in initArray)
            {
                _array[Length++] = item;
            }
        }

        public static ArrayList Create(int[] initArray)
        {
            if (initArray != null)
            {
                return new ArrayList(initArray);
            }
            else
            {
                throw new ArgumentException("No null in on");
            }

        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return _array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }

        public void AddLast(int value)
        {
            Resize(Length);

            _array[Length++] = value;
        }

        public void AddLast(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;

            Resize(oldLength);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[oldLength + i] = list[i];
            }

        }

        public void AddFirst(int value)
        {
            int index = 0;
            int nElemen = 1;

            Resize(Length);
            Length++;
            ShiftRight(index, nElemen);
            _array[index] = value;
        }

        public void AddFirst(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;
            Resize(oldLength);
            ShiftRight(list.Length - 1, list.Length);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[i] = list[i];
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index >= 0 && index <= Length)
            {
                int nElement = 1;

                Resize(Length);
                Length++;
                ShiftRight(index, nElement);
                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMessage);
            }
        }

        public void AddByIndex(int index, ArrayList list)
        {
            if (index <= Length && index >= 0)
            {
                int oldLength = Length;

                Length += list.Length;
                Resize(oldLength);
                ShiftRight(index + list.Length - 1, list.Length);

                for (int i = 0; i < list.Length; ++i)
                {
                    _array[i + index] = list[i];
                }
            }
            else
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMessage);
            }
        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                Length--;
            }

            Resize(Length);
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                int index = 0;
                int nElement = 1;

                Length--;
                ShiftLeft(index, nElement);
            }
            Resize(Length);
        }

        public void RemoveByIndex(int index)
        {
            int nElement = 1;

            if (index >= 0 && index < Length)
            {
                if (Length != 0)
                {
                    Length--;
                    ShiftLeft(index, nElement);
                }

                Resize(Length);
            }
            else
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMessage);
            }
        }

        public void RemoveLast(int nElelements)
        {
            if (Length >= nElelements)
            {
                if (nElelements >= 0)
                {
                    Length -= nElelements;
                }
            }
            else
            {
                Length = 0;
            }

            Resize(Length);
        }

        public void RemoveFirst(int nElelements)
        {
            if (!(Length <= nElelements))
            {
                if (nElelements >= 0)
                {
                    Length -= nElelements;
                    ShiftLeft(0, nElelements);
                }
            }
            else
            {
                Length = 0;
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index, int nElelements)
        {
            if (nElelements >= 0)
            {
                if (index >= 0 && index < Length)
                {
                    if (Length - index >= nElelements)
                    {
                        Length -= nElelements;
                        ShiftLeft(index, nElelements);
                    }
                    else
                    {
                        Length = index;
                    }
                    Resize(Length);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else 
            {
                throw new ArgumentException("in corect counts elements");
            }
        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse()
        {
            int swapIndex;

            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                Swap(ref _array[i], ref _array[swapIndex]);
            }
        }

        public int FindMaxIndex()
        {
            if (Length != 0)
            {
                int maxIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[maxIndexOfElement] < _array[i])
                    {
                        maxIndexOfElement = i;
                    }
                }
                return maxIndexOfElement;
            }

            throw new InvalidOperationException("List is null");
        }

        public int FindMinIndex()
        {
            if (Length != 0)
            {
                int minIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[minIndexOfElement] > _array[i])
                    {
                        minIndexOfElement = i;
                    }
                }
                return minIndexOfElement;
            }

            throw new InvalidOperationException("List is null");
        }

        public int FindMaxElement()
        {
            return _array[FindMaxIndex()];
        }

        public int FindMinElement()
        {
            return _array[FindMinIndex()];
        }

        public void RemoveByValue(int value)
        {
            RemoveByIndex(GetIndexByValue(value));
        }

        public void RemoveAllByValue(int value)
        {
            int indexOfElements = GetIndexByValue(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }
        }

        public void Sort(bool ascending)
        {
            var coef = ascending ? 1 : -1;

            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == coef)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < Length; i++)
                {
                    stringBuilder.Append($"{_array[i]} ");
                }

                return stringBuilder.ToString().Trim();
            }

            return string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList || !(obj is null))
            {
                ArrayList List = (ArrayList)obj;

                if (Length != List.Length)
                {
                    return false;
                }

                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != List._array[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            throw new ArgumentException("obj is null");
        }

        private void Resize(int oldLength)
        {
            if ((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[newLength];

                for (int i = 0; i < oldLength; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void ShiftRight(int index, int nElements)
        {
            for (int i = Length - 1; i > index; i--)
            {
                _array[i] = _array[i - nElements];
            }
        }

        private void ShiftLeft(int index, int nElements)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + nElements];
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_array, Length);
        }
    }
}




