using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {

    public Sprite[] bg;
    public GameObject bg1;
    public GameObject bg2;
    public Image bg3;
    public Image bg4;
    // Use this for initialization

	public void Changebg()
    {
        Debug.Log("Entra");
        Sprite chosenbg = bg[Random.Range(0,bg.Length)];
        bg1.GetComponent<SpriteRenderer>().sprite = chosenbg;
        bg2.GetComponent<SpriteRenderer>().sprite = chosenbg;
        bg3.sprite = chosenbg;
        bg4.sprite = chosenbg;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
