using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControllerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void AddItemReturnsTrue()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            player.gameObject.AddComponent<Rigidbody2D>();
            var itemAdded = GameObject.Instantiate(player).AddItem("PorkChop");
            Assert.AreEqual(true, itemAdded);
        }

        [Test]
        public void AddItemReturnsFalseIfInvalid()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            player.gameObject.AddComponent<Rigidbody2D>();
            var itemAdded = GameObject.Instantiate(player).AddItem("NotAnItem");
            Assert.AreEqual(false, itemAdded);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        // [UnityTest]
        // public IEnumerator NewTestScriptWithEnumeratorPasses()
        // {
        //     // Use the Assert class to test conditions.
        //     // Use yield to skip a frame.
        //     yield return null;
        // }
    }
}
