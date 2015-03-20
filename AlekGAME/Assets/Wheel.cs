using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CircleCollider2D))]
public class Wheel : MonoBehaviour
{
    protected internal bool isFlying = false;

    protected virtual void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isFlying = true;
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isFlying = false;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isFlying = false;
        }
    }
}
