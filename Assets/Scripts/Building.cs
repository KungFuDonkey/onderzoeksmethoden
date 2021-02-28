using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    int peopleCount;
    string name;
    int size;
    float ventilationGrade;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.RegisterBuilding(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float InfectionChance
    {
        get { return peopleCount / size / ventilationGrade; }
    }
}
