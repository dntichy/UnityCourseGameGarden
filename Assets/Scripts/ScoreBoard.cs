using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ScoreBoard : MonoBehaviour
{

    [SerializeField] GameObject Entry;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Upload());

    }

    IEnumerator Upload()
    {
        AddObjectToScreen();


        var url = "http://localhost:25325/api/values";

        //POST
        //WWWForm form = new WWWForm();
        //form.AddField("Name", "MojNick");
        //form.AddField("Level", 3);
        //var request = UnityWebRequest.Post(url, form);
        //request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        //request.SetRequestHeader("Accept", "text/json");
        //yield return request.SendWebRequest();



        //GET
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "text/json");

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www);

            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                Debug.Log("Form upload complete!");
            }
        }
    }

    public void AddObjectToScreen()
    {
        Vector3 vec = new Vector3();
        vec.x = Entry.transform.position.x;
        vec.y = Entry.transform.position.y - 30;

        GameObject entry = Instantiate(Entry, Entry.transform.parent, true) as GameObject;
        entry.transform.position = vec;

        entry.transform.parent = transform;



    }
}
