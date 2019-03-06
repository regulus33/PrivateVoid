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
        public void ExtractUIItems_Returns_Proper_Items()
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

            //COMPARING ITEM IN ARRAY TO ITEM CREATED IN SCRIPT ABOVE
           Assert.AreEqual(ItemMenu.instance.ExtractUIItems()[0], childOfItems);


        }

        [Test]
        public void PopulateItems_changes_text_of_ui_to_player_item()
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
            //add a player item
            var player = new GameObject().AddComponent<PlayerController>();

            var playerData = new GameObject().AddComponent<PlayerData>();

            PlayerData.instance = playerData;

            // player.gameObject.AddComponent<Rigidbody2D>();
            var dataInstance = GameObject.Instantiate(playerData);
            var playerInstance = GameObject.Instantiate(player).AddItem("pork_chop");
            

            var itemText = ItemMenu.instance.items.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text;
            
           Assert.AreEqual("pork chop", "pork chop");

            // playerInstance
            // ItemMenu.instance.

            //SETUP FINALLLLY DONE, need to put this shit in methods.

            




        }

        [Test]

        public void Has_A_Working_String_Sanitizer()
        {
            var uiCanvas = new GameObject().AddComponent<ItemMenu>();

            uiCanvas.gameObject.AddComponent<Canvas>();

            ItemMenu.instance = GameObject.Instantiate(uiCanvas);

            Assert.AreEqual("pork_chop", ItemMenu.instance.MakeComputerFormat("pork chop"));
        }


     
    }
}
