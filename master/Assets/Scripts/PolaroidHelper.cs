using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR

public class PolaroidHelper : MonoBehaviour
{
	[InspectorButton("Randomise")]
	public bool _;

	void Randomise()
	{
		Image[] images = GetComponentsInChildren<Image>();

		foreach(Image i in images)
		{
			if (i.name == "mask") continue;
			if (i.gameObject == this.gameObject) continue;

			UnityEditor.Undo.RecordObject(i.rectTransform, "transform");

			i.rectTransform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
			i.rectTransform.localPosition += new Vector3(Random.Range(-50,50), Random.Range(-50, 50), Random.Range(-50, 50));
		}
	}
}

#endif