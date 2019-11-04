using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Player)
    {
        Destroy(this.gameObject);
    }
}
