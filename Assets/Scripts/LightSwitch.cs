using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IBreakable
{
    [SerializeField]
    private List<Light> lights = new List<Light>();

    void Awake()
    {
        foreach (var light in lights)
        {
            light.enabled = true;
        }
    }

    public void Break()
    {
        foreach (var light in lights)
        {
            light.enabled = false;
        }
        Locator.GetGauge().Add();
    }
}
