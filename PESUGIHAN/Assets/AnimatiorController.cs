using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiorController : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    int isRunnerHash;

    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim);
        isRunnerHash = Animator.StringToHash("isRun");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunner = anim.GetBool(isRunnerHash);
        bool pressButton = Input.GetKey("w");
        if (!isRunner && pressButton) {
            anim.SetBool(isRunnerHash, true);
        }

        if (isRunner && !pressButton) {
            anim.SetBool(isRunnerHash, false);
        }
    }
}
