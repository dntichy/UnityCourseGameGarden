using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Assets.Scripts;

//https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
/// <summary>
/// Responsible for scoreBoard
/// </summary>
public class ScoreBoard : MonoBehaviour
{

    [SerializeField] GameObject Entry; //Entry in scoreboard
    PlayerWrap[] Players; //Players retrieved from API
    readonly string url = "http://localhost:25325/api/values"; //API URL
 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetScoreData());
    }
    /// <summary>
  /// Gets data from API
    /// </summary>
    /// <returns></returns>
    IEnumerator GetScoreData()
    {
        //GET
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "text/json");

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonString = FixJson(www.downloadHandler.text);
                Players = JsonHelper.FromJson<PlayerWrap>(jsonString);
                AddObjectToScreen();
                Debug.Log(Players[0].name);
            }
        }
    }
    /// <summary>
    /// Helper function for fixing json from server to be parsed
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private string FixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }
    /// <summary>
    /// Add entry to the screen
    /// </summary>
    public void AddObjectToScreen()
    {
        var transCoeficient = 45;
        int countCoeficient = 0;

        if (Players != null)
        {
            foreach (PlayerWrap player in Players)
            {
                Vector3 vec = new Vector3();
                vec.x = Entry.transform.position.x;
                vec.y = Entry.transform.position.y - transCoeficient * countCoeficient;

                GameObject entry = Instantiate(Entry, Entry.transform.parent, true) as GameObject;

                entry.transform.position = vec;
                entry.transform.Find("Name").GetComponent<Text>().text = player.name;
                entry.transform.Find("Score").GetComponent<Text>().text = player.level.ToString();
                entry.transform.Find("Game Start").GetComponent<Text>().text = player.gameStart;
                entry.transform.Find("Game Finished").GetComponent<Text>().text = player.gameFinish;
                entry.transform.Find("Killed Creatures").GetComponent<Text>().text = player.killedCreatures.ToString();
                entry.transform.parent = transform;

                countCoeficient++;
            }
        }
    }


    /// <summary>
    /// Starts coroutine with api post call with statistics and nickname
    /// </summary>
    public void RequestInsert()
    {
        var inputField = FindObjectOfType<InputField>();
        if (inputField.text.Length == 0) return;

        StartCoroutine(SendGameResult(inputField.text));
    }

    /// <summary>
    /// Sends gameresult to API
    /// </summary>
    /// <param name="nickName"></param>
    /// <returns></returns>
    private IEnumerator SendGameResult(string nickName)
    {


        var level = PlayerStats.Level;
        var startGame = PlayerStats.GameStart;
        var killedCreatures = PlayerStats.KilledCreatures;

        //POST
        WWWForm form = new WWWForm();

        form.AddField("Name", nickName);
        form.AddField("Level", level);
        form.AddField("GameStart", startGame.ToString());
        form.AddField("GameFinished", DateTime.Now.ToString());
        form.AddField("KilledCreatures", killedCreatures);

        var request = UnityWebRequest.Post(url, form);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        request.SetRequestHeader("Accept", "text/json");

        yield return request.SendWebRequest();

        FindObjectOfType<LevelLoader>().ShowScoreBoard();

    }
}
