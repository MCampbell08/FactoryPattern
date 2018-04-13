using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPatternLib;
using FactoryPatternLib.Enums;

namespace FactoryPattern
{
    public class UserInterface
    {
        private LanguageFactory languageFactory = null;
        public void Run()
        {
            Console.Write("Hello user!\n" +
                "Please choose a language(WPF or HTML): " +
                "1 - WPF\n" +
                "2 - HTML\n");

            if (ChooseLanguage(Console.ReadLine().ToLower()) == Language.HTML)
                languageFactory = new HTML();
            else
                languageFactory = new WPF();

            ChooseComponents();
        }
        private Language ChooseLanguage(string input)
        {
            if (input == "wpf" || input == "1")
                return Language.WPF;
            else if (input == "html" || input == "2")
                return Language.HTML;

            return Language.HTML;
        }
        private void ChooseComponents()
        {
            string choice = "";
            bool done = false;

            while (!done) { 
                Component component = new Component();
                Console.Write("Please choose a component from this list: \n" +
                    "1 - Button\n" +
                    "2 - Circle\n" +
                    "3 - Image\n" +
                    "4 - Textbox" +
                    "0 - Finished Adding" +
                    "Your choice: ");

                choice = Console.ReadLine().ToLower();

                if (choice == "1" || choice == "button")
                    component = Component.BUTTON;
                else if (choice == "2" || choice == "circle")
                    component = Component.CIRCLE;
                else if (choice == "3" || choice == "image")
                    component = Component.IMAGE;
                else if (choice == "4" || choice == "textbox")
                    component = Component.TEXTBOX;
                else if (choice == "0" || choice == "finished adding")
                    component = Component.NULL;

                //Then we would prompt the user of the attributes of said component and add it to languageFactory.Components property.
            }
        }
    }
}
