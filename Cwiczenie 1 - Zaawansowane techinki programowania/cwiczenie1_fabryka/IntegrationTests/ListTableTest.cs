using cwiczenie1_fabryka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestClass]
    public class ListTableTest
    {
        [TestMethod]
        public void AddingElementsToListTest()
        {
            ListTable<int> table = new ListTable<int>();

            table.AddElement(3, 3);
            table.AddElement(10, 5);
            table.AddElement(14, 13);

            int expected = 3;
            int result = table.ElementsCount();

            Assert.AreEqual(expected, result);
        }

    }
}
