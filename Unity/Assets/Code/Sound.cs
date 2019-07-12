using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public static class Sound
{
    //ID des persos : 0:Ours, 1:Crash, 2:Grenouille, 3:Hippo

    [FMODUnity.EventRef]
    static EventInstance langueCollision;
    static EventInstance langueImpact;
    static EventInstance barkIdle;
    static EventInstance gobe;
    static EventInstance Bonus;
    static EventInstance Victoire;
    static EventInstance gameplayMusic;

    public static void LoadSounds()
    {
        langueCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Langue_EnCollision");
        langueImpact = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Langue_Impact");
        barkIdle = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/BARK_Idle");
        gobe = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Gobe");
        Bonus = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Bonus");
        Victoire = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Victoire");
        gameplayMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Musiques/Gameplay_Music");


    }

    public static void LangueCollisionBegin()
    {
        langueCollision.start();
    }

    public static void LangueCollisionStop()
    {
        langueCollision.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public static void GameStart()
    {
        gameplayMusic.start();
        barkIdle.start();
    }

    public static void GameEnd()
    {
        barkIdle.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        gameplayMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public static void Gobe(int perso)
    {
        gobe.setParameterByName("Perso", perso, true);
        gobe.start();
    }



}
