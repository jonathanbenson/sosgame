using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class Replay
    {
        private int pos;

        private List<MoveEntry>? moveEntries;

        public Replay()
        {
            pos = 0;
        }

        public void Parse(string fileName)
        {
            string jsonText = File.ReadAllText(fileName, Encoding.UTF8);

            moveEntries = JsonSerializer.Deserialize<List<MoveEntry>>(jsonText);
        }

        public MoveEntry GetNextMoveEntry()
        {
            return moveEntries[pos++];
        }

        public bool AtEnd()
        {
            if (pos == moveEntries.Count - 1)
                return true;

            return false;
        }
    }
}
