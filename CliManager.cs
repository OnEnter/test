using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CliManager {
    public string[] clipName;
    public ClipSing[] Sings;
    public CliManager()
    {
        Load();
        Musci();
    }
    private void Load()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "游戏音乐.txt");
        FileInfo file = new FileInfo(path);
        if(file.Exists)
        {
            StreamReader r = new StreamReader(path);
            string tmpLine = r.ReadLine();
            int LineCount;
            if(int.TryParse(tmpLine,out LineCount))
            {
                clipName = new string[LineCount];
                for (int i = 0; i < LineCount; i++)
                {
                    tmpLine = r.ReadLine();
                    clipName[i] = tmpLine;
                }
            }
            r.Close();
        }
    }
    private void Musci()
    {
        Sings = new ClipSing[clipName.Length];
        for (int i = 0; i < clipName.Length; i++)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/"+clipName);
            ClipSing sing = new ClipSing(clip);
            Sings[i] = sing;
        }
    }
    public ClipSing GetSing(string audioName)
    {
        int c = 0;
        for (int i = 0; i < clipName.Length; i++)
        {
            if(clipName[i].Equals(audioName))
            {
                c = i;
            }
        }
        if (c != 0)
            return Sings[c];
        Debug.Log("没有搜索到该歌曲   "+ audioName);
        return null;
    }
}
