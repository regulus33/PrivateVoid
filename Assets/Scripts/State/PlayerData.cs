using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp = 100;
    public int wisdom = 0;
    public int withdrawal = 0;
    public int will = 0;
    public int maxHp = 100;
    public int maxWithdraw = 100; 
    public int porkChopImpact = 20;
    public int intWithdrawalImpact = 10;
    public List<string> itemList = new List<string>();

    public int exp; 

    public static PlayerData instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
        if(itemName == "pork_chop")
        {
            addHp(porkChopImpact);
        }
        if(itemName == "pill_bottle")
        {
            deferWithdrawal(intWithdrawalImpact);
        }

    }

}
