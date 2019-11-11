using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public string apiKey;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        /*RestClient.Get(new RequestHelper
        {
            Uri = "https://platform.antares.id:8443/~/antares-cse/antares-id/KebunKu/" + "PH-tanah" + "/la/",
            Headers = new Dictionary<string, string>
            {
                { "X-M2M-Origin", GameManager.instance.apiKey},
                { "Content-Type",  "application/json;ty=4"},
                { "Accept", "application/json"}
            }
        }).Then(res =>
        {

            string txt = res.Text.Substring(17, res.Text.Length - 20);
            var data = JsonUtility.FromJson<AntaresData>(txt);
            string[] values = data.con.Replace(" ", "").Split('|');
            foreach (string val in values)
            {
                            }

        }).Catch(err =>
        {
            Debug.Log(err.Message);
        });*/

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex==0) {
            EndGame();
        }
    }

    public void StartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentSceneIndex+ 1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
