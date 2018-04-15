using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Repairable, IBreakable
{
    public List<DoorCollider> Doors = new List<DoorCollider>();
    public bool DoorsBroken;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        DoorsBroken = false;
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Break();
    }

    public void Break()
    {
        foreach (var door in Doors)
        {
            door.Broken = true;
        }
        DoorsBroken = true;
        
    }

    public void DoorRepair()
    {
        foreach (var door in Doors)
        {
            door.Broken = false;
        }
        DoorsBroken = false;
        anim.StopPlayback();
    }
}
