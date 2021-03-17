using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
	List<(int, int, int, float)> state;
	List<Image> images;

	public bool AddState(List<Character> characters, float r)
	{
		int healthy = 0;
		int infected = 0;
		int immune= 0;
		for(int i = 0; i < characters.Count; i++)
		{
			if (characters[i].state == CharacterState.immune)
			{
				immune++;
			}
			else if (characters[i].state == CharacterState.infected)
			{
				infected++;
			}
			else if (characters[i].state == CharacterState.healthy)
			{
				healthy++;
			}
		}
		if (state == null) state = new List<(int, int, int, float)>();
		state.Add((healthy, infected, immune, r));
		if(infected == 0 && immune != 0)
		{
			Stop();
			return true;
		}
		return false;
	}

	public void Stop()
	{
		DrawGraph();
		WriteGraph();
	}

	void DrawGraph()
	{
		float width = Screen.width / state.Count;
		float height = Screen.height;
		int totalPopSize = GameValues.instance.characterAmount;
		float heightStep = (height / totalPopSize);
		GameObject imageObject = Resources.Load<GameObject>("UI/Image");
		for(int i = 0; i < state.Count; i++)
		{
			GameObject healthyObject = Instantiate(imageObject, this.transform);
			GameObject infectedObject = Instantiate(imageObject, this.transform);
			GameObject immuneObject = Instantiate(imageObject, this.transform);
			Image healthyImage = healthyObject.GetComponent<Image>();
			Image infectedImage = infectedObject.GetComponent<Image>();
			Image immuneImage = immuneObject.GetComponent<Image>();
			healthyImage.color = Color.blue;
			infectedImage.color = Color.red;
			immuneImage.color = Color.green;

			RectTransform healthyRect = healthyObject.GetComponent<RectTransform>();
			RectTransform infectedRect = infectedObject.GetComponent<RectTransform>();
			RectTransform immuneRect = immuneObject.GetComponent<RectTransform>();

			healthyRect.sizeDelta = new Vector2(width, state[i].Item1 * heightStep);
			infectedRect.sizeDelta = new Vector2(width, state[i].Item2 * heightStep);
			immuneRect.sizeDelta = new Vector2(width, state[i].Item3 * heightStep);

			float posx = width * i - Screen.width / 2;
			float healthyY = heightStep * state[i].Item1;
			float infectedY = healthyY + heightStep * state[i].Item2 / 2;
			float immuneY = infectedY + heightStep * state[i].Item2 / 2 + heightStep * state[i].Item3 / 2;
			healthyY = healthyY / 2 - Screen.height / 2;
			infectedY -= Screen.height / 2;
			immuneY -= Screen.height / 2;

			healthyRect.anchoredPosition = new Vector2(posx, healthyY);
			infectedRect.anchoredPosition = new Vector2(posx, infectedY);
			immuneRect.anchoredPosition = new Vector2(posx, immuneY);


		}
	}

	void WriteGraph()
	{	
		using (NamedPipeServerStream pipeServer =
		new NamedPipeServerStream("excelpipe", PipeDirection.Out))
		{

			// Wait for a client to connect
			pipeServer.WaitForConnection();
			try
			{
				// Read user input and send that to the client process.
				using (StreamWriter sw = new StreamWriter(pipeServer))
				{
					sw.AutoFlush = true;
					for (int i = 0; i < state.Count; i++)
					{
						sw.WriteLine(string.Format("{0} {1} {2} {3}" , state[i].Item1, state[i].Item2, state[i].Item3, state[i].Item4));
					}
				}
			}
			// Catch the IOException that is raised if the pipe is broken
			// or disconnected.
			catch
			{

			}
		}
	}
	public void Restart()
	{
		for(int i = 0; i < images.Count; i++)
		{
			Destroy(images[i].gameObject);
		}
		state.Clear();
	}
}
