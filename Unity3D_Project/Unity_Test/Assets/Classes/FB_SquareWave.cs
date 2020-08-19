using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_SquareWave : SimulationObject
{

    [SerializeField]
    public string sPulseLengthName;
    public int iPulseLength;       

    private int iLastWrittenPulseLength;
    private bool bState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        readState();
        writePulseLenght();
    }

    private void readState()
    {
        bState = TwinCatHandler.ReadBool(pouName, varName);
        toggleColor(bState);
    }

    private void writePulseLenght()
    {
        if(iLastWrittenPulseLength != iPulseLength)
        {
            if(TwinCatHandler.WriteInt(pouName, sPulseLengthName, iPulseLength))
            {
                iLastWrittenPulseLength = iPulseLength;
            }
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
