using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public GameObject rankingPanel;
    public GameObject formPanel;
    public InputField input;
    public Database database;

    public void OpenForm()
    {
        formPanel.SetActive(true);
    }
    public void CloseForm()
    {
        formPanel.SetActive(false);
    }

    public void OpenRanking()
    {
        rankingPanel.SetActive(true);
    }

    public void CloseRanking()
    {
        rankingPanel.SetActive(false);
    }

    public void SendScore()
    {
        StartCoroutine(database.SendScore(input));
    }

}
