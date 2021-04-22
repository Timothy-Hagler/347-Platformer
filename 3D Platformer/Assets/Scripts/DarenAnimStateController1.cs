using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarenAnimStateController1 : MonoBehaviour
{
    Animator animator;
    int isDanceHash;
    public bool isDance = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isDanceHash = Animator.StringToHash("isDance");

        if (isDance)
        {
            animator.SetBool(isDanceHash, true);
        }
    }
}
