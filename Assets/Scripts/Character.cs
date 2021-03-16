using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Building Home;
    public CharacterState state = CharacterState.healthy;
    int infectedTurns = 0;
    int immuneTurns = 0;
    Building currentBuilding;
    public Character toInfect;
    Material mat;


    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        state = CharacterState.healthy;
        mat.color = Color.cyan;
    }


    Vector3 offsetVec = Vector3.up;
    public void ChooseBuilding(Building nextBuilding)
    {
        int random = GameValues.instance.random.Next(100);
        if(random < GameValues.instance.stayAtHome)
		{
            MoveHome();
		}
		else
		{
            GotoBuilding(nextBuilding);
		}


    }

    public void MoveHome()
	{
        GotoBuilding(Home);
	}

    void GotoBuilding(Building building)
	{
        if (currentBuilding != null) currentBuilding.UnRegisterPerson(this);
        currentBuilding = building;
        currentBuilding.RegisterPerson(this);

        float xoffset = (float)(GameValues.instance.random.NextDouble() - 0.5) * 10;
        float yoffset = (float)(GameValues.instance.random.NextDouble() - 0.5) * 10;
        offsetVec.x = xoffset;
        offsetVec.z = yoffset;


        this.transform.position = currentBuilding.transform.position + offsetVec;
    }


    public void GetInfected()
    {

		if (state == CharacterState.healthy)
		{
            state = CharacterState.infected;
            mat.color = Color.red;
            infectedTurns = GameValues.instance.infectTurns;
        }

    }

    public void Heal()
	{
		if (state == CharacterState.infected)
		{
            infectedTurns--;
            if(infectedTurns <= 0)
			{
                state = CharacterState.immune;
                mat.color = Color.green;
                immuneTurns = GameValues.instance.immuneTurns;
			}
		}
		else if (state == CharacterState.immune)
		{
            immuneTurns--;
            if(immuneTurns <= 0)
			{
                state = CharacterState.healthy;
                mat.color = Color.cyan;
			}

		}
	}
}
