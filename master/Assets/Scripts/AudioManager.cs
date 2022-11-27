using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using Ink.Runtime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance;

    //[Header("Music Events")]
    [SerializeField]
    EventReference bowWowMusic, doggoAdventureMusic, dogxcitedMusic;
    public static EventInstance currentMusic;

    //[Header("Music - Scene matching")]
    [SerializeField]
    string bowWowScene, doggoAdventureScene, dogxcitedScene;        //Could insead do: foreach (scene.name) to add eventref for every scene
    Dictionary<string, EventReference> sceneMusic;

    //[Header("UI SFX Events")]
    [SerializeField]
    EventReference dogBarkUI;

    //[Header("UI SFX OneShot Events")]
    [SerializeField]
    EventReference woodClickUI, woodClickDownUI, woodClickUpUI, stoneClickDownUI, stoneClickUpUI, popClickUI, hoverUI01,
        hoverUI02, notificationUI01, notificationUI02, squeakToyUI;

    [SerializeField]
    EventReference dogDialogue;
    EventInstance dogDialogueEvent;

    //[Header("Parameters")]
    [SerializeField]
    ParamRef dogRef;

    EventInstance masterMuteSnapshot;

    public static GameObject volumeSliderObject;

    public enum ButtonType
    {
        Stone01,
        Wood01,
        Wood02,
        Phone01,
        Writing01,
        Dog01
    }

    public static AudioManager Instance
    {
        get {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        sceneMusic = new Dictionary<string, EventReference>() { { bowWowScene, bowWowMusic },
                                                                { doggoAdventureScene, doggoAdventureMusic },
                                                                { dogxcitedScene, dogxcitedMusic } };

        dogDialogueEvent = RuntimeManager.CreateInstance(dogDialogue);
        volumeSliderObject = GameObject.FindGameObjectWithTag("UI_Master_Volume");
        Debug.Log("Volume slider object: " + volumeSliderObject);

        CheckSceneMusic();
    }

    public void SetMasterVolume()
    {
        var volume = volumeSliderObject.GetComponent<UnityEngine.UI.Slider>().value;
        RuntimeManager.StudioSystem.setParameterByName("Master_Volume", volume);
    }

    public void MuteMasterVolume()
    {
        if (GetPlaybackState(masterMuteSnapshot) != PLAYBACK_STATE.PLAYING)
        {
            masterMuteSnapshot = RuntimeManager.CreateInstance("snapshot:/Master_Mute");
            masterMuteSnapshot.start();
        }
        else
        {
            masterMuteSnapshot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            masterMuteSnapshot.release();
        }
    }

    public void PlayClickDownUI(ButtonType type)
    {
        switch (type)
        {
        case ButtonType.Stone01:
            RuntimeManager.PlayOneShot(stoneClickDownUI);
            break;
        case ButtonType.Wood01:
            RuntimeManager.PlayOneShot(woodClickDownUI);
            break;
        case ButtonType.Wood02:
            RuntimeManager.PlayOneShot(woodClickUI);
            break;
        case ButtonType.Phone01:
            RuntimeManager.PlayOneShot(popClickUI);
            break;
        default:
            RuntimeManager.PlayOneShot(woodClickDownUI);
            break;
        }
    }

    public void PlayClickUpUI(ButtonType type)
    {
        switch (type)
        {
        case ButtonType.Stone01:
            RuntimeManager.PlayOneShot(stoneClickUpUI);
            break;
        case ButtonType.Wood01:
            RuntimeManager.PlayOneShot(woodClickUpUI);
            break;
        default:
            break;
        }
    }

    public void PlayHoverUI(ButtonType type, string doggoName = null)
    {
        switch (type)
        {
        case ButtonType.Stone01:
            RuntimeManager.PlayOneShot(hoverUI01);
            break;
        case ButtonType.Wood01:
            RuntimeManager.PlayOneShot(hoverUI02);
            break;
        case ButtonType.Dog01:
            PlayDogBarkUI(doggoName);
            break;
        default:
            RuntimeManager.PlayOneShot(hoverUI02);
            break;
        }
    }

    public void PlayNotificationUI01()
    {
        RuntimeManager.PlayOneShot(notificationUI01);
    }
    public void PlayNotificationUI02()
    {
        RuntimeManager.PlayOneShot(notificationUI02);
    }
    public void PlaySqueakToyUI()
    {
        RuntimeManager.PlayOneShot(squeakToyUI);
    }

    public EventInstance PlayMusic(EventReference musicTrack)
    {
        currentMusic.getDescription(out EventDescription currentMusicDesc);
        var newMusicDesc = RuntimeManager.GetEventDescription(musicTrack);

        currentMusicDesc.getID(out FMOD.GUID currentMusicGUID);
        newMusicDesc.getID(out FMOD.GUID newMusicGUID);

        if (currentMusicGUID != newMusicGUID)
        {
            currentMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            currentMusic = RuntimeManager.CreateInstance(musicTrack);
            currentMusic.start();
        }

        return currentMusic;
    }

    public void PlayDogBarkUI(string DoggoName)
    {
        if (DoggoName == null)
            return;

        var instance = RuntimeManager.CreateInstance(dogBarkUI);
        instance.setParameterByIDWithLabel(dogRef.ID, DoggoName);
        instance.start();
        instance.release();
    }

    public void PlayDialogue()
    {
        if (GetPlaybackState(dogDialogueEvent) != PLAYBACK_STATE.PLAYING)
            dogDialogueEvent.start();
    }

    EventInstance CreateEmitter(EventReference eventRef, GameObject soundSource)
    {
        // gizmo for min/max dist?
        var instance = RuntimeManager.CreateInstance(eventRef);
        RuntimeManager.AttachInstanceToGameObject(instance, soundSource.transform);
        instance.start();

        DrawSoundDistance(instance, soundSource);

        return instance;
    }
    void CheckSceneMusic()
    {
        var currentScene = SceneManager.GetActiveScene();

        foreach (var pair in sceneMusic)
        {
            if (pair.Key == currentScene.name)
            {
                PlayMusic(pair.Value);
            }
        }
    }

    void DrawSoundDistance(EventInstance instance, GameObject soundSource)
    {
        instance.getDescription(out EventDescription description);
        description.getMinMaxDistance(out float minDist, out float maxDist);

        Gizmos.DrawWireSphere(soundSource.transform.position, minDist);
        Gizmos.DrawWireSphere(soundSource.transform.position, maxDist);
    }

    public PLAYBACK_STATE GetPlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE playbackState;
        instance.getPlaybackState(out playbackState);
        return playbackState;
    }
}
