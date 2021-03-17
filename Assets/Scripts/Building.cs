using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures.Generic.FastLists;

public class Building : MonoBehaviour
{
    UnsortedDistinctList<Character> people;

    int size = 10;
    float ventilationGrade = 1;


    // Start is called before the first frame update
    void Start()
    {
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
            if(GameValues.instance.random.NextDouble() < infectionChance)
			{
                people[i].GetInfected();
			}
		}
	}

    public float InfectionChance()
    {
        float infectedPeople = 0;
        for(int i = 0; i < people.Count; i++)
		{
            infectedPeople += people[i].state == CharacterState.infected ? 1 : 0;
		}
        return infectedPeople / size * GameValues.instance.RZero;
    }

	public void Restart()
	{
        people.Clear();
	}
}
