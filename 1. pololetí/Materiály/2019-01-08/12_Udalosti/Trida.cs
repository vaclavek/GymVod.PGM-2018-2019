using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Udalosti
{
    public class Trida
    {
        public event EventHandler Progress;

        public void Spocitej()
        {
            // počítání něčeho složitého
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(1000);
                if (i % 10 == 0)
                {
                    Progress.Invoke(i, null);
                }
            }
        }
    }
}
