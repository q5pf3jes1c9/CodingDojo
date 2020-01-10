using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Frame
    {
        internal List<int> PinsRolled { get; } = new List<int>();
        internal int Score => PinsRolled.Sum();

        internal bool IsScoreFinished()
        {
            if (HasExact3Roles())
            {
                return true;
            }
            return HasExact2Roles() && IsNormalFrame();
        }
        
        internal bool IsNormalFrame() => Score < 10;
        internal bool HasExact2Roles() => PinsRolled.Count == 2;
        private bool HasExact3Roles() => PinsRolled.Count == 3;

    }
}