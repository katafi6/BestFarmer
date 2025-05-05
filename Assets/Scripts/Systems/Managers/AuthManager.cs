using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class UserAccount
{
    private string _email;
    private string _password;
}

public class AuthManager : ManagerBase
{
    private UserAccount _account;
    private string _path = "";

    public async Task<bool> CheckUserLoginFromFile(string path, Action<string> onMessage = null)
    {
        onMessage?.Invoke("계정 정보를 확인하고 있습니다.");
        bool existsFile = await SaveLoader.WaitForFileExists(path);
        if (existsFile == false)
        {
            onMessage?.Invoke("계정 정보가 존재하지 않거나 요청시간이 초과하였습니다.");
            return false;
        }

        
        return true;
    }
}