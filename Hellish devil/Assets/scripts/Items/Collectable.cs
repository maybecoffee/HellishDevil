using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Inv_Item CurrentItem;

    private SpriteRenderer spriteRenderer;
    public Rigidbody2D Rigidbody;

    private Player _player;
    private float pickDistance = 3, grabDistance = 1;
    [SerializeField] private int startDelay = 30;
    [SerializeField] private AudioClip grabSound;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        _player = FindObjectOfType<Player>();
    }

    public void Create(Inv_Item item, Vector2 startForce)
    {
        CurrentItem = item;
        spriteRenderer.sprite = item.Icon;

        Rigidbody.AddForce(startForce);
    }

    private void FixedUpdate()
    {
        
        if(startDelay > 0) { startDelay--; return; }

        if (Vector2.Distance(_player.transform.position, this.transform.position) < pickDistance)
        {
            Vector2 newPosition = Vector2.Lerp(_player.transform.position, this.transform.position, 0.9f);
            Rigidbody.MovePosition(newPosition);

                if (Vector2.Distance(_player.transform.position, this.transform.position) < grabDistance)
                        {
                            FindObjectOfType<Inv_Manager>().AddToInventory(CurrentItem);
                            SoundManager.Instance.PlaySound(grabSound);
                            Destroy(this.gameObject);
                        }
        }
    }
}
