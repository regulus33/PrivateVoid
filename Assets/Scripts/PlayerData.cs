using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp = 100;

    public int porkChopImpact = 20;

    public int maxHp = 100;

    public string[] items;

    public int withdrawal;

    public int intWithdrawalImpact = 10;
    public int maxWithdraw = 100; 

    public int exp; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addHp(int hpToAdd)
    {   if(hpToAdd + hp <= maxHp)
        {
            hp += hpToAdd;
        }
    }

    public void deferWithdrawal(int amount)
    {
        if(withdrawal - amount > 0)
        {
            withdrawal -= amount;
        }
    }

    public void UseItem(string itemName)
    {
        if(itemName == "PorkChop")
        {
            addHp(porkChopImpact);
        }
        if(itemName == "PillBottle")
        {
            deferWithdrawal(intWithdrawalImpact);
        }

    }

}
