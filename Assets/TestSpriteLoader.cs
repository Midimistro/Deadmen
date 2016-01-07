using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSpriteLoader : MonoBehaviour
{
    private string spritePiece = "Game_Assets/spritesheets/Items/SpriteSheet_Blade01_FallenSword";

    // Use this for initialization
    void Start() {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var LoadedSprite = Resources.LoadAll<Sprite>(spritePiece);
        spriteRenderer.sprite = LoadedSprite[1];
        Debug.Log(LoadedSprite[0] + " : " + LoadedSprite[1]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
