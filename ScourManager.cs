using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScourManager 
{
    GameObject ScourGame;
    List<AudioSource> allScour;
    public ScourManager(GameObject tmpGame)
    {
        ScourGame = tmpGame;
        AddScour();
    }
    public void AddScour()
    {
        allScour = new List<AudioSource>();
        for (int i = 0; i < 3; i++)
        {
            AudioSource audio = ScourGame.AddComponent<AudioSource>();
            allScour.Add(audio);
        }
    }
    public void AudioStop(string name)
    {
        for (int i = 0; i < allScour.Count; i++)
        {
            if (allScour[i].isPlaying && allScour[i].clip.name == name)
            {
                allScour[i].Stop();
            }
        }
    }
    public AudioSource PlayAudio()
    {
        for (int i = 0; i < allScour.Count; i++)
        {
            if (!allScour[i].isPlaying)
            {
                return allScour[i];
            }
        }
        AudioSource audio = ScourGame.AddComponent<AudioSource>();
        allScour.Add(audio);
        return audio;
    }
    public void RelesFreeAudio()
    {
        int tmpIndex = 0;
        List<AudioSource> audios = new List<AudioSource>();
        for (int i = 0; i < allScour.Count; i++)
        {
            if (!allScour[i].isPlaying)
            {
                tmpIndex++;
                if (tmpIndex > 3)
                    audios.Add(allScour[i]);
            }
        }
        for (int i = 0; i < audios.Count; i++)
        {
            AudioSource audio = audios[i];
            allScour.Remove(audio);
            GameObject.Destroy(audio);
        }
        audios.Clear();
    }
}
