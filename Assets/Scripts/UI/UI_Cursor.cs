using UnityEngine;
using System.Collections;

public class UI_Cursor : MonoBehaviour {

    public float gotoX;
    public float gotoY;
    private RectTransform ThisRect;
    private float slideFactor = 5;

	// Use this for initialization
	void Start () {
        ThisRect = GetComponent<RectTransform>();
        if (ThisRect == null) return;

        gotoX = ThisRect.rect.x;
        gotoY = ThisRect.rect.y;
    }
	
	// Update is called once per frame
	void Update () {
        var ThisRect = GetComponent<RectTransform>();
        if (ThisRect == null) return;

        var newPosition = new Vector3((ThisRect.position.x * slideFactor + gotoX)/(slideFactor+1), (ThisRect.position.y * slideFactor + gotoY) / (slideFactor + 1), ThisRect.position.z);
        ThisRect.position = newPosition;
    }

    public void UpdatePosition(RectTransform goToObject)
    {
        if (goToObject == null) return;

        gotoX = goToObject.rect.xMin - (goToObject.rect.width / 2);
        gotoY = goToObject.position.y + 0.2f;
    }
}
