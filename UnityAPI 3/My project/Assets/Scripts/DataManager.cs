using System.Collections;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetData();
        }
    }

    // Fetches all quests
    public void GetData()
    {
        Debug.Log("Fetching data...");
        string uri = "https://localhost:7196/api/quests";

        if (player == null)
        {
            Debug.LogError("Player is not assigned!");
            return;
        }

        Quest quest = new Quest();
        StartCoroutine(quest.LoadDataFromDatabase(uri, player));
    }
}
