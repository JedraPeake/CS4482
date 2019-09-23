using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderMenu : MonoBehaviour
{
	TextMeshProUGUI first;
	TextMeshProUGUI second;
	TextMeshProUGUI third;

	LeaderBoard leaderBoard;

	void Awake()
    {
		GameObject firstObj = GameObject.FindGameObjectWithTag("Score1");
		first = firstObj.GetComponent<TextMeshProUGUI>();

		GameObject secondObj = GameObject.FindGameObjectWithTag("Score2");
		second = secondObj.GetComponent<TextMeshProUGUI>();

		GameObject thirdObj = GameObject.FindGameObjectWithTag("Score3");
		third = thirdObj.GetComponent<TextMeshProUGUI>();

		GameObject g = GameObject.FindGameObjectWithTag("StaticObj");
		leaderBoard = g.GetComponent<LeaderBoard>();
	}

    void Update()
    {
		List<Entry> ent = leaderBoard.GetLB();

		first.text = $"{ent[0].name}: {ent[0].score}";
		second.text = $"{ent[1].name}: {ent[1].score}";
		third.text = $"{ent[2].name}: {ent[2].score}";
	}
}
