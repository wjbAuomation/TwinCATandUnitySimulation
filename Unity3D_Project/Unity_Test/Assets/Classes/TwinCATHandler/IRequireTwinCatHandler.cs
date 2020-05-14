using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes.TwinCATHandler
{
    public interface IRequireTwinCatHandler
    {
        ITwinCatHandler TwinCatHandler { get; set; }
    }
}
