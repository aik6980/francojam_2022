using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dog_ImageStatus : MonoBehaviour
{
	public Doggo doggo_enum;
	public bool available = true;

	public List<Image> images;
	public Image emoji;

	void Start()
    {
		System.Enum.TryParse(name, out doggo_enum);

		images.AddRange(GetComponentsInChildren<Image>(true));
		emoji = images.Find(i => i.name == "Emoji");

		images.RemoveAll(i => i.name == "mask");
		images.RemoveAll(i => i.gameObject == this.gameObject);
		images.RemoveAll(i => i.name == "Pin");
		images.RemoveAll(i => i.name == "Emoji");
	}

	//ToDo: we'll need some callback or broadcast event after each "round", so we can update our status
	//ToDo: display more thank just on/off; an emoji for example.

    void Update()
    {
		bool _available = Story_selection_mgr.Instance.Is_available_for_chat(doggo_enum);
		if (available != _available)
		{
			available = _available;
			foreach(Image i in images)
			{
				i.color = available ? Color.white : Color.black;
			}

			GetComponent<UI_mouse_over>().enabled = false;
			GetComponent<Button>().enabled = false;
		}
	}
}
