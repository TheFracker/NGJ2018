using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour, IBreakable
{
    public List<DoorCollider> doors = new List<DoorCollider>();
    public bool doorsBroken = false;

    

    // Use this for initialization
    void Start()
    {
        doorsBroken = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Break();
        }

    }

    public void Break()
    {
        print("doors broken");
        foreach (var door in doors)
        {
            door.broken = true;
        }
        doorsBroken = true;
    }

    public void DoorRepair()
    {
        print("doors repaired");
        foreach (var door in doors)
        {
            door.broken = false;
        }
        doorsBroken = false;

    }

}
