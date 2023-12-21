using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    /// <summary>
    /// Code that is ran when a cipher button is clicked
    /// </summary>
    public delegate void CipherMethod();

    public delegate void OutputMethod(string output);

    public delegate void PatternClicked(string pattern);

    public enum ComparisonResult
    {
        Greater,
        Lesser,
        Equal
    }
}
