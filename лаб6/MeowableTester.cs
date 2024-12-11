using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    internal class MeowableTester
    {
        // Метод для вызова мяуканья у всех объектов, реализующих IMeowable
        public static void MakeMeow(IMeower[] meowables)
        {
            foreach (var meowable in meowables)
            {
                meowable.Meow();
            }
        }
    }
}
