using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListCLass;

namespace TestCustomListClass
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void GiveValueGetIndex_ItemsInList_MatchExpectedIndex()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };
            int valueGiven = 5;
            int? indexResulting;
            int? indexExpected = 5;

            indexResulting = list.GiveValueGetIndex(valueGiven);

            Assert.AreEqual(indexExpected, indexResulting);
        }
        [TestMethod]
        public void GiveValueGetIndex_ItemsInList_NotNull()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };
            int valueGiven = 5;
            int? indexResulting;

            indexResulting = list.GiveValueGetIndex(valueGiven);

            Assert.IsNotNull(indexResulting);
        }

        [TestMethod]
        public void GiveValueGetIndex_ItemsInList_WrongValueIsNull()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };
            int valueGiven = 6;
            int? indexResulting;

            indexResulting = list.GiveValueGetIndex(valueGiven);

            Assert.IsNull(indexResulting);
        }


        [TestMethod]
        public void GiveValueGetIndex_ItemsInList_ReturnsFirstInstanceOf()
        {
            CustomList<int> list = new CustomList<int>() { 0, 5, 2, 3, 4, 5 };
            int valueGiven = 5;
            int indexExpected = 1;
            int? indexResulting;

            indexResulting = list.GiveValueGetIndex(valueGiven);

            Assert.AreEqual(indexResulting, indexExpected);
        }

        [TestMethod]
        public void GiveIndexGetValue_ItemsInList_IsNotNull()
        {
            CustomList<int> list = new CustomList<int>() { 0, 5, 2, 3, 4, 5 };
            int indexGiven = 1;
            int valueResulting;

            valueResulting = list.GiveIndexGetValue(indexGiven);

            Assert.IsNotNull(valueResulting);
        }

        public void GiveIndexGetValue_ItemsInList_IstNull()
        {
            CustomList<int> list = new CustomList<int>() { 0, 5, 2, 3, 4, 5 };
            int indexGiven = 7;
            int valueResulting;

            valueResulting = list.GiveIndexGetValue(indexGiven);

            Assert.IsNull(valueResulting);
        }

        [TestMethod]
        public void Count_ItemsInList_ReturnsCount()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };

            int result;
            int expected = 6;
            //arrange

            result = list.Count;
            //act

            Assert.AreEqual(result, expected);
            //assert 
        }

        [TestMethod]
        public void ToString_ChangeArrayToString_MatchesString()
        {
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };
            string result;
            string expected = "1,2,3,4,5";

            result = list.ToString();

            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void ToString_ChangeArrayToString_GiantInt()
        {
            CustomList<int> list = new CustomList<int>() { 999999999, 2, 3, 4, 5 };
            string result;
            string expected = "999999999,2,3,4,5";

            result = list.ToString();

            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void ToString_ChangeArrayToString_ContainsANegative()
        {
            CustomList<int> list = new CustomList<int>() { -16, 2, 3, 4, 5 };
            string result;
            string expected = "-16,2,3,4,5";

            result = list.ToString();

            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Add_ItemInList_ReturnsAccurateCount()
        {
            CustomList<int> list = new CustomList<int>();
            int result;
            int expected = 1;
            int addedItem = 5;

            list.Add(addedItem);
            result = list.Counter();

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Add_ItemInList_CheckIndexOfValue()
        {
            CustomList<int> list = new CustomList<int>();
            int? resultingIndex;
            int expectedIndex = 0;
            int addedItem = 5;

            list.Add(addedItem);
            resultingIndex = list.GiveValueGetIndex(addedItem);

            Assert.AreEqual(resultingIndex, expectedIndex);

        }


        [TestMethod]
        public void Add_ItemInList_CheckValueAtIndex()
        {
            CustomList<int> list = new CustomList<int>();
            int resultValue;
            int expectedValue = 5;
            int addedItem = 5;


            list.Add(addedItem);
            resultValue = list[0];

            Assert.AreEqual(resultValue, expectedValue);
        }

        [TestMethod]
        public void Remove_ItemFromList_ReturnsMatchingIndices()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };

            int removedItem = 2;
            int expected = 5;

            list.Remove(removedItem);
            int result = list[4];

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Remove_ItemFromList_ReturnsAccurateCount()
        {
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };
            int resultOfCount;
            int expectedCount = 5;
            int itemRemoved = 2;


            list.Remove(itemRemoved);
            resultOfCount = list.Counter();

            Assert.AreEqual(resultOfCount, expectedCount);
        }

        [TestMethod]
        public void Remove_RemoveMultipleObjectsFromList_ReturnLengthOfListWithRemovedElements()
        {
            CustomList<int> list = new CustomList<int>();
            //Arrange
            int number = 1;
            int biggerNumber = 2;
            int biggestNumber = 3;
            int expected = 1;
            int result;

            //Act
            list.Add(number);
            list.Add(biggerNumber);
            list.Add(biggestNumber);
            list.Remove(biggerNumber);
            list.Remove(biggestNumber);
            result = list.Counter();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Plus_Overload_CheckValueAtIndex()
        {
            CustomList<int> listA = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> listB = new CustomList<int>() { 1, 2, 3 };

            int expectedValue = 1;
            int resultingValue;
            CustomList<int> list = new CustomList<int>();

            list = listA + listB;

            resultingValue = list[3];

            Assert.AreEqual(expectedValue, resultingValue);
        }

       

        [TestMethod]
        public void Minus_Overload_CheckValueAtIndex()
        {
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> listB = new CustomList<int>() { 2, 3 };

            int expectedValue = 5;
            int resultingValue;

            list = list - listB;

            resultingValue = list[2];

            Assert.AreEqual(expectedValue, resultingValue);
        }

        [TestMethod]
        public void Zip_CheckValueAtIndex()
        {
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> itemsAdded = new CustomList<int>() { 0, 0, 0, };
            CustomList<int> zippedList = new CustomList<int>();
            int expectedValue = 0;
            int result;

            zippedList = list.Zip(itemsAdded);

            result = zippedList[1];

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Zip_CheckCount()
        {
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> itemsAdded = new CustomList<int>() { 0, 0, 0, };
            CustomList<int> zippedList = new CustomList<int>();
            int expectedCount = 6;
            int result;

            zippedList = list.Zip(itemsAdded);

            result = zippedList.Count;

            Assert.AreEqual(expectedCount, result);
        }

    }
}
