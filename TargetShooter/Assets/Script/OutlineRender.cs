using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(OutlineRender),PostProcessEvent.AfterStack, "Outline")]
public sealed class OutlineRender : PostProcessEffectSettings
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
