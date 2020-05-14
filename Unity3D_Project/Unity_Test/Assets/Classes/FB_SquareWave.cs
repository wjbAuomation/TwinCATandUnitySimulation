using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_SquareWave : MonoBehaviour, IRequireTwinCatHandler
{

    [SerializeField]
    //public TwinCAT_Handler _tcHandler;
    public string sPouName;
    public string sStateName;
    public string sPulseLengthName;
    public int iPulseLength;

    public ITwinCatHandler TwinCatHandler { get; set; }
    

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
        bState = TwinCatHandler.ReadBool(sPouName, sStateName);
        toggleColor(bState);
    }

    private void writePulseLenght()
    {
        if(iLastWrittenPulseLength != iPulseLength)
        {
            if(TwinCatHandler.WriteInt(sPouName, sPulseLengthName, iPulseLength))
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
