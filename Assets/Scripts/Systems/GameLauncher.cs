using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    private AuthManager _auth;


    private async void Start()
    {
        _auth = Management.Instance.GetManager<AuthManager>() as AuthManager;

       
    }


    private async Task Initialize()
    {
        //게임런처 시작시 해야할것들
        /*
         *  1. 계정이 존재하는 지 파일 확인
         *      1-1. 계정이 존재하면 데이터 불러오기
         *      1-3. 계정이 존재하지 않으면 계정 새로 만들기
         *  2.
         *
         */
    }
}