using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public enum PalletStatus
    {
        [Description("Zaskladněno")]
        Stored = 0,
        [Description("Vyskladněno")]
        Dispatched = 1,
        [Description("V dopravě")]
        InTransit = 2
    }
}
