using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkService : MonoBehaviour
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&mode=xml&APPID=b5c83d3c8a729dc9c6f9578b8a9131be";
    private const string jsonAPI = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&APPID=b5c83d3c8a729dc9c6f9578b8a9131be";
    private const string webImage = "http://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";

    private bool IsResponseValid(WWW www)
    {
        if(www.error != null)
        {
            Debug.Log("bad connection");
            return false;
        }
        else if(string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if (!IsResponseValid(www))
        {
            yield break;
        }

        callback(www.text);
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

    public IEnumerator GetWeatherJSON(Action<string> callback)
    {
        return CallAPI(jsonAPI, callback);
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        WWW www = new WWW(webImage);
        yield return www;
        callback(www.texture);
    }

}
