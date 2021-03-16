using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameValues : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameValues instance;
    void Start()
    {
        if(instance == null)
		{
            instance = this;
		}
		else
		{
            Destroy(this.gameObject);
		}
    }

    public System.Random random = new System.Random();

    //Will be set in the editor
    public int xhouses;
    public int yhouses;
    public int xstores;
    public int ystores;
    public int infectTurns;
    public int immuneTurns;
    public int characterAmount;
    public int moveToHomeTurns;
    public int stayAtHome;
    [SerializeField]
    int deathChancePercentage;
    public int DeathChance
	{
		get
		{
            int chance = 100 / deathChancePercentage;
            return chance;
		}
	}


}
