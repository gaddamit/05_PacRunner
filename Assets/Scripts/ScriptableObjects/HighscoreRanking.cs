using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighscoreRanking", menuName = "SOs/HighscoreRanking")]
public class HighscoreRanking : ScriptableObject
{
    [SerializeField]
    private int _maxHighscores = 5;
    public int index;
    public List<int> highscores = new List<int>(0);

    public void AddScore(int score)
    {
        index = _maxHighscores;
        for (int i = 0; i < highscores.Count; i++)
        {
            if (score >= highscores[i])
            {
                highscores.Insert(i, score);
                highscores.RemoveAt(highscores.Count - 1);

                index = i;
                Debug.Log(index);
                break;
            }
        }
    }
}
