using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class woof : MonoBehaviour
{
    [SerializeField] GameObject goodBoy, dogButton;

    private void OnEnable()
    {
        AudioManager.Instance.PlayDogBarkUI("");

        goodBoy.SetActive(true);
        dogButton.SetActive(false);

        Invoke("DogButton", 0.3f);

        this.gameObject.SetActive(false);
    }

    void DogButton()
    {
        goodBoy.SetActive(false);
        dogButton.SetActive(true);
    }
}
