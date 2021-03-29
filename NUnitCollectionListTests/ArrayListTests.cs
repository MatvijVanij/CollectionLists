using CollectionLists;
using NUnit.Framework;
using System;

namespace NUnitCollectionListTests
{
    public class ArrayListTests
    {
        [TestCase(-1, new int[] { 1, 2, 3 }, 99)]
        [TestCase(4, new int[] { 1, 3, 4 }, 99)]
        public void Indecsator_WhenIndexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int[] actualAr, int value)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(actualAr);

                actual[index] = value;
            });
        }

        [TestCase(99, new int[] { }, new int[] { 99 })]
        [TestCase(-11, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, -11 })]
        [TestCase(33, new int[] { -1, 2, 0, 4, 4 }, new int[] { -1, 2, 0, 4, 4, 33 })]
        [TestCase(00, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 67, 9, 87, -1, 00 })]
        public void AddLast_WhenGetValue_ShouldAddToLast(int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddLast(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 11, 22, 33 }, new int[] { 1 }, new int[] { 1, 11, 22, 33 })]
        [TestCase(new int[] { 99, 77 }, new int[] { 4, 6, 3 }, new int[] { 4, 6, 3, 99, 77 })]
        [TestCase(new int[] { 44 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44 })]
        [TestCase(new int[] { 77 }, new int[] { }, new int[] { 77 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddLast_WhenGetList_ShouldAddByLast(int[] newlist, int[] actualArr, int[] expectedArr)
        {
            ArrayList list = new ArrayList(newlist);
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddLast(list);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(99, new int[] { }, new int[] { 99 })]
        [TestCase(-11, new int[] { 1, 2, 3 }, new int[] { -11, 1, 2, 3 })]
        [TestCase(33, new int[] { -1, 2, 0, 4, 4 }, new int[] { 33, -1, 2, 0, 4, 4 })]
        [TestCase(00, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 00, -3, 5, 9, 0, 67, 9, 87, -1 })]
        public void AddFirst_WhenGetValue_ShouldAddToFirst(int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddFirst(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 11, 22, 33 }, new int[] { 1 }, new int[] { 11, 22, 33, 1 })]
        [TestCase(new int[] { 99, 77 }, new int[] { 4, 6, 3 }, new int[] { 99, 77, 4, 6, 3 })]
        [TestCase(new int[] { 44 }, new int[] { 1, 2, 3 }, new int[] { 44, 1, 2, 3 })]
        [TestCase(new int[] { 77 }, new int[] { }, new int[] { 77 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddFirst_WhenGetList_ShouldAddListFirst(int[] newlist, int[] actualArr, int[] expectedArr)
        {
            ArrayList list = new ArrayList(newlist);
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddFirst(list);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(3, 99, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 99 })]
        [TestCase(4, 99, new int[] { -1, 2, 0, 4, 4 }, new int[] { -1, 2, 0, 4, 99, 4 })]
        [TestCase(0, 99, new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 99, 1, 2, 3, 5, 7, 8 })]
        [TestCase(3, 99, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 99, 0, 67, 9, 87, -1 })]
        public void AddByIndex_WhenGetValue_ShouldAddValueByIndex(int index, int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddByIndex(index, value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5, 11, new int[] { 11, 22, 33 })]
        [TestCase(14, 11, new int[] { 11, 22, 33 })]
        [TestCase(-323, 11, new int[] { 11, 22, 33 })]
        public void AddByIndex_WhenIndexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int value, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.AddByIndex(index, value);
            });
        }

        [TestCase(0, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3, 4 }, new int[] { 11, 22, 33, 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 11, 22, 33, 3, 4 })]
        [TestCase(4, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 11, 22, 33 })]
        public void AddByIndex_WhenGetList_ShouldAddByIndex(int index, int[] newlist, int[] actualArr, int[] expectedArr)
        {
            ArrayList list = new ArrayList(newlist);
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddByIndex(index, list);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(-655, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3 })]
        [TestCase(-1, new int[] { 11, 22, 33 }, new int[] { 1, 2, 3 })]
        public void AddByIndex_WhenIndexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int[] listarray, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList list = new ArrayList(listarray);
                ArrayList actual = new ArrayList(expectedArr);

                actual.AddByIndex(index, list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { -1, 2, 0, 4, 4 }, new int[] { -1, 2, 0, 4 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 5, 7 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 67, 9, 87, })]
        public void RemoveLast_WhenGetValue_ShouldRemoveLast(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveLast();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 2, 3, 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 5, 9, 0, 67, 9, 87, -1 })]
        public void RemoveFirst_WhenGetValue_ShouldRemoveFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveFirst();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 5, 7, })]
        [TestCase(1, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 9, 0, 67, 9, 87, -1 })]
        public void RemoveByIndex_WhenGetIndex_ShouldRemoveValueByIndex(int index, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByIndex(index);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5, new int[] { 11, 22, 33 })]
        [TestCase(-1, new int[] { 11, 22, 33 })]
        [TestCase(-14, new int[] { 11, 22, 33 })]
        public void RemoveByIndex_WhenindexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.RemoveByIndex(index);
            });
        }

        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1 })]
        [TestCase(0, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 7 })]
        [TestCase(5, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9 })]
        public void RemoveLast_WhenGetNElements_ShouldRemoveLastNElements(int nElements, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveLast(nElements);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(0, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(6, new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { })]
        [TestCase(4, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 67, 9, 87, -1 })]
        public void RemoveFirst_WhenGetNElements_ShouldRemoveFirstNElements(int nElements, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveFirst(nElements);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, 2, new int[] { 1, 2, 3, 6 }, new int[] { 1, 6 })]
        [TestCase(0, 4, new int[] { 1, 2, 3, 4, -3, -5 }, new int[] { -3, -5 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { })]
        [TestCase(2, 2, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 67, 9, 87, -1 })]
        public void RemoveByIndex_WhenGetNElementsAndIndex_ShouldRemoveNElementsbyIndex(int index, int nElements, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByIndex(index, nElements);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5, 1, new int[] { 11, 22, 33 })]
        [TestCase(0, 7, new int[] { 11, 22, 33 })]
        [TestCase(-14, 1, new int[] { 11, 22, 33 })]
        [TestCase(0, 4, new int[] { 11, 22, 33 })]
        public void RemoveByIndex_WhenindexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int nElements, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.RemoveByIndex(index, nElements);
            });
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, -5, 5)]
        [TestCase(new int[] { 1, 2, 3, 0, 7, 8 }, 0, 3)]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, 67, 4)]
        public void GetIndexByValue_WhenGetValue_ShouldIndexForValue(int[] actualArray, int value, int expected)
        {
            ArrayList Array = new ArrayList(actualArray);

            int actual = Array.GetIndexByValue(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, 8)]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, 87)]
        public void FindMaxElement_WhenGetList_ShouldValueMax(int[] actualArray, int expected)
        {
            ArrayList Array = new ArrayList(actualArray);

            int actual = Array.FindMaxElement();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { })]
        public void FindMaxElement_WhenGetNullList_ShoudInvalidOperationException(int[] expectedArr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.FindMaxElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, 3)]
        [TestCase(new int[] { 76, 1, 2, 3, 4, -3, -5 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, 5)]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, 6)]
        public void FindMaxIndex_WhenGetList_ShouldIndexMax(int[] actualArray, int expected)
        {
            ArrayList Array = new ArrayList(actualArray);

            int actual = Array.FindMaxIndex();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { })]
        public void FindMaxIndex_WhenGetNullList_ShoudInvalidOperationException(int[] expectedArr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.FindMaxIndex();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, -5)]
        [TestCase(new int[] { 0, 1, 2, 3, 5, 7, 8 }, 0)]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, -3)]
        public void FindMinElement_WhenGetList_ShouldValueMin(int[] actualArray, int expected)
        {
            ArrayList Array = new ArrayList(actualArray);

            int actual = Array.FindMinElement();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { })]
        public void FindMinElement_WhenGetNullList_ShoudInvalidOperationException(int[] expectedArr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.FindMinElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, 0)]
        [TestCase(new int[] { 76, 1, 2, 3, 4, -3, -5 }, 6)]
        [TestCase(new int[] { 1, 2, 3, -7, 5, 7, 8 }, 3)]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, -87, -1 }, 6)]
        public void FindMinIndex_WhenGettList_ShouldIndexMin(int[] actualArray, int expected)
        {
            ArrayList Array = new ArrayList(actualArray);

            int actual = Array.FindMinIndex();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { })]
        public void FindMinIndex_WhenGetNullList_ShoudInvalidOperationException(int[] expectedArr)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.FindMinIndex();
            });
        }

        [TestCase(1, 100, new int[] { 2, 3, 6 }, new int[] { 2, 100, 6 })]
        [TestCase(0, 100, new int[] { 1, 2, 1, 3, 6 }, new int[] { 100, 2, 1, 3, 6 })]
        [TestCase(7, 100, new int[] { 1, -3, 2, -3, 3, 4, -3, -5 }, new int[] { 1, -3, 2, -3, 3, 4, -3, 100 })]
        [TestCase(5, 100, new int[] { -3, 67, 5, 9, 67, 0, 67, 9, 87, -1 }, new int[] { -3, 67, 5, 9, 67, 100, 67, 9, 87, -1 })]
        public void ChangeByIndex_WhenGetList_ShouldChangeValueByIndex(int index, int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.ChangeByIndex(index, value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5, 111, new int[] { 11, 22, 33 })]
        [TestCase(3, 111, new int[] { 11, 22, 33 })]
        [TestCase(-14, 111, new int[] { 11, 22, 33 })]
        [TestCase(-1, 111, new int[] { 11, 22, 33 })]
        public void ChangeByIndex_WhenIndexBigerLengthOrLessZero_ShoudArgumentOutOfRangeException(int index, int value, int[] expectedArr)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = new ArrayList(expectedArr);

                actual.ChangeByIndex(index, value);
            });
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { -1, 0, 3 }, new int[] { 3, 0, -1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void Revers_WhenGetList_ShouldRevers(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.Revers();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { -9, 4, -8 }, new int[] { 4, -8, -9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void SortDecrease_WhenGetList_ShouldSortDecrease(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.SortDecrease();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 3, 2, 0, 1 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 6, 4, 2, 5, 3, 1 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -9, 4, -8 }, new int[] { -9, -8, 4 })]
        public void SortIncrease_WhenGetList_ShouldSortIncrease(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.SortIncrease();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 1, 2, 3, 6 }, new int[] { 2, 3, 6 })]
        [TestCase(-3, new int[] { 1, 2, 3, 4, -3, -5 }, new int[] { 1, 2, 3, 4, -5 })]
        [TestCase(8, new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 5, 7, })]
        [TestCase(67, new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 9, 87, -1 })]
        public void RemoveByValue_WhenGetList_ShouldRemoveFistForValue(int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByValue(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 2, 3, 6 }, new int[] { 2, 3, 6 })]
        [TestCase(1, new int[] { 1, 2, 1, 3, 6 }, new int[] { 2, 3, 6 })]
        [TestCase(-3, new int[] { 1, -3, 2, -3, 3, 4, -3, -5 }, new int[] { 1, 2, 3, 4, -5 })]
        [TestCase(8, new int[] { 1, 2, 8, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 5, 7, })]
        [TestCase(67, new int[] { -3, 67, 5, 9, 67, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 9, 87, -1 })]
        public void RemoveAllByValue_WhenGetList_ShouldRemoveAllByValue(int value, int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveAllByValue(value);
            Assert.AreEqual(actual, expected);
        }
    }
}