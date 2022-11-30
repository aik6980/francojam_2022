using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance;
    public static EventInstance currentMusic, currentEnvironment;

    [Serializable]
    public struct SceneMusicSet
    {
        public string scene;
        public EventReference music, environment;
        public ParamRef parameter;
    }
    public SceneMusicSet[] sceneAudio;

    [SerializeField]
    EventReference dogBarkUI, woodClickUI, woodClickDownUI, woodClickUpUI, stoneClickDownUI, stoneClickUpUI, 
        popClickUI, popClickDownUI, popClickUpUI, hoverUI01,
        hoverUI02, notificationUI01, notificationUI02, squeakToyUI;

    [SerializeField]
    EventReference dogDialogue;

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
        Phone02,
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (var i = 0; i < sceneAudio.Length; i++)
        {
            if (sceneAudio[i].scene == scene.name)
            {
                PlayMusic(sceneAudio[i].music);
                PlayEnvironment(sceneAudio[i].environment);
                currentMusic.setParameterByName(sceneAudio[i].parameter.Name, sceneAudio[i].parameter.Value);     //There has to be a better way to do this?
            }
        }

    }

    private void Start()
    {
        volumeSliderObject = GameObject.FindGameObjectWithTag("UI_Master_Volume");
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
            RuntimeManager.PlayOneShot(popClickDownUI);
            break;
        case ButtonType.Phone02:
            RuntimeManager.PlayOneShot(notificationUI01);
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
            currentMusic.release();
            currentMusic = RuntimeManager.CreateInstance(musicTrack);
            currentMusic.start();
        }

        return currentMusic;
    }

    public EventInstance PlayEnvironment(EventReference environment)            //this is shoddy, but environments will probably have to do something different later once more are in
    {
        currentEnvironment.getDescription(out EventDescription currentEnvironmentDesc);
        var newEnvironmentDesc = RuntimeManager.GetEventDescription(environment);

        currentEnvironmentDesc.getID(out FMOD.GUID currentEnvironmentGUID);
        newEnvironmentDesc.getID(out FMOD.GUID newEnvironmentGUID);

        if (currentEnvironmentGUID != newEnvironmentGUID)
        {
            currentEnvironment.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            currentEnvironment.release();
            currentEnvironment = RuntimeManager.CreateInstance(environment);
            currentEnvironment.start();
        }

        return currentEnvironment;
    }

    public void PlayDogBarkUI(string doggoName)
    {
        if (doggoName == null)
            return;

        var instance = RuntimeManager.CreateInstance(dogBarkUI);
        instance.setParameterByNameWithLabel(dogRef.Name, doggoName);
        instance.start();
        instance.release();
    }

    public void PlayDialogue(EventReference charVoice)
    {
        RuntimeManager.PlayOneShot(charVoice);
    }

    public PLAYBACK_STATE GetPlaybackState(EventInstance instance)
    {
        instance.getPlaybackState(out PLAYBACK_STATE playbackState);
        return playbackState;
    }
}
