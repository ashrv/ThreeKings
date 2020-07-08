using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using InteractiveStory.Dialogs;

namespace InteractiveStory.Events
{
    public class TalkEvents:List<Event>
    {
        public TalkEvents()
        {
            Add(new Event()
            {
                input = "input Talk " + emmilia,
                sequence = () => new EmmiliaDialog().Generate(emmilia),
                condition = () => !GameState.lionheartDead || !GameState.necroDead
            });
            Add(new Event()
            {
                input = "input Talk " + emmilia,
                sequence = () => new EmmiliaDialog2().Generate(emmilia).Add(new Sequence() { new Action("SetExpression({0}, surprised)", emmilia) }),
                condition = () => GameState.lionheartDead && GameState.necroDead
            });
            Add(new Event()
            {
                inputs = new List<string>()
                    {
                        "input Talk "+ bob,
                    },
                sequence = () => new BobDialog().Generate(bob)
            });
            Add(new Event()
            {
                input = "input Talk " + blacksmith,
                sequence = () => new BlacksmithDialog().Generate(blacksmith)
            });
            Add(new Event()
            {
                input = "input Talk " + lionheart,
                sequence = () => new LionheartDialog().Generate(lionheart),
                condition=()=>GameState.lionheartQuestState<2,
          
            });
            Add(new Event()
            {
                input = "input Talk " + lionheart,
                sequence = () => new LionheartDialog2().Generate(lionheart),
                condition = () => GameState.lionheartQuestState >= 2&&GameState.lionheartQuestState<5,
            });
            Add(new Event()
            {
                input = "input Talk " + lionheart,
                sequence = () => new LionheartDialog3().Generate(lionheart),
                condition = () =>  GameState.lionheartQuestState == 5,
            });
            Add(new Event()
            {
                inputs=new List<string>() { "input Talk " + guard1, "input Talk " + guard2 },
                sequence = () => new Sequence(){
                    new GuardDialog().Generate(guard1),
                    new Action("EnableEffect({0}, diamond)", crossroads+".Gate")
                }
            });
            Add(new Event()
            {
                input = "input Talk " + bandit,
                sequence = () => new BanditDialog().Generate(bandit)
            });
            Add(new Event()
            {
                input = "input Talk " + necromancer,
                sequence = () => new NecroDialog().Generate(necromancer),
                condition=()=>GameState.necroState==0,
              
            });
            Add(new Event()
            {
                input = "input Talk " + necromancer,
                sequence = () => new NecroDialog2().Generate(necromancer),
                condition = () => GameState.necroState<4&&GameState.necroState>0
            });
            Add(new Event()
            {
                input = "input Talk " + necromancer,
                sequence = () => new NecroDialog3().Generate(necromancer),
                condition = () => GameState.necroState == 4
            });
            Add(new Event()
            {
                input = "input Talk " + grandma,
                sequence = () => new GrandmaDialog().Generate(grandma),
            });
        }
        
    }
}
