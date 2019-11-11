using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AntaresClient 
{
    public static string Get(string apiKey)
    {
        string result = null;

        //Unfinished Code
        /*RestClient.Get(new RequestHelper
        {
            Uri = "https://platform.antares.id:8443/~/antares-cse/antares-id/KebunKu/PH-tanah/la/",
            Headers = new Dictionary<string, string>
            {
                { "X-M2M-Origin", apiKey},
                { "Content-Type",  "application/json;ty=4"},
                { "Accept", "application/json"}
            }
        }).Then(res =>
        {

            string txt = res.Text.Substring(17, res.Text.Length - 20);
            var data = JsonUtility.FromJson<AntaresData>(txt);
            //Debug.Log(result);
            result = data.con;
        }).Catch(err =>
        {
            Debug.Log(err.Message);
            result = "";
        });*/

        return result;

    }
}
