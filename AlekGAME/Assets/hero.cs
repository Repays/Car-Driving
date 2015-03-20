using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class hero : MonoBehaviour 
{
    [SerializeField]
    protected float speed = 1;

    protected virtual void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,rigidbody2D.velocity.y);
    }

}
