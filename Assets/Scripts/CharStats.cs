using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int[] mpLvlBonus;
    public int currentMP;
    public int maxMP = 30;
    public int strength;
    public int defence;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            //delete this for production
            //Debug.Log(i);
            //incrementing up exp to next level slightly 
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }
    //add exp and stats
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if(currentEXP > expToNextLevel[playerLevel])
        {
            currentEXP -= expToNextLevel[playerLevel];
            playerLevel++;

            //determine strenght or defense 
            //even or odd
            if(playerLevel%2 == 0)
            {
                strength++;
            }
            else
            {
                defence++;
            }

            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            //make the current now max amen
            currentHP = maxHP;

            maxMP = maxMP + mpLvlBonus[playerLevel];
            currentMP = maxMP; 

        }
    }
}
