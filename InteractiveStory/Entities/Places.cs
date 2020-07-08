using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class Places:List<Place>
    {
        public static Places instance;

        public Places()
        {
            if (instance != null)
                throw new InvalidOperationException("Places has already been instantiated");
            instance = this;
            
            Add(new Place() { name = blacksmithshop });
            Add(new Place() { name = castle });
            Add(new Place() { name = courtyard });
            Add(new Place() { name = crossroads });
            Add(new Place() { name = dungeon });
            Add(new Place() { name = library });
            Add(new Place() { name = path });
            Add(new Place() { name = ruins });
            Add(new Place() { name = storage });


            get(crossroads).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=gate,
                    place=crossroads,
                },
                new Portal()
                {
                    name=westend,
                    place=crossroads,
                    pathway=true
                },
                new Portal()
                {
                    name=eastend,
                    place=crossroads,
                    pathway= true
                }
            };
            get(library).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=door,
                    other=get(crossroads).get(westend),
                    place=library,
                    icon="Cottage"
                }
            };

            get(blacksmithshop).portals = new List<Portal>(){
                new Portal()
                {
                    name=door,
                    place=blacksmithshop,
                    icon="Anvil"
                }
            };

            get(courtyard).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=gate,
                    place=courtyard
                },
                new Portal()
                {
                    name=exit,
                    other=get(crossroads).get(gate),
                    place=courtyard,
                    pathway=true
                }
            };

            get(storage).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=door,
                    place=storage
                }
            };

            get(castle).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=leftdoor,
                    place=castle,
                    other=get(blacksmithshop).get(door),
                },
                new Portal()
                {
                    name=gate,
                    other=get(courtyard).get(gate),
                    place=castle,
                    icon="Castle"
                },
                new Portal()
                {
                    name=rightdoor,
                    other=get(storage).get(door),
                    place=castle
                }
            };

            get(path).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=eastend,
                    other=get(crossroads).get(eastend),
                    place=path,
                    pathway=true
                },
                new Portal()
                {
                    name=westend,
                    place=path,
                    pathway=true
                }
            };

            get(ruins).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=exit,
                    other=get(path).get(westend),
                    place=ruins,
                    pathway=true,
                    icon="Dungeon"
                }
            };

            get(dungeon).portals = new List<Portal>()
            {
                new Portal()
                {
                    name=door,
                    place=dungeon,
                    other=get(ruins).get(exit)
                }
            };

            get(crossroads).get(westend).other = get(library).get(door);
            get(crossroads).get(eastend).other = get(path).get(eastend);
            get(crossroads).get(gate).other = get(courtyard).get(exit);
            get(blacksmithshop).get(door).other = get(castle).get(leftdoor);
            get(path).get(westend).other = get(ruins).get(exit);
            get(courtyard).get(gate).other = get(castle).get(gate);
            get(storage).get(door).other = get(castle).get(rightdoor);


        }

        public Place get(string name)
        {
            var place= this.FirstOrDefault(z => z.name == name);
            if (place == null)
                throw new NullReferenceException("There is a problem with place setups: " + name);
            return place;
        }
    }
}
