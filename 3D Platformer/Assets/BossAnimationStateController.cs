using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationStateController : MonoBehaviour
{
    Animator animator;
    int isFallingHash;
    int isSpinningHash;
    public AttackBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isFallingHash = Animator.StringToHash("isFalling");
        isSpinningHash = Animator.StringToHash("isSpinning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isFalling = animator.GetBool(isFallingHash);
        bool isSpinning = animator.GetBool(isSpinningHash);
        int health = boss.health;

        if (health == 2)
        {
            isSpinning = true;
        }

        if (isFalling)
        {
            animator.SetBool(isFallingHash, true);
        }

        if (!isFalling)
        {
            animator.SetBool(isFallingHash, false);
        }

        if (isSpinning)
        {
            animator.SetBool(isSpinningHash, true);
        }

        if (!isSpinning)
        {
            animator.SetBool(isSpinningHash, false);
        }
    }
}
