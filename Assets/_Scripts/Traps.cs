using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrapPanel;
public class Traps : MonoBehaviour
{
    [Header("Dinesh Balakrishnan Last edit 11/02/2019")]
    public bool PlayerCollision;
    public SpriteRenderer trapderer;
    public TrapState trapsState;
    public Animator tranim;
    // Start is called before the first frame update
    void Start()
    {
        trapsState = TrapState.NotActive;
    }

    // Update is called once per frame
    // Runs once
    // When player collides with trap it will activate
    // and destroy 
    void OnTriggerEnter2D(Collider2D Player)
    {
        trapsState = TrapState.Active;
        tranim.SetInteger("TrapState", (int)TrapState.Active);
    }
}
