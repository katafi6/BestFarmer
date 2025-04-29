using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using System.Text;
using System.Threading.Tasks;


public class SaveLoader
{
    public static bool SaveFile(object obj, string fileName)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

        return true;
    }

    public  static async Task<bool> WaitForFileExists(string path)
    {
        int waitTime = 500;
        int maxTime = 10000;
        int currentTime = 0;

        while (!File.Exists(path))
        {
            Debug.Log("파일이 아직 없습니다. 기다리는 중...");
            await Task.Delay(waitTime); // 0.5초 기다린 다음 다시 확인
            currentTime += waitTime;
            if (currentTime >= maxTime)
            {
                return false;
            }
        }

        return true;
    }

    public static bool LoadFileFromLocal<T>(string path, string fileName, T loadData) where T : class
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(path);
        sb.Append("/");
        sb.Append(fileName);

        if (!File.Exists(sb.ToString()))
        {
            Debug.Log("File does not exist");
            return false;
        }

        string jsonFile = File.ReadAllText(path);
        T data = JsonConvert.DeserializeObject<T>(jsonFile);

        return true;
    }
}