using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroogeAnimStateController : MonoBehaviour
{
    Animator animator;
    int isSadHash;
    public bool isSad = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isSadHash = Animator.StringToHash("isSad");

        if (isSad)
        {
            animator.SetBool(isSadHash, true);
        }
    }
}
