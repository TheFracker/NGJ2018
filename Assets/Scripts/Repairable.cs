using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class Repairable : MonoBehaviour
{
    public void Repair(float timeToRepair)
    {
        Timing.RunCoroutine(RepairRoutine(timeToRepair));
    }

    private IEnumerator<float> RepairRoutine(float timeToRepair)
    {
        yield return Timing.WaitForOneFrame;
    }
}