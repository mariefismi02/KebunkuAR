using System;
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using RSG;
using UnityEditor;
using UnityEngine;

public static class AntaresClient 
{
    public static IPromise<AntaresData> Get(string apiKey, string uri)
    {
        var promise = new Promise<AntaresData>();    // Create promise.

        RestClient.Get(new RequestHelper
        {
            Uri = uri,
            Headers = new Dictionary<string, string>
            {
                {"X-M2M-Origin", apiKey},
                {"Content-Type", "application/json;ty=4"},
                {"Accept", "application/json"}
            }
        }).Then(res =>
        {

            string txt = res.Text.Substring(17, res.Text.Length - 20);
            var data = JsonUtility.FromJson<AntaresData>(txt);
            promise.Resolve(data);
        }).Catch(err =>
        {
            string message = err.Message;

            promise.Resolve(new AntaresData(message, message));
        });


        return promise;

    }
}
