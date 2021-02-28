using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Building Home;
    bool infected;
    Building currentBuilding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseBuilding(Building nextBuilding)
    {
        currentBuilding = nextBuilding;
    }
}
