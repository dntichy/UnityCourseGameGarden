using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// Player statistics
    /// </summary>
    public static class PlayerStats
    {
        private static int level = 1;
        private static int killedCreatures = 0;
        private static DateTime gameStart;

        public static int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }


        public static DateTime GameStart
        {
            get
            {
                return gameStart;
            }
            set
            {
                gameStart = value;
            }
        }


        public static int KilledCreatures
        {
            get
            {
                return killedCreatures;
            }
            set
            {
                killedCreatures = value;
            }
        }

    }
}
