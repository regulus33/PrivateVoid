using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ItemTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ItemTestsSimplePasses()
        {
            var item = new GameObject().AddComponent<Item>();
            var itemTestedMethod = GameObject.Instantiate(item).JustForTest(3);
            Assert.AreEqual(9, itemTestedMethod);
        }

       
    }
}
