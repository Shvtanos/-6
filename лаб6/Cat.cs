using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    internal class Cat : IMeower
    {
        // Имя кота
        public string Name { get; private set; }
        // Счетчик мяуканий
        private int meowCount;

        // Конструктор для создания кота с именем
        public Cat(string name)
        {
            Name = name;
            meowCount = 0;
        }

        // Переопределение метода ToString для текстового представления кота
        public override string ToString()
        {
            return $"кот: {Name}";
        }

        // Метод для мяуканья кота
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
            meowCount++;
        }

        // Метод для мяуканья кота N раз
        public void Meow(int n)
        {
            if (n <= 0)
                Console.WriteLine("Количество раз для мяуканья должно быть больше нуля.");
            Console.WriteLine($"{Name}: " + string.Join("-", new string[n].Select(_ => "мяу")));
            meowCount += n;
        }

        // Метод для получения количества мяуканий
        public int GetMeowCount()
        {
            return meowCount;
        }
    }
}
