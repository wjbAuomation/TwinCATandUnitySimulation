using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes.TwinCATHandler
{
    public class SimulationObject : MonoBehaviour, IRequireTwinCatHandler
    {
        public ITwinCatHandler TwinCatHandler { get; set; }

        [SerializeField]
        public string pouName;
        public string varName;

    }
}
