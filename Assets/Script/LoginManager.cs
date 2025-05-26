using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Networking;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;


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

    void Start()
    {
        Login.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        if(PasswordInput != RePasswordInput)
        {
            Debug.Log("Wrong Password");
        }

        Data data = new Data
        {
            Email = EmailInput.text,
            Password = PasswordInput.text,
            RePassword = RePasswordInput.text,
        };

    }

}
