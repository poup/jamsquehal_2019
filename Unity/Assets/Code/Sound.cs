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
    static EventInstance bonus;
    static EventInstance malus;
    static EventInstance victoire;
    static EventInstance gameplayMusic;
    static EventInstance menuScreenEvent;

    public static void LoadSounds()
    {
        langueCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Langue_EnCollision");
        langueImpact = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Langue_Impact");
        barkIdle = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/BARK_Idle");
        gobe = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Gobe");
        bonus = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Bonus");
        victoire = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Victoire");
        gameplayMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Musiques/Gameplay_Music");
        menuScreenEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Musiques/Menu_Music");
        malus = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay_SFX/SFX_Malus");



    }

    public static void LangueCollisionBegin()
    {
        langueImpact.start();
        langueCollision.start();
    }

    public static void LangueCollisionStop()
    {
        langueCollision.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public static void GameStart()
    {
        menuScreenEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //gameplayMusic.start();
        barkIdle.start();
    }  
    
    public static void GameStop()
    {
        barkIdle.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gameplayMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public static void VictoireScreen(int perso)
    {
        barkIdle.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gameplayMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        victoire.setParameterByName("Perso", perso, true);
        victoire.start();
    }

    public static void MenuScreen()
    {
        victoire.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        menuScreenEvent.start();

    }
    
    public static void Gobe(int perso)
    {
        gobe.setParameterByName("Perso", perso, true);
        gobe.start();
    }

    public static void Bonus(int perso)
    {
        bonus.setParameterByName("Perso", perso);
        bonus.start();
    }

    public static void Malus(int perso)
    {
        malus.setParameterByName("Perso", perso);
        malus.start();
    }




}
