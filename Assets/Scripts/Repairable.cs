using System;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class Repairable : MonoBehaviour, IRepairProgress
{
    public float Progress { get; private set; }

    public string Repair(float timeToRepair, bool repair = true)
    {
        var tag = Guid.NewGuid().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair, repair), tag);
        return tag;
    }

    public string Repair(float timeToRepair, Action callback, bool repair = true)
    {
        var tag = Guid.NewGuid().ToString();
        Timing.RunCoroutine(RepairRoutine(timeToRepair, callback, repair), tag);
        return tag;
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair, bool repair)
    {
        var startTime = Time.time;

        while (Time.time - startTime < timeToRepair)
        {
            Progress = (Time.time - startTime) / timeToRepair;
            print(Progress);
            yield return Timing.WaitForOneFrame;
        }
        if (repair)
            Locator.GetGauge().Subtract();
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair, Action callback, bool repair)
    {

        var startTime = Time.time;

        while (Time.time - startTime < timeToRepair)
        {
            Progress = (Time.time - startTime) / timeToRepair;
            print(Progress);
            yield return Timing.WaitForOneFrame;
        }
        if (repair)
            Locator.GetGauge().Subtract();
        callback();
    }
}