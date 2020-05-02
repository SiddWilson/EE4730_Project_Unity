using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationController : MonoBehaviour
{
    Animation test = new Animation();
    // Start is called before the first frame update
    void Start()
    {
        AnimationClip testClip = new AnimationClip();
        if (testClip.isLooping) print("WARNING: CLIP SET TO LOOP");
        testClip.ClearCurves();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
