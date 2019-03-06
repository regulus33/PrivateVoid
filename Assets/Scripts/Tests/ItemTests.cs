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
        public void Add_Item_Adds_Self_To_Player_Items()
        {
            var player = new GameObject().AddComponent<PlayerController>();

            var state = new GameObject().AddComponent<PlayerData>();

            var item = new GameObject().AddComponent<Item>();

            var initialListCount = state.itemList.Count;

            PlayerController.instance = GameObject.Instantiate(player);

            PlayerData.instance = GameObject.Instantiate(state);

            Item.instance = GameObject.Instantiate(item); 

            item.itemType = "pill_bottle";

            item.PickupItem();

            Assert.Greater(PlayerData.instance.itemList.Count, initialListCount);
            
        }

        [Test]
        public void Item_Is_Destroyed_Once_Used()
        {
            var player = new GameObject().AddComponent<PlayerController>();

            var item = new GameObject().AddComponent<Item>();

            PlayerController.instance = GameObject.Instantiate(player);

            Item.instance = GameObject.Instantiate(item); 

            item.itemType = "pork_chop";

            item.PickupItem();

            Assert.AreEqual(false, item.gameObject.activeInHierarchy);

        }

        

       
    }
}
