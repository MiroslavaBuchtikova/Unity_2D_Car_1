using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    
    SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite newSprite;
    private Sprite _defaultSprite;

    private void Start()
    {
        _spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }

    public void SpriteChange()
    {
        StartCoroutine(ChangeIcons());
    }

    private IEnumerator ChangeIcons()
    {
        ChangeSprite();
        yield return new WaitForSeconds(5);
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        var sprite = _spriteRenderer.sprite == _defaultSprite ? newSprite : _defaultSprite;
        _spriteRenderer.sprite = sprite;
    }
    
}
