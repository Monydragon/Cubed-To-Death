using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HighscoresController : MonoBehaviour
{
    [SerializeField]
    private GameObject rankPrefab, scorePrefab, namePrefab, contentPanel;

    [SerializeField]
    private List<HighScore> highScores;
    // Start is called before the first frame update

    private void OnEnable()
    {
        EventManager.onHighscoreAdd += EventManager_onHighscoreAdd;    
    }

    private void OnDisable()
    {
        EventManager.onHighscoreAdd -= EventManager_onHighscoreAdd;
    }

    void Start()
    {
        EventManager.HighscoreAdd("Mony", 500);
        EventManager.HighscoreAdd("Dave", 50);
        EventManager.HighscoreAdd("Justin", 150);
        EventManager.HighscoreAdd("Anthony", 1000);

        //highScores.Add(new HighScore{ Name = "Mony", Rank = "1St", Score = 5000});
        //highScores.Add(new HighScore{ Name = "Dave", Rank = "2nd", Score = 3500});



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EventManager_onHighscoreAdd(int score, string name)
    {

        for (int i = 0; i < contentPanel.transform.childCount; i++)
        {
            Destroy(contentPanel.transform.GetChild(i).gameObject);
        }

        var highscore = new HighScore
        {
            Name = name,
            Score = score
        };

        highScores.Add(highscore);
        highScores = highScores.OrderByDescending(x => x.Score).ToList();

        for (int i = 0; i < highScores.Count; i++)
        {
            var rank = i + 1;
            var rankText = "";

            switch (rank)
            {
                case 1:
                    rankText = "1ST";
                    break;
                case 2:
                    rankText = "2ND";
                    break;
                case 3:
                    rankText = "3RD";
                    break;
                default:
                    rankText = rank + "TH";
                    break;
            }

            rankPrefab.GetComponent<TMP_Text>().text = rankText;
            scorePrefab.GetComponent<TMP_Text>().text = highScores[i].Score.ToString();
            namePrefab.GetComponent<TMP_Text>().text = highScores[i].Name;
            Instantiate(rankPrefab, contentPanel.transform);
            Instantiate(scorePrefab, contentPanel.transform);
            Instantiate(namePrefab, contentPanel.transform);
        }

    }

}

[System.Serializable]
public struct HighScore
{
    public string Name { get; set; }
    public int Score { get; set; }
}