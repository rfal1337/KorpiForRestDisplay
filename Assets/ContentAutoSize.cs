using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentAutoSize : MonoBehaviour {

    int childCount;
    float spacing;
    float imageWidth;
    GameObject child;
    int totalExpansion;
    RectTransform rt;

	// Use this for initialization
	void Start () {
        //FIX!!!@@
        rt = gameObject.GetComponent<RectTransform>();
        childCount = Mathf.RoundToInt(gameObject.transform.childCount / 5 + 1);
        child = gameObject.transform.GetChild(0).gameObject;
        imageWidth = child.GetComponent<RectTransform>().rect.height / 2;
        spacing = GetComponent<GridLayoutGroup>().spacing.y;
        totalExpansion = Mathf.RoundToInt(spacing * imageWidth * childCount);
        Debug.Log(totalExpansion);
        rt.offsetMin = new Vector2(rt.offsetMin.x, 300 - totalExpansion);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
