using System;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using UnityEditor;

public abstract class Repairable : MonoBehaviour
{

    public string Repair(float timeToRepair)
    {
        var tag = GUID.Generate().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair), tag);
        return tag;
    }

    public string Repair(float timeToRepair, Action callback)
    {
        var tag = GUID.Generate().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair, callback), tag);
        return tag;
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair)
    {
        yield return Timing.WaitForSeconds(timeToRepair);
        Locator.GetGauge().Subtract();
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair, Action callback)
    {
        yield return Timing.WaitForSeconds(timeToRepair);
        Locator.GetGauge().Subtract();
        callback();
    }
}