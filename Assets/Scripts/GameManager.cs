using System;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.Generic.FastLists;

public class GameManager : MonoBehaviour
{
    public System.Random random = new System.Random();
    public static GameManager instance;
    public UnsortedDistinctList<Building> buildings;
    UnsortedDistinctList<Character> characters;
    
    // Start is called before the first frame update


    void Start()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        buildings = new UnsortedDistinctList<Building>();
        characters = new UnsortedDistinctList<Character>();
        SetupCharacters();
	}

    float Movestep = 2, InfectStep = 4, STEP = 4;
    // Update is called once per frame
    void Update()
    {
        Movestep -= Time.deltaTime;
        if(Movestep < 0)
		{
            Movestep = STEP;
            for(int i = 0; i < characters.Count; i++)
			{
                characters[i].ChooseBuilding(buildings[random.Next(buildings.Count)]);
			}
		}
        InfectStep -= Time.deltaTime;
        if(InfectStep < 0)
		{
            InfectStep = STEP;
            for(int i = 0; i < buildings.Count; i++)
			{
                buildings[i].InfectPeople();
			}
		}
    }

    public int characterAmount = 1000;
    void SetupCharacters()
	{
        GameObject CharacterObject = Resources.Load<GameObject>("Prefabs/Character");
        for (int i = 0; i < characterAmount; i++)
		{
            Instantiate(CharacterObject);
		}
	}

    public void RegisterBuilding(Building building)
	{
        buildings.Add(building);
	}

    public void BeginSpread()
	{

	}

    public void Restart()
	{
        for(int i = 0; i < characters.Count; i++)
		{
            Destroy(characters[i].gameObject);
		}
        SetupCharacters();
	}
}
