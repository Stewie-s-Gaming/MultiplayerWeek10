using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        updateScore(score);
    }
    public void updateScore(int newScore)
    {
        score += newScore;
        gameObject.GetComponent<TextMeshPro>().SetText("" + score);
    }
    public int getScore()
    {
        return score;
    }
}
