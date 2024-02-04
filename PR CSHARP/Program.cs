namespace PR_CSHARP
{
   class Cat
    {
        //Максимальне значення потреб  кота
        private int maxValue;
        //Ефективність дій над котом
        private int effectivness;
        //потреби кота
        public int tireness;
        public int hunger;
        public int tidiness;
        //Конструктор
        public Cat(int maxValue, int effectivness, int tireness, int hunger, int tidiness)
        {
            this.maxValue = maxValue;
            this.effectivness = effectivness;
            this.tireness = tireness;
            this.hunger = hunger;
            this.tidiness = tidiness;
        }
        //Підвищення рівня вдоволеності кота
        public void Increase(ref int value)
        {
            value += value+effectivness>maxValue?0:effectivness;
        }
        //Пониження рівня вдоволеності кота 
        public void Decrease(ref int value)
        {
            Random rand = new Random();
            value -= rand.Next(0, effectivness);
        }
        //Перевірка чи всі потреби кота на належному рівні
        public bool isUpset()
        {
            if(tireness <= 0 || tidiness <= 0 || hunger <= 0)
            {
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Cat cat = new Cat(100, 20, 50, 50, 50);
            while (!cat.isUpset())
            {
                Console.WriteLine($"Потреби кота:\n\tГолод:{cat.hunger}/100\n\tСон:{cat.tireness}/100\n\tчистота:{cat.tidiness}/100");
                Draw(cat);
                Control(cat);
                Console.Clear();
            }
            Console.WriteLine("\n\n\tО ні, кіт втік!");
            
        }
        //Метод для малювання кота
        static void Draw(Cat cat)
        {
            if (cat.tireness <= 20 || cat.tidiness <= 20 || cat.hunger <= 20)
            {
                Console.WriteLine("    /\\_____/\\\r\n   /  \\   /  \\\r\n  ( ==  ^  == )\r\n   )         (\r\n  (           )\r\n ( (  )   (  ) )\r\n(__(__)___(__)__)");

            }
            else
            {
                Console.WriteLine("    /\\_____/\\\r\n   /  o   o  \\\r\n  ( ==  ^  == )\r\n   )         (\r\n  (           )\r\n ( (  )   (  ) )\r\n(__(__)___(__)__)");

            }
        }
        //Метод для керування
        static void Control(Cat cat)
        {
            Console.WriteLine("Введіть команду (годувати/убаюкати/мити):");
            string input = Console.ReadLine();
            switch (input)
            {
                case "годувати":
                    cat.Increase(ref cat.hunger);
                    cat.Decrease(ref cat.tireness);
                    cat.Decrease(ref cat.tidiness);
                    break;
                case "убаюкати":
                    cat.Increase(ref cat.tireness);
                    cat.Decrease(ref cat.hunger);
                    cat.Decrease(ref cat.tidiness);
                    break;
                case "мити":
                    cat.Increase(ref cat.tidiness);
                    cat.Decrease(ref cat.hunger);
                    cat.Decrease(ref cat.tireness);
                    break;
                default: Console.WriteLine("Невірна команда!");
                    Control(cat);
                    break;
            }
        }
    }
    
}
