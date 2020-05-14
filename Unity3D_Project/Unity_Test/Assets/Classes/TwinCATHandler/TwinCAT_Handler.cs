using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwinCAT.Ads;
using Assets.Classes.TwinCATHandler;

public class TwinCAT_Handler : ITwinCatHandler
{
    private TcAdsClient _tcClient = null;

    public void InitializeConnection()
    {
        _tcClient = new TcAdsClient();
        _tcClient.Connect("172.20.136.133.1.1", 851);
        if (_tcClient.IsConnected)
        {
            Debug.Log("Twin CAT ADS port connected");
        }
        else
        {
            Debug.LogError("ADS Connection failed");
        }
    }

    public bool ReadBool(string pou, string variableName)
    {
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            var readVariable = _tcClient.ReadAny(hVar, typeof(bool));
            _tcClient.DeleteVariableHandle(hVar);
            return bool.Parse(readVariable.ToString());
        }
        catch (AdsErrorException)
        {
            Debug.LogError("TC Read Error - Bool");
            return false;
        }
    }

    public int ReadInt(string pou, string variableName)
    {
        int value = 0;
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            value = (int)_tcClient.ReadAny(hVar, typeof(int));
            _tcClient.DeleteVariableHandle(hVar);
        }
        catch (AdsErrorException)
        {
            Debug.LogError("TC Read Error - Int");            
        }
        return (int)value;
    }

    public bool WriteBool(string pou, string variableName, bool value)
    {
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            _tcClient.WriteAny(hVar, value);
            _tcClient.DeleteVariableHandle(hVar);
            return true;
        }
        catch (AdsErrorException exp)
        {
            Debug.LogError("TC Write Error - Bool" + exp.Message);
        }
        return false;
    }

    public bool WriteInt(string pou, string variableName, int value)
    {
        try
        {
            var hVar = _tcClient.CreateVariableHandle(pou + "." + variableName);
            _tcClient.WriteAny(hVar, value);
            _tcClient.DeleteVariableHandle(hVar);
            return true;
        }
        catch (AdsErrorException exp)
        {
            Debug.LogError("TC Write Error - Int" + exp.Message);
        }
        return false;
    }
}
