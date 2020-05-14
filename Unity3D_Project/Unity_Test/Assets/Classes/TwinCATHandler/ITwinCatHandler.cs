using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes.TwinCATHandler
{
    public interface ITwinCatHandler
    {
        void InitializeConnection();
        bool ReadBool(string pou, string variableName);
        int ReadInt(string pou, string variableName);
        bool WriteInt(string pou, string variableName, int value);
        bool WriteBool(string pou, string variableName, bool value);
    }
}
