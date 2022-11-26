using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance;

    [Header("UI SFX Events")]
    [SerializeField] EventReference dogBarkUI;

    [Header("UI SFX Parameters")]
    [SerializeField] ParamRef dogRef;


    public static AudioManager Instance
    {
        get 
        { 
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

    public void PlayDogBarkUI(int dogReference)
    {
        var instance = RuntimeManager.CreateInstance(dogBarkUI);
        instance.setParameterByID(dogRef.ID, dogReference);
        instance.start();
        instance.release();
    }

    EventInstance CreateEmitter(EventReference eventRef, GameObject soundSource)
    {
        //gizmo for min/max dist?
        var instance = RuntimeManager.CreateInstance(eventRef);
        RuntimeManager.AttachInstanceToGameObject(instance, soundSource.transform);
        instance.start();

        DrawSoundDistance(instance, soundSource);

        return instance;
    }

    void DrawSoundDistance(EventInstance instance, GameObject soundSource)
    {
        instance.getDescription(out EventDescription description);
        description.getMinMaxDistance(out float minDist, out float maxDist);

        Gizmos.DrawWireSphere(soundSource.transform.position, minDist);
        Gizmos.DrawWireSphere(soundSource.transform.position, maxDist);
    }

    PLAYBACK_STATE GetPlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE playbackState;
        instance.getPlaybackState(out playbackState);
        return playbackState;
    }
}
