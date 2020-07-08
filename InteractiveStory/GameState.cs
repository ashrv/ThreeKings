using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class GameState
    {
        internal static string combinedWith;
        internal static string playerPosition;
        internal static int alchemySkill=1;
        internal static int magicSkill=1;
        internal static int swordSkill=1;
        internal static int availableSkillPoints = 0;
        internal static int lionheartQuestState;
        internal static int necroState;
        internal static bool revived;
        internal static bool necroHasBook;
        internal static bool learntFireball;
        internal static bool end;
        internal static bool knowsAboutHunger;

        static bool _lionheartDead;
        internal static bool lionheartDead
        {
            get { return _lionheartDead; }
            set { _lionheartDead = value;SecretEndingCheck();  }
        }
        static bool _emmiliaDead;
        internal static bool emmiliaDead
        {
            get { return _emmiliaDead; }
            set {  _emmiliaDead = value; SecretEndingCheck();}
        }
        static bool _necroDead;
        internal static bool necroDead
        {
            get { return _necroDead; }
            set {  _necroDead = value; SecretEndingCheck();}
        }

        static void SecretEndingCheck()
        {
            if (necroDead && emmiliaDead && lionheartDead) ;
        }

        internal static string skillPoints
        {
            get
            {
                return string.Format("Available: {0}", availableSkillPoints);
            }
        }
    }
}
