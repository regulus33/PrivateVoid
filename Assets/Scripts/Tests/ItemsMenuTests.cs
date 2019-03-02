using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class ItemsMenuTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PopulateItems_Returns_Proper_Items()
        {
            var uiCanvas = new GameObject().AddComponent<ItemMenu>();

             uiCanvas.gameObject.AddComponent<Canvas>();

             ItemMenu.instance = GameObject.Instantiate(uiCanvas);

            var childOfItems = new GameObject();
            childOfItems.AddComponent<Text>();

             ItemMenu.instance.items = new GameObject();

            //setting the child items to the parent
            //https://answers.unity.com/questions/43011/how-to-make-a-game-object-a-child-of-antohter-whil.html
            childOfItems.gameObject.transform.parent = ItemMenu.instance.items.transform;

           Assert.AreEqual(ItemMenu.instance.PopulateItems()[0], childOfItems);


        }


     
    }
}
