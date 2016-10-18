using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Part2;

namespace TaskThree.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext test)
        {
            Repository.Create<ArrayList>();
            Repository.Create<Hashtable>();
            Repository.Create<MyEngine>();
            Repository.Create<MyEngine>();
        }

        [TestMethod]
        public void TestGetAllGuidAndObjectForType()
        {
            var result1 = Repository.GetAllGuidAndObjectForType<ArrayList>();
            var result2 = Repository.GetAllGuidAndObjectForType<Hashtable>();
            var result3 = Repository.GetAllGuidAndObjectForType<MyEngine>();

            Assert.AreEqual(1, result1.Count);
            Assert.AreEqual(1, result2.Count);
            Assert.AreEqual(2, result3.Count);
        }

        [TestMethod]
        public void TestGetAllGuidAndObjectForTypeAtObjectParameter()
        {
            var result = Repository.GetAllGuidAndObjectForType<object>();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestGetObjectByGuid()
        {
            var guid = Repository.GetAllGuidAndObjectForType<ArrayList>().FirstOrDefault().Key;
            var result = Repository.GetObjectByGuid<ArrayList>(guid);

            Assert.AreEqual(typeof(ArrayList), result.GetType());
        }

        [TestMethod]
        public void TestGetObjectByGuidWithNull()
        {
            var guid = Repository.GetAllGuidAndObjectForType<ArrayList>().FirstOrDefault().Key;
            var result = Repository.GetObjectByGuid<Hashtable>(guid);

            Assert.IsNull(result);
        }
    }
}
