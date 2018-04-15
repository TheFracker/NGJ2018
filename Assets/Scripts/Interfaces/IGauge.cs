using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGauge
{
    int FailureCounter { get; }
    float FailurePercentage { get; }
    int MaxFailures { get; }
    void Add();
    void Subtract();
}
