using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;

namespace InteractiveStory
{
    public class SkillEvents:List<Event>
    {
        public SkillEvents()
        {
            Add(new Event()
            {
                input = "input Upgrade " + swordSkill,
                condition = () => GameState.availableSkillPoints > 0,
                sequence = () => new Sequence() {
                    Inventory.instance.Hide(),
                    new Action("PlaySound(Spell2)"),
                },
                changeState = () => { GameState.availableSkillPoints--; GameState.swordSkill++; }
            });
            Add(new Event()
            {
                input = "input Upgrade " + magicSkill,
                condition = () => GameState.availableSkillPoints > 0,
                sequence = () => new Sequence() {
                    Inventory.instance.Hide(),
                    new Action("PlaySound(Spell2)"),
                },
                changeState = () => { GameState.availableSkillPoints--; GameState.magicSkill++; }
            });
            Add(new Event()
            {
                inputs = new List<string>(){
                    "input Upgrade " + magicSkill,
                    "input Upgrade " + alchemySkill,
                    "input Upgrade " + swordSkill,
                },
                condition = () => GameState.availableSkillPoints == 0,
                sequence = ()=>new Sequence() {
                    new Action("SetNarration(I don't have enough skill points)"),
                    new Action("ShowNarration()")
                },
            });
            Add(new Event()
            {
                input = "input Upgrade " + alchemySkill,
                condition = () => GameState.availableSkillPoints > 0,
                sequence = () => new Sequence() {
                    Inventory.instance.Hide(),
                    new Action("PlaySound(Spell2)"),
                },
                changeState = () => { GameState.availableSkillPoints--; GameState.alchemySkill++; }
            });
        }
    }
}
