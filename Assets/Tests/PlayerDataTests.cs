using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerDataTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Use_Item_Works()
        {
            var playerData = new GameObject().AddComponent<PlayerData>();
            playerData.hp = 0;
            playerData.UseItem("PorkChop");

            Assert.AreEqual(playerData.hp, playerData.porkChopImpact);
        }

    }
}
