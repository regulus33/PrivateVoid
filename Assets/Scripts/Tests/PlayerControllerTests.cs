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
        public void Add_Item_Returns_True()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            player.gameObject.AddComponent<Rigidbody2D>();
            var itemAdded = GameObject.Instantiate(player).AddItem("pork_chop");
            Assert.AreEqual(true, itemAdded);
        }

        [Test]
        public void Add_Item_Returns_False_If_Invalid()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            player.gameObject.AddComponent<Rigidbody2D>();
            var itemAdded = GameObject.Instantiate(player).AddItem("not_an_item");
            Assert.AreEqual(false, itemAdded);
        }

        [Test]

        public void Item_Is_Destroyed_Once_Used()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            player.gameObject.AddComponent<Rigidbody2D>();
            var itemAdded = GameObject.Instantiate(player).AddItem("not_an_item");
            
            // Assert.AreEqual(false, itemAdded);

        }
    }
}
