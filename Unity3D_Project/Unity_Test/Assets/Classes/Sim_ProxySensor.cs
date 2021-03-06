﻿using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim_ProxySensor : SimulationObject
{
    private bool bLastState;
    private bool bSensorState;
    private bool firstScan;

    public float sensorRange = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        firstScan = true;
    }

    // Update is called once per frame
    void Update()
    {
        IR_Ray();
    }

    private void IR_Ray()
    {
        var direction = this.transform.TransformDirection(Vector3.forward);

        Transform trans = this.transform;
        Transform child = trans.Find("Indicator");

        //leave the function if parent transform does not contain "Indicator" child
        if (child == null) return;

        var objectRendered = child.GetComponent<Renderer>();

        RaycastHit hit;

        Debug.DrawRay(this.transform.position, direction);

        if (Physics.Raycast(this.transform.position, direction, out hit, sensorRange))
        {
            objectRendered.material.color = new Color(0, 255, 0);
            if (!bLastState)
            {
                TwinCatHandler.WriteBool(pouName, varName, true);
                bLastState = true;
            }
        }
        else
        {
            objectRendered.material.color = new Color(255, 0, 0);
            if (bLastState || firstScan)
            {
                TwinCatHandler.WriteBool(pouName, varName, false);
                bLastState = false;
                firstScan = false;
            }
        }
    }
}
