using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog_ImageStatus : MonoBehaviour
{
	public Doggo doggo_enum;
	public bool available = true;

	public List<Image> images;

	void Start()
    {
		System.Enum.TryParse(name, out doggo_enum);

		images.AddRange(GetComponentsInChildren<Image>());
		images.RemoveAll(i => i.name == "mask");
		images.RemoveAll(i => i.gameObject == this.gameObject);
	}

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
		}
	}
}
