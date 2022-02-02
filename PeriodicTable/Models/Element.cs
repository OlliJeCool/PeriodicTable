using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable;
public class Element
{
    //properties for the element object
    #region Properties
    public int PN { get; set; }
    public string Short { get; set; } = string.Empty;
    public string EnName { get; set; } = string.Empty;
    public string CzName { get; set; } = string.Empty;
    public string lName { get; set; } = string.Empty;

    #endregion

    public override string ToString()
    {
        return $" ~ {this.PN}, Short: {this.Short}; EN: {this.EnName}, CZ: {this.CzName}, LAT: {this.lName}";
    }
}
