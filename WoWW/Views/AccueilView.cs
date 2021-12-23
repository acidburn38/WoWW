using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    internal class AccueilView
    {
        public static void AccueilMenu()
        {
            Console.WriteLine("#     #                                                 #     #                  #     #                #####    #   ");
            Console.WriteLine("#  #  #  ####  #####  #      #####      ####  ######    #  #  #   ##   #####     #  #  #   ##   #####  #     #  ##   ");
            Console.WriteLine("#  #  #  ####  #####  #      #####      ####  ######    #  #  #   ##   #####     #  #  #   ##   #####  #     #  ##   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #         #  #  #  #  #  #    #    #  #  #  #  #  #    #       # # #   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #         #  #  #  #  #  #    #    #  #  #  #  #  #    #       # # #   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #####     #  #  # #    # #    #    #  #  # #    # #    #  #####    #   ");
            Console.WriteLine("#  #  # #    # #####  #      #    #    #    # #         #  #  # ###### #####     #  #  # ###### #    # #         #   ");
            Console.WriteLine("#  #  # #    # #   #  #      #    #    #    # #         #  #  # #    # #   #     #  #  # #    # #    # #         #   ");
            Console.WriteLine("## ##   ####  #    # ###### #####      ####  #          ## ##  #    # #    #     ## ##  #    # #####  ####### #####  ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Que faire ?");
            Console.WriteLine("1. Créer un compte Player ?");
            Console.WriteLine("2. Se connecter");
            Console.ReadLine();
        }
    }
}
