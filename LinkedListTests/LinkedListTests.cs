using System;
using Xunit;
using LinkedListLibrary;

namespace LinkedListTests
{
    public class LinkedListTests
    {
        [Fact]
        public void Count_ElementsCountInEmptyList_0Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            int count = list.Count;

            //assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Count_ElementsCountInNotEmptyListWithOneElement_1Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(10);

            //act
            int count = list.Count;

            //assert
            Assert.Equal(1, count);
        }

        [Fact]
        public void First_FirstElementInEmptyList_InvalidOperationExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            try
            {
                var first = list.First;

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch(InvalidOperationException e)
            {
                Assert.Equal("List contains no elements", e.Message);
            }
        }

        [Fact]
        public void First_FirstElementInNotEmptyListWithElements1And2_1Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            var first = list.First;

            //assert
            Assert.Equal(1, first.Value);
        }

        [Fact]
        public void Last_LastElementInEmptyList_InvalidOperationExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            try
            {
                var first = list.Last;

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.Equal("List contains no elements", e.Message);
            }
        }

        [Fact]
        public void Last_LastElementInNotEmptyListWithElements1And2_2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            var last = list.Last;

            //assert
            Assert.Equal(2, last.Value);
        }

        [Fact]
        public void Clear_ClearEmptyList_0CountOfElementsReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            list.Clear();

            //assert
            int count = list.Count;
            Assert.Equal(0, count);
        }

        [Fact]
        public void Clear_ClearNotEmptyList_0CountOfElementsReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            //act
            list.Clear();

            //assert
            int count = list.Count;
            Assert.Equal(0, count);
        }

        [Fact]
        public void Contains_ÑontainsElement5InEmptyList_FalseReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            bool contains = list.Contains(5);

            //assert
            Assert.False(contains);
        }

        [Fact]
        public void Contains_ÑontainsElement5InNotEmptyListWithElements1And2_FalseReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            bool contains = list.Contains(5);

            //assert
            Assert.False(contains);
        }

        [Fact]
        public void Contains_ÑontainsElement5InNotEmptyListWithElements1And5_TrueReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(5);

            //act
            bool contains = list.Contains(5);

            //assert
            Assert.True(contains);
        }

        [Fact]
        public void AddFirst_AddFirstElement4InEmptyList_ListWithOneElement4Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            var first = list.AddFirst(4);

            //assert
            Assert.Single(list);
            Assert.Equal(4, first.Value);
        }

        [Fact]
        public void AddFirst_AddFirstElement1InNotEmptyListWithElements2And3_ListWithThreeElementsWithFirstElement1Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(2);
            list.Add(3);

            //act
            list.AddFirst(1);

            //assert
            Assert.Equal(3, list.Count);
            Assert.Equal(1, list.First.Value);
        }

        [Fact]
        public void AddLast_AddLastElement3InEmptyList_ListWithOneElement3Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            var last = list.AddLast(3);

            //assert
            Assert.Single(list);
            Assert.Equal(3, last.Value);
        }

        [Fact]
        public void AddLast_AddLastElement3InNotEmptyListWithElements1And2_ListWithThreeElementsWithLastElement3Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            list.AddLast(3);

            //assert
            Assert.Equal(3, list.Count);
            Assert.Equal(3, list.Last.Value);
        }

        [Fact]
        public void RemoveFirst_RemoveFirstElementFromEmptyList_InvalidOperationExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            try
            {
                list.RemoveFirst();

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.Equal("List contains no elements", e.Message);
            }
        }

        [Fact]
        public void RemoveFirst_RemoveFirstElement1FromNotEmptyListWithElements1And2_ListWithOneElementWithFirstElement2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            list.RemoveFirst();

            //assert
            Assert.Single(list);
            Assert.Equal(2, list.First.Value);
        }

        [Fact]
        public void RemoveFirst_RemoveFirstElement1FromNotEmptyListWithElement1_EmptyListReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);

            //act
            list.RemoveFirst();

            //assert
            Assert.Empty(list);
        }

        [Fact]
        public void RemoveLast_RemoveLastElementFromEmptyList_InvalidOperationExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            try
            {
                list.RemoveLast();

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.Equal("List contains no elements", e.Message);
            }
        }

        [Fact]
        public void RemoveLast_RemoveLastElement2FromNotEmptyListWithElements1And2_ListWithOneElementWithLastElement1Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            list.RemoveLast();

            //assert
            Assert.Single(list);
            Assert.Equal(1, list.Last.Value);
        }

        [Fact]
        public void RemoveLast_RemoveLastElement1FromNotEmptyListWithElement1_EmptyListReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);

            //act
            list.RemoveLast();

            //assert
            Assert.Empty(list);
        }

        [Fact]
        public void FindLast_FindLastElement1FromEmptyList_NullReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            var last1 = list.FindLast(1);

            //assert
            Assert.Null(last1);
        }

        [Fact]
        public void FindLast_FindLastElement1FromNotEmptyListWithElements1And1_ChangedValueLast1To2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            //act
            var last1 = list.FindLast(1);
            last1.Value = 2;

            //assert
            Assert.Equal(2, list.Last.Value);
        }

        [Fact]
        public void Remove_RemoveElement1FromEmptyList_FalseReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            var remove = list.Remove(1);

            //assert
            Assert.False(remove);
        }

        [Fact]
        public void Remove_RemoveElement1FromNotEmptyListWithElements1And2And3_Count2AndTrueReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var remove = list.Remove(1);

            //assert
            Assert.True(remove);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_RemoveElement2FromNotEmptyListWithElements1And2And3_Count2AndTrueReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var remove = list.Remove(2);

            //assert
            Assert.True(remove);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_RemoveElement3FromNotEmptyListWithElements1And2And3_Count2AndTrueReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var remove = list.Remove(3);

            //assert
            Assert.True(remove);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void CopyTo_CopyToNullArrayFromList_ArgumentNullExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            int[] array = null;

            //act
            try
            {
                list.CopyTo(array, 0);

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (ArgumentNullException e)
            {
                Assert.Equal("Value cannot be null. (Parameter 'array')", e.Message);
            }
        }

        [Fact]
        public void CopyTo_CopyToSmallArrayFromList_InvalidOperationExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            int[] array = new int[1];

            //act
            try
            {
                list.CopyTo(array, 0);

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.Equal("Array has insufficient space", e.Message);
            }
        }

        [Fact]
        public void CopyTo_CopyToArrayFromListInInvalidIndex_ArgumentOutOfRangeExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            int[] array = new int[2];

            //act
            try
            {
                list.CopyTo(array, 3);

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'index')", e.Message);
            }
        }

        [Fact]
        public void CopyTo_CopyToArrayWithElement1FromListWithElements2And3And4InIndex1_ArrayWithElements1And2And3And4Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            int[] array = new int[4];
            array[0] = 1;

            //act
            list.CopyTo(array, 1);

            //assert
            int[] real_array = new int[4] { 1, 2, 3, 4};
            Assert.Equal(real_array, array);
        }

        [Fact]
        public void AddAfter_AddAfterNullElementInList_ArgumentNullExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            Node<int> element = null;

            //act
            try
            {
                list.AddAfter(element, 2);

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (ArgumentNullException e)
            {
                Assert.Equal("Value cannot be null. (Parameter 'node')", e.Message);
            }
        }

        [Fact]
        public void AddAfter_Add2AfterElement1InNotEmptyListWithElement1_2CountOfElementsAnd2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            var element1 = list.AddFirst(1);

            //act
            var element2 = list.AddAfter(element1, 2);

            //assert
            Assert.Equal(2, list.Count);
            Assert.Equal(2, element2.Value);
        }

        [Fact]
        public void AddAfter_Add2AfterElement1InNotEmptyListWithElements1And3_3CountOfElementsAnd2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            var element1 = list.AddFirst(1);
            list.Add(3);

            //act
            var element2 = list.AddAfter(element1, 2);

            //assert
            Assert.Equal(3, list.Count);
            Assert.Equal(2, element2.Value);
        }

        [Fact]
        public void AddBefore_AddBeforeNullElementInList_ArgumentNullExceptionReturned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(2);
            Node<int> element = null;

            //act
            try
            {
                list.AddBefore(element, 1);

                //assert
                Assert.True(false, "No exception thrown");
            }
            catch (ArgumentNullException e)
            {
                Assert.Equal("Value cannot be null. (Parameter 'node')", e.Message);
            }
        }

        [Fact]
        public void AddBefore_Add1BeforeElement2InNotEmptyListWithElement2_2CountOfElementsAnd1Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            var element2 = list.AddLast(2);

            //act
            var element1 = list.AddBefore(element2, 1);

            //assert
            Assert.Equal(2, list.Count);
            Assert.Equal(1, element1.Value);
        }

        [Fact]
        public void AddBefore_Add2BeforeElement3InNotEmptyListWithElements1And3_3CountOfElementsAnd2Returned()
        {
            //arrange
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(1);
            var element3 = list.AddLast(3);

            //act
            var element2 = list.AddBefore(element3, 2);

            //assert
            Assert.Equal(3, list.Count);
            Assert.Equal(2, element2.Value);
        }
    }
}
