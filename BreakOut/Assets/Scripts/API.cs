using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    private const string URL = "http://192.168.43.232:5000/p";
    private const string token = "abcdefghijklmnopqrstuvwxyz";
   

    public void Request()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers;

        form.AddField("score", "fuckYeah!!!");
        form.AddField("token", token);

        byte[] rawFormData = form.data;

        WWW request = new WWW(URL, rawFormData, headers);
    }
    
    private IEnumerator OnResponce(WWW req)
    {
        yield return req;
        Debug.Log(req.text);
    }
}
