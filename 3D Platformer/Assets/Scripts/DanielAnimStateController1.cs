using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielAnimStateController1 : MonoBehaviour
{
    Animator animator;
    int isDancingHash;
    public bool isDance = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isDancingHash = Animator.StringToHash("isDance");

        if (isDance)
        {
            animator.SetBool(isDancingHash, true);
        }
    }
}
