using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
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
            DoorBreak();
        }

       /*if (Input.GetButtonDown("Fire2") && doorsBroken == true)
        {
            DoorRepair();
        }*/

    }

    void DoorBreak()
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
