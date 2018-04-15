using System;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class Repairable : MonoBehaviour, IRepairProgress
{
    public float Progress { get; private set; }

    public string Repair(float timeToRepair)
    {
        var tag = Guid.NewGuid().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair), tag);
        return tag;
    }

    public string Repair(float timeToRepair, Action callback)
    {
        var tag = Guid.NewGuid().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair, callback), tag);
        return tag;
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair)
    {
        var startTime = Time.time;

        while (Time.time - startTime < timeToRepair)
        {
            Progress = (Time.time - startTime) / timeToRepair;
            print(Progress);
            yield return Timing.WaitForOneFrame;
        }
        Locator.GetGauge().Subtract();
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair, Action callback)
    {

        var startTime = Time.time;

        while (Time.time - startTime < timeToRepair)
        {
            Progress = (Time.time - startTime) / timeToRepair;
            print(Progress);
            yield return Timing.WaitForOneFrame;
        }
        Locator.GetGauge().Subtract();
        callback();
    }
}