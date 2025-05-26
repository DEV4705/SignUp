using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Networking;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;


[System.Serializable]
public class Data
{
    public string Email;
    public string Password;
    public string RePassword;

}

public class LoginManager : MonoBehaviour
{
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField RePasswordInput;
    public Button Login;

    private string URL = "https://binusgat.rf.gd/unity-api-test/api/auth/signup.php";

    void Start()
    {
        Login.onClick.AddListener(OnSubmit);
    }

    IEnumerator PostRequest(string uri, string json)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + request.error);
            Debug.Log("Full response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }

    }

    void OnSubmit()
    {
        if(PasswordInput.text != RePasswordInput.text)
        {
            Debug.Log("Wrong Password");
        }

        Data data = new Data
        {
            Email = EmailInput.text,
            Password = PasswordInput.text,
            RePassword = RePasswordInput.text,
        };

        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(PostRequest(URL, jsonData));

    }

    

}
