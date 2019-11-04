using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyUtil;

public class EnemyController : MonoBehaviour
{
    [Header("Dinesh Balakrishnan, Last Edited 11/02/2019")]
    // Shows Animation State for documentations
    public EnemyAnimState animState;
    // Takes care of changing the animation clips appropriately
    public Animator enemyAnim;
    // Takes care of opposite direction animations/manipulations of sprite
    public SpriteRenderer enemyRenderer;
    // Arrow That travels right
    public GameObject ArrowRight;
    // Arrow that travels left
    public GameObject ArrowLeft;
    // Spawns Arrows that go right
    public Transform ArrowSpawnR;
    // Spawns Arrows that go left
    public Transform ArrowSpawnL;
    public GameObject PlayerDetector;
    // Rate of the arrows fired
    public float fireRate = 0.5f;
    // For calculating the rate
    //private float counter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer.flipX = true;
        animState = EnemyAnimState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        // counter += Time.deltaTime;
        //
        // if (Input.GetButton("Fire1") && counter > fireRate)
        // {
        //     // Instantiate the arrows
        //    Instantiate(ArrowRight, ArrowSpawnR.position, ArrowRight.transform.rotation);
        //    Instantiate(ArrowLeft, ArrowSpawnL.position, ArrowLeft.transform.rotation);
        //     counter = 0.0f;
        // }
    }
    private void LeftOnTriggerEnter2D(Collider2D PlayerDetector)
    {
        enemyRenderer.flipX = true;
        animState = EnemyAnimState.ATTACK;
        enemyAnim.SetInteger("AnimState", (int)EnemyAnimState.ATTACK);
        Instantiate(ArrowLeft, ArrowSpawnL.position, ArrowLeft.transform.rotation);
        Destroy(ArrowLeft.gameObject);
    }

    private void RightOnTriggerEnter2D(Collider2D PlayerDetector)
    {
        enemyRenderer.flipX = false;
        animState = EnemyAnimState.ATTACK;
        enemyAnim.SetInteger("AnimState", (int)EnemyAnimState.ATTACK);
        Instantiate(ArrowRight, ArrowSpawnR.position, ArrowRight.transform.rotation);
        Destroy(ArrowLeft.gameObject);
    }
}
