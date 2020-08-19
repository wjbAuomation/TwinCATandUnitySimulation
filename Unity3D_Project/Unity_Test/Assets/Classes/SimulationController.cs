using Assets.Classes.TwinCATHandler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        InitializeTwinCATInterfaces();
    }

    private void InitializeTwinCATInterfaces()
    {
        // initialize new TwinCAT interface handler and inject it into the required objects
        ITwinCatHandler twinCatHandler = new TwinCAT_Handler();
        // initialize connection
        twinCatHandler.InitializeConnection();

        // Find all elements that require TwinCat handler
        var elements = FindObjectsOfType<SimulationObject>().OfType<IRequireTwinCatHandler>();
        foreach(var element in elements)
        {
            element.TwinCatHandler = twinCatHandler;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
