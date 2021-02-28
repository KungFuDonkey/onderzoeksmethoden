using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) SpeedUp();
        if (Input.GetKeyDown(KeyCode.Q)) SlowDown();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
            this.transform.position += this.transform.forward;
		}
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
            this.transform.position -= this.transform.forward;
		}
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
            this.transform.position += this.transform.right;
		}
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
            this.transform.position -= this.transform.right;
		}
    }

    void SpeedUp()
	{
        Time.timeScale = Time.timeScale + 1;
	}

    void SlowDown()
	{
        Time.timeScale = Time.timeScale - 1;
	}
}
