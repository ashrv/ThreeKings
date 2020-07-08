using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;

namespace InteractiveStory
{
    class PotionEvents : List<Event>
    {
        public PotionEvents()
        {
            PurpleEvents();
            BlueEvents();
            GreenEvents();
            FirstCombo();
        }

        private void FirstCombo()
        {
            Add(new Event()
            {
                input = "input Combine " + greenPotion,
                condition = () => GameState.combinedWith == null,
                changeState = () => GameState.combinedWith = greenPotion,
             
            });
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith == null,
                changeState = () => GameState.combinedWith = bluePotion,
                
            });
            Add(new Event()
            {
                input = "input Combine " + purplePotion,
                condition = () => GameState.combinedWith == null && GameState.alchemySkill >= 3,
                changeState = () => GameState.combinedWith = purplePotion,
             
            });
        }

        private void GreenEvents()
        {
            Add(new Event()
            {
                input = "input Combine " + greenPotion,
                condition = () => GameState.combinedWith == bluePotion && !Inventory.instance.Contains(tom, redPotion),
                sequence = () => new Sequence()
                    {
                        new Action("PlaySound(Potion)"),
                        new Action("AddToList({0},{1})", redPotion,redPotionDescription),
                        new PotionTargets(),
                        new Action("RemoveFromList({0})", purplePotion),
                        new Action("RemoveFromList({0})", bluePotion),
                        new Action("RemoveFromList({0})", greenPotion),
                    },
                changeState = () => { 
                    GameState.combinedWith = null; 
                    Inventory.instance.Add(tom, redPotion, redPotionDescription);
                    Inventory.instance.Remove(tom, bluePotion);
                    Inventory.instance.Remove(tom, greenPotion);
                    Inventory.instance.Remove(tom, purplePotion);
                },
                
            });
            Add(new Event()
            {
                input = "input Combine " + greenPotion,
                condition = () => GameState.combinedWith != null && GameState.combinedWith != bluePotion,
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(Didn't work!)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
            Add(new Event()
            {
                input = "input Combine " + greenPotion,
                condition = () => GameState.combinedWith == bluePotion && Inventory.instance.Contains(tom, redPotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(I already have a vial of red potion)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
        }

        private void BlueEvents()
        {
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith == purplePotion && !Inventory.instance.Contains(tom, greenPotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("PlaySound(Potion)"),
                        new Action("AddToList({0},{1})", greenPotion,greenPotionDescription),
                        new Action("RemoveFromList({0})", bluePotion)
                    },
                changeState = () =>
                {
                    GameState.combinedWith = null; 
                    Inventory.instance.Add(tom, greenPotion, greenPotionDescription);
                    Inventory.instance.Remove(tom, bluePotion);
                },
                
            });
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith == greenPotion && !Inventory.instance.Contains(tom, redPotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("PlaySound(Potion)"),
                        new Action("AddToList({0}, {1})", redPotion,redPotionDescription ),
                        new PotionTargets(),
                        new Action("RemoveFromList({0})", purplePotion),
                        new Action("RemoveFromList({0})", bluePotion),
                        new Action("RemoveFromList({0})", greenPotion),
                    },
                changeState = () => { GameState.combinedWith = null; 
                    Inventory.instance.Add(tom, redPotion, redPotionDescription);
                    Inventory.instance.Remove(tom, bluePotion);
                    Inventory.instance.Remove(tom, greenPotion);
                    Inventory.instance.Remove(tom, purplePotion);
                },
                
            });
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith ==bluePotion,
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(Didn't work!)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith == purplePotion && Inventory.instance.Contains(tom, greenPotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(I already have a vial of green potion)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
            Add(new Event()
            {
                input = "input Combine " + bluePotion,
                condition = () => GameState.combinedWith == greenPotion && Inventory.instance.Contains(tom, redPotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(I already have a vial of red potion)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
        }

        private void PurpleEvents()
        {
            Add(new Event()
            {
                input = "input Combine " + purplePotion,
                condition = () => GameState.combinedWith == bluePotion && !Inventory.instance.Contains(tom, greenPotion),
                sequence = () => new Sequence()
                    {
                        new Action("PlaySound(Potion)"),
                        new Action("AddToList({0},{1})", greenPotion,greenPotionDescription),
                        new Action("RemoveFromList({0})", bluePotion)
                    },
                changeState = () => { 
                    GameState.combinedWith = null;
                    Inventory.instance.Add(tom, greenPotion, greenPotionDescription);
                    Inventory.instance.Remove(tom, bluePotion);
                },

            });
            Add(new Event()
            {
                input = "input Combine " + purplePotion,
                condition = () => GameState.combinedWith == purplePotion && !Inventory.instance.Contains(tom, bluePotion),
                sequence = () => new Sequence()
                    {
                        new Action("PlaySound(Potion)"),
                        new Action("AddToList({0},{1})", bluePotion, bluePotionDescription),
                    },
                changeState = () => { GameState.combinedWith = null; Inventory.instance.Add(tom, bluePotion, bluePotionDescription); },
                
            });
            Add(new Event()
            {
                input = "input Combine " + purplePotion,
                condition = () => GameState.combinedWith ==greenPotion,
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(Didn't work!)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });
            Add(new Event()
            {
                input = "input Combine " + purplePotion,
                condition = () => GameState.combinedWith == purplePotion && Inventory.instance.Contains(tom, bluePotion),
                sequence = ()=>new Sequence()
                    {
                        new Action("SetNarration(I already have a vial of blue potion)"),
                        new Action("ShowNarration()"),
                    },
                changeState = () => GameState.combinedWith = null,
                
            });

        }
    }
}
