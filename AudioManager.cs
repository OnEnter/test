using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Insite;
    private ScourManager scourManager;
    private CliManager cliManager;
    private void Awake()
    {
        cliManager = new CliManager();
        scourManager = new ScourManager(this.gameObject);
        Insite = this;
    }
    public void Play(string name)
    {
        AudioSource audio = scourManager.PlayAudio();
        ClipSing clipSing = cliManager.GetSing(name);
        clipSing.Play(audio);
    }
}
