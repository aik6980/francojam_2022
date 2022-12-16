using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Scene_preload_script : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] GameObject textGO;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.LoadSoundBanks();

        textGO.GetComponent<TextMeshProUGUI>().text =  "Click to Start.";
    }

    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        textGO.GetComponent<TextMeshProUGUI>().text = "Loading...";
        SceneManager.LoadSceneAsync("Scene_UI_TitleScreen");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
