using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite endSprite;
    void Update()
    {
        if (spriteRenderer.sprite = endSprite)
        {
            StartCoroutine(DestroyObject());
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
