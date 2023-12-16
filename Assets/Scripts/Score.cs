using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int score = 0;

    public static void print()
    {
	GameObject go = GameObject.Find("Score");
	Text scoreText = go.GetComponent<Text>();

	scoreText.text = "Score: " + score.ToString();
	Debug.Log("Score: " + score.ToString());
    }
    
    public static void Update(int n)
    {
	score += n;
	Debug.Log(n);
	Debug.Log(score);
	print();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
	print();
    }

    // Update is called once per frame
    void Update()
    {
	
    }
}
