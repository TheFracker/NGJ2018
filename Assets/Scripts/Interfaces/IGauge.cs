using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGauge
{
    int FailureCounter { get; }
    void Add();
    void Subtract();
}
