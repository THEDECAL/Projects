using System;
using static System.Console;
using seven_wonders_of_the_world;

namespace task9
{
    class Program
    {
        static void Main()
        {
            the_pyramid_of_cheops wonder1 = new the_pyramid_of_cheops();
            wonder1.show();

            hanging_gardens_of_babylon wonder2 = new hanging_gardens_of_babylon();
            wonder2.show();

            statue_of_zeus wonder3 = new statue_of_zeus();
            wonder3.show();

            temple_of_artemis wonder4 = new temple_of_artemis();
            wonder4.show();

            mausoleum_in_halicarnassus wonder5 = new mausoleum_in_halicarnassus();
            wonder5.show();

            the_colossus_of_rhodes wonder6 = new the_colossus_of_rhodes();
            wonder6.show();

            alexandrian_lighthouse wonder7 = new alexandrian_lighthouse();
            wonder7.show();
        }
    }
}
