using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Building Home;
    bool infected = false;
    Building currentBuilding;
    public Character toInfect;
    Material mat;


    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            toInfect.getInfected();
        }
    }

    public void ChooseBuilding(Building nextBuilding)
    {
        if (currentBuilding != null) currentBuilding.UnRegisterPerson(this);
        currentBuilding = nextBuilding;
        currentBuilding.RegisterPerson(this);
    }

    public void GetInfected()
    {
        Debug.Log("infected");
        infected = true;
        mat.color = Color.green;
    }
}
