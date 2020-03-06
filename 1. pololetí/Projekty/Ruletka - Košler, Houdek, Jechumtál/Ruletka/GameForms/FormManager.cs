using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruletka.GameForms
{
    public class FormManager
    {
        public static MenuForm MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new MenuForm();
                }
                return _mainMenu;
            }
        }
        private static MenuForm _mainMenu;
    }
}
