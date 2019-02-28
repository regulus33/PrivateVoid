using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI; //dont forget this one!!

namespace Tests
{
    public class PlayerMenuTests
    {

        // A Test behaves as an ordinary method
        [Test]
        public void Adds_Player_HP_To_UI()
        {
            //setup, INSTANTIATE all required components, yes a lot i KNOW. Unity tests are not a thing yet i guess. 
             
             var uiCanvas = new GameObject().AddComponent<PlayerMenu>();

             uiCanvas.gameObject.AddComponent<Canvas>();

             PlayerMenu.instance = GameObject.Instantiate(uiCanvas);

             PlayerMenu.instance.hpText = new GameObject().AddComponent<Text>();
             
             PlayerMenu.instance.wisdomText = new GameObject().AddComponent<Text>();
             
             PlayerMenu.instance.willText = new GameObject().AddComponent<Text>();
             
             PlayerMenu.instance.withdrawText = new GameObject().AddComponent<Text>();

             var playerData = new GameObject().AddComponent<PlayerData>();

             PlayerData.instance = GameObject.Instantiate(playerData);


            PlayerMenu.instance.updateHP();
            
            PlayerMenu.instance.updateWisdom();
            
            PlayerMenu.instance.updateWill();
            
            PlayerMenu.instance.updateWithdrawal();

            Assert.AreEqual(PlayerData.instance.hp.ToString(), PlayerMenu.instance.hpText.text);
            
            Assert.AreEqual(PlayerData.instance.will.ToString(), PlayerMenu.instance.willText.text);
            
            Assert.AreEqual(PlayerData.instance.wisdom.ToString(), 
            PlayerMenu.instance.wisdomText.text);
            
            Assert.AreEqual(PlayerData.instance.withdrawal.ToString(), PlayerMenu.instance.withdrawText.text);

        }
        [Test]
        public void First_Toggle_Resolves_True()
        {
            var uiCanvas = new GameObject().AddComponent<PlayerMenu>();

             uiCanvas.gameObject.AddComponent<Canvas>();

             PlayerMenu.instance = GameObject.Instantiate(uiCanvas);

            PlayerMenu.instance.ToggleMenu();

            Assert.AreEqual(true, PlayerMenu.instance.shouldAssemble);
        }
    
    }
}
