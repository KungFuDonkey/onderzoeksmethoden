using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.Generic.FastLists;

public class Building : MonoBehaviour
{
    UnsortedDistinctList<Character> people;
    string name;
    int size;
    float ventilationGrade;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.RegisterBuilding(this);
        people = new UnsortedDistinctList<Character>();
    }


    public void UnRegisterPerson(Character character)
	{
        people.Remove(character);
	}
    public void RegisterPerson(Character character)
	{
        people.Add(character);
	}

    public void InfectPeople()
	{
        float infectionChance = InfectionChance();
        for(int i = 0; i < people.Count; i++)
		{
            if(GameManager.instance.random.NextDouble() < infectionChance)
			{
                people[i].GetInfected();
			}
		}
	}

    public float InfectionChance()
    {
        return people.Count / size / ventilationGrade;
    }
}
