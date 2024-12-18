using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

[System.Serializable]
public class Quest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Reward { get; set; }

    public Quest() { }

    public Quest(int id, string name, string description, int reward)
    {
        Id = id;
        Name = name;
        Description = description;
        Reward = reward;
    }

    public IEnumerator LoadDataFromDatabase(string uri, Player player)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Network error: {request.error}");
            }
            else
            {
                string json = request.downloadHandler.text;
                Quest[] quests = JsonConvert.DeserializeObject<Quest[]>(json);

                if (quests != null && quests.Length > 0)
                {
                    Debug.Log($"Id:{quests[0].Id}, Name:{quests[0].Name}");
                    if (quests.Length > 1)
                    {
                        Debug.Log($"Id:{quests[1].Id}, Name:{quests[1].Name}");
                    }
                }
                else
                {
                    Debug.LogWarning("No quests found.");
                }
            }
        }
    }
}
