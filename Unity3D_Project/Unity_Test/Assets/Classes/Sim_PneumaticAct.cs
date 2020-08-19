using Assets.Classes.TwinCATHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim_PneumaticAct : SimulationObject
{
    // Start is called before the first frame update
    [SerializeField]
    // Inputs - operate actuator: extend or retract
    public string extendVarName;
    public string retractVarName;
    // Outputs - confirm actuator position extended or retracted
    public string extendedVarName;
    public string retractedVarName;

    private Animator animator;       
    private bool firstScan;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TwinCatHandler.ReadBool(pouName, extendVarName))
        {
            if (animator != null)
            {
                animator.SetTrigger("Extend");
                TwinCatHandler.WriteBool(pouName, retractedVarName, false);
            }
        }
        else
        {
            animator.ResetTrigger("Extend");
        }

        if (TwinCatHandler.ReadBool(pouName, retractVarName))
        {
            if (animator != null)
            {
                animator.SetTrigger("Retract");
                TwinCatHandler.WriteBool(pouName, extendedVarName, false);
            }
        }
        else
        {
            animator.ResetTrigger("Retract");
        }
    }

    void ExtendAnimationFinished()
    {
        TwinCatHandler.WriteBool(pouName, extendedVarName, true);
    }

    void RetractAnimationFinished()
    {
        TwinCatHandler.WriteBool(pouName, retractedVarName, true);
    }
}
