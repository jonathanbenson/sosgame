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
            // Keep track of how far into the replay
            pos = 0;
        }

        public void Parse(string fileName)
        {
            // Parse all the move entry JSON objects from the previous game
            string jsonText = File.ReadAllText(fileName, Encoding.UTF8);

            moveEntries = JsonSerializer.Deserialize<List<MoveEntry>>(jsonText);
        }

        public MoveEntry GetNextMoveEntry()
        {
            // return the current move entry and advance the position
            return moveEntries[pos++];
        }

        public bool AtEnd()
        {
            // If we are at the last move entry, then return true
            // else false
            if (pos == moveEntries.Count - 1)
                return true;

            return false;
        }
    }
}
