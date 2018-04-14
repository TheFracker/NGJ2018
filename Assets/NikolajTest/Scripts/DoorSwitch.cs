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
        if (Input.GetButtonDown("Fire2") && doorsBroken == false)
        {
            Break();
        }

       /*if (Input.GetButtonDown("Fire2") && doorsBroken == true)
        {
            DoorRepair();
        }*/

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

    void DoorRepair()
    {
        print("doors repaired");
        foreach (var door in doors)
        {
            door.broken = false;
        }
        doorsBroken = false;

    }

}
