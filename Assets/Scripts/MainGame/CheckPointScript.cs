using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;
    private bool isActivated = false;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
        theSpriteRenderer.sprite = flagClosed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            theSpriteRenderer.sprite = flagOpen;
            isActivated = true;
        }
    }
}
