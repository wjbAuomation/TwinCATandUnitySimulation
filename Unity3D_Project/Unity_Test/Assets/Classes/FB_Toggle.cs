using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Toggle : MonoBehaviour, IRequireTwinCatHandler
{
    public ITwinCatHandler TwinCatHandler { get; set; }

    [SerializeField]
    public string sPouName;
    public string sButton;
    public string sState;

    private bool bState;
    private bool bLast;

    // Update is called once per frame
    void Update()
    {
        bState = TwinCatHandler.ReadBool(sPouName, sState);
        toggleColor(bState);
    }

    void OnMouseDown()
    {
        updateVariable(true);
    }

    void OnMouseUp()
    {
        updateVariable(false);
    }

    void updateVariable(bool variable)
    {
        if (variable != bLast)
        {
            TwinCatHandler.WriteBool(sPouName, sButton, variable);
            bLast = variable;
            Debug.Log("Writing button state:" + variable.ToString());
        }
    }

    private void toggleColor(bool state)
    {
        var objectRendered = gameObject.GetComponent<Renderer>();
        if (state)
        {
            if (objectRendered != null)
            {
                objectRendered.material.color = new Color(255, 0, 0);
            }
        }
        else
        {
            if (objectRendered != null)
            {
                objectRendered.material.color = new Color(0, 255, 0);
            }
        }
    }
}
