using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    UnityEngine.Rendering.Universal.Light2D light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D> ();
    }

    public void toggle()
    {
        light.enabled = !light.enabled;
    }
}
