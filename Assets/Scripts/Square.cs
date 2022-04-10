using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    [field: SerializeField] public int Index { get; private set; }

    public bool isOccupied=false;

    private Sprite _oSprite;
    private Sprite _xSprite;
    private Image _image; 

    private void OnEnable()
    {
        Sprite[] spriteSheet = Resources.LoadAll<Sprite>("Sprite-0001-Sheet");
        Debug.Log(spriteSheet.Length);
        _image = GetComponent<Image>();
        _oSprite = spriteSheet[3];
        _xSprite = spriteSheet[2];
    }

    public void MarkTile(int sign)
    {
        isOccupied = true;
        if(sign==0)
            _image.sprite = _oSprite;

        else if(sign==1)
            _image.sprite = _xSprite;

    }

}
