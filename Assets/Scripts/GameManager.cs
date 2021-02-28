using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.Generic.FastLists;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UnsortedDistinctList<Building> buildings;
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

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterBuilding(Building building)
	{
        buildings.Add(building);
	}
}
