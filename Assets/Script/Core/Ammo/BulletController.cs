using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BaseAmmo ammoStat;
    public BaseAmmo AmmoStat { get; set; }

    private BoxCollider2D boxCollider2D;
    private BoxCollider2D boxTrigger;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody2D;
    private void Start()
    {
        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        boxTrigger = gameObject.AddComponent<BoxCollider2D>();
        boxTrigger.isTrigger = true;
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();

        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Weapons/BulletHead/circle bullet");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BulletController: OnTriggerEnter2D");
    }
}
