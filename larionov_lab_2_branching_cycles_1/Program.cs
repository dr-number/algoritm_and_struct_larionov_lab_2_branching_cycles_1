namespace larionov_lab_2_branching_cycles_1
{
    class TasksInfo
    {
        public const string TASK_1 = "Пользователь задает промежутки для двух аргументов и шаг.\n" +
            "Программа выводит на экран значения функции.";

        public const string TASK_3 = "Даны три целых числа.\n" +
            "Если среди них есть ноль, все числа обнулить.\n" +
            "Если два числа положительны, а третье отрицательно, отрицательное возвести в квадрат.\n" +
            "Если два числа отрицательны, а третье положительно, сменить знак у каждого числа.\n" +
            "Если все числа имеют один знак, изменять их не требуется.";

        public const string TASK_7 = "Вычислить значние суммы бесконечного ряда\n" +
            "с точностью до члена ряда, по модулю меньшего E";

        public const string TASK_9 = "Дано k натуральных чисел. Определить, сколько из них совершенны. ";
    }

    class MyInput
    {
        public int inputData(string text, int min, int max, int defaultValue = -1)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;


            while (true)    //Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();

                if (xStr == "")
                    return defaultValue;

                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else if(x < min && x > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число должно лежать в промежутке [{min}; {max}]!");
                }
                else
                    break;
            }

            return x;
        }

        public double inputDoubleData(string text, int min, int max, double defaultValue = -1)
        {

            string xStr = "";
            bool isNumber = false;
            double x = 0;

            while (true)    //Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();

                if (xStr == "")
                    return defaultValue;

                isNumber = double.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else if (x < min && x > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число должно лежать в промежутке [{min}; {max}]!");
                }
                else
                    break;
            }

            return x;
        }
    }

    class MyQuestion
    {
        public const string QUESTION_RANDOM_DATA = "Сгенерировать данные случайным образом [y/n]?";
        public const string QUESTION_IN_ORDER_DATA = "Взять числа по порядку [y/n]?";
        public const string QUESTION_SHOW_CALC = "Показывать ход вычислений [y/n]?";

        public bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }
    }

    class Task1
    {
        const int MIN = -1000;
        const int MAX = 1000;

        private struct arguments
        {
            public double x;
            public double x1;
        }

        private bool function1(double a, double a1, double b, double b1, double step)
        {
            Console.WriteLine($"\nШаг: {step}\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           -");
            Console.WriteLine("           | a - b, если a > 10,");
            Console.WriteLine("           |");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           | a - b");
            Console.WriteLine("f(a, b) = < -------, если 0 < a <= 10, b > 0");
            Console.WriteLine("           | a + b");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("           |");
            Console.WriteLine("           | b - в остальных случаях");
            Console.WriteLine("           -\n");

            Console.ResetColor();

            if (step > a1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка аргумент A: шаг не должен быть больше длинны промежутка!");
                Console.ResetColor();
                return false;
            }

            if (step > b1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка аргумент B: шаг не должен быть больше длинны промежутка!");
                Console.ResetColor();
                return false;
            }

            double y = 0;
            string f = "";

            Console.WriteLine("{0,10}   |{1,10}   |{2,30}   |{3,10}", "a", "b", "f(a, b)", "y");

            while (a < a1 && b < b1)
            {

                if (a > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    f = $"{a} - {b}";
                    y = a - b;
                }
                else if (0 < a && a <= 10 && b > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    f = $"({a} - {b}) / ({a} + {b})";
                    y = (a - b) / (a + b);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    y = b;
                    f = $"b = {b}";
                }

                y = Math.Round(y, 2);
                Console.WriteLine("{0,10}   |{1,10}   |{2,30}   |{3,10}", a, b, f, y);

                a += step;
                b += step;

            }

            Console.ResetColor();
            return true;
        }

        private arguments inputDouble(string arg)
        {
            double x = 0, x1 = 0;
            
            MyInput myInput = new MyInput();

            while (true) //Цикл с предусловием
            {
                Console.ResetColor();

                x = myInput.inputData($"\nВведите начальное значение {arg} (число): ", MIN, MAX);
                x1 = myInput.inputData($"\nВведите промежуток для {arg} (число): ", MIN, MAX);

                if (x >= x1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка аргумент {arg}: {x} >= {x1}");
                }
                else
                    break;
            }

            arguments result = new arguments();
            result.x = x;
            result.x1 = x1;
            return result;
        }

        public bool init()
        {
            Console.WriteLine(TasksInfo.TASK_1);

            arguments A = inputDouble("A");
            arguments B = inputDouble("B");

            MyInput myInput = new MyInput();
            double step = myInput.inputDoubleData("\nВведите шаг (число): ", 0, MAX);

            return function1(A.x, A.x1, B.x, B.x1, step);
        }

    }

    class Task3
    {
        private const int MIN = -50;
        private const int MAX = 50;

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_3);

            MyQuestion myQuestion = new MyQuestion();
            bool isRandom = myQuestion.isQuestion(MyQuestion.QUESTION_RANDOM_DATA);

            MyInput myInput = new MyInput();

            bool isError = false;
            int var1 = 0, var2 = 0, var3 = 0;

            if (isRandom)
            {
                Random rnd = new Random();
                var1 = rnd.Next(MIN, MAX);
                var2 = rnd.Next(MIN, MAX);
                var3 = rnd.Next(MIN, MAX);
            }
            else
            {
                var1 = myInput.inputData("\nВведите первое целое число: ", MIN, MAX);
                var2 = myInput.inputData("\nВведите второе целое число: ", MIN, MAX);
                var3 = myInput.inputData("\nВведите третье целое число: ", MIN, MAX);
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nПолученные данные: {var1}; {var2}; {var3}.\n");
            Console.ResetColor();

            if (var1 == 0 || var2 == 0 || var3 == 0)
            {
                Console.WriteLine($"\nСреди чисел есть ноль. Обнулим все числа (по условию задачи)");
                var1 = var2 = var3 = 0;
            }
            else if(var1 > 0 && var2 > 0 && var3 < 0)
            {
                Console.WriteLine($"\nДва первых цисла положительны, третье отрицательно. Возведем в квадрат третье число (по условию задачи)");
                var3 = (int) Math.Pow(var3, 2);

            }
            else if (var1 < 0 && var2 < 0 && var3 > 0)
            {
                Console.WriteLine($"\nДва первых цисла отрицательны, третье положительно. Меняем знак у каждого (по условию задачи)");

                var1 = 0 - var1;
                var2 = 0 - var2;
                var3 = 0 - var3;
            }
            else
            {
                int sign1 = Math.Sign(var1);
                int sign2 = Math.Sign(var2);
                int sign3 = Math.Sign(var3);

                if(sign1 == sign2 && sign2 == sign3 && sign1 == sign3)
                {
                    if(sign1 > 0)
                        Console.WriteLine($"\nВсе числа положительны\n");
                    else if (sign1 < 0)
                        Console.WriteLine($"\nВсе числа отрицательны\n");

                    Console.WriteLine($"\nНичего не меняем (по условию задачи)\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные не удовлетворяют ни одному условию задачи!");
                    Console.ResetColor();

                    isError = true;
                }

            }

            if (!isError)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nКонечный результат: {var1}; {var2}; {var3}.\n");
                Console.ResetColor();
            }

        }
    }

    class Task7
    {
        private double EXACTNESS = 0.0001, DEFAULT_X = 0.5;

        public void init()
        {
            int factorial = 1, n = 1;
            double current = 1, sum = 1, prev;

            string MASK = "0.#########################";

            Console.WriteLine($"\nВычислить значение суммы бесконечного ряда c точностью  E = {EXACTNESS}\n");

            MyInput myInput = new MyInput();
            double x = myInput.inputDoubleData($"Введите значение X (дробное число 0 <= x <= 1) или нажмите Enter для x = {DEFAULT_X}: ", 0, 1, DEFAULT_X);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"x = {x}");
            Console.ResetColor();

            Console.WriteLine("{0,30}   |{1,30}", "Слагаемое", "Сумма");
            Console.WriteLine("{0,30}   |{1,30}", current, sum);

            do //Цикл с постусловием
            {
                prev = current;
                current = (Math.Pow(Math.Log(3), n) / factorial) * Math.Pow(x, n);

                sum += current;

                Console.WriteLine("{0,30}   |{1,30}", current.ToString(MASK), sum.ToString(MASK));

                ++n;

                if (factorial == 1) factorial = 2;
                else factorial = factorial * n;

            } 
            while (Math.Abs(current - prev) > EXACTNESS);

            double check = Math.Pow(3, x);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСумма ряда равна: {0,30}", sum);
            Console.ResetColor();

            Console.WriteLine("Значение функции проверки: {0,21}", check);

            double difference = Math.Abs(check - sum);

            string message = "";

            if(difference <= EXACTNESS)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                message = "Вычисления выполнены с необходимой точностью.";
               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                message = "Вычисления неточны!";
            }

            Console.WriteLine($"\nРазность: {difference.ToString(MASK)}");
            Console.WriteLine($"{message}\n");

            Console.ResetColor();

        }
    }

    class Task9
    {
        public const int MAX_COUNT = 50;
        public const int DEFAULT_COUNT = 20;
        public const int MAX_SUBSEQUENCE = 8500;

        public const int MIN_RANDOM = -200;
        public const int MAX_RANDOM = 200;

        private string inputNumber(string text, string symbolExit)
        {


            string xStr = "";
            bool isNumber = true;
            int x;

            while (true) ////Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();

                if (xStr.ToLower() == symbolExit.ToLower())
                    return symbolExit;

                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else
                    break;
            }

            return xStr;
        }

        private bool isAbsolutely(int num)
        {
            if (num == 1)
                return false;

            int sum = 1;
            int count = num / 2 + 1;

            for (int i = 2; i < count; ++i) 
                if (num % i == 0) sum += i;

            return sum == num;
        }

        private int processing(int num, int i)
        {
            string number = $"{i}) {num}";
            bool result = isAbsolutely(num);

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                number += " - Совершенное число";
            }
            else
            {
                Console.ResetColor();
                number += " - не совершенное число";
            }

            Console.WriteLine($"{number}");
            return result ? 1 : 0;
        }

        public void init()
        {
           
            Console.WriteLine(TasksInfo.TASK_9);

            Console.WriteLine($"\nВзять числа от 1 до {MAX_SUBSEQUENCE} [s]");
            Console.WriteLine($"Ручной ввод данных (максимум {MAX_COUNT} чисел) [h]");
            Console.WriteLine("Cгенерировать числа случайным образом [любое значение]\n");

            Console.WriteLine("Введите значение: ");
            string select = Console.ReadLine()?.ToLower();

            int countAbsolutely = 0;

            if (select == "s")
            {
                Console.WriteLine($"Числа от 1 до {MAX_SUBSEQUENCE}\n") ;

                for (int i = 1; i <= MAX_SUBSEQUENCE; i++) ////Цикл с параметром
                    countAbsolutely += processing(i, i);
            }
            else if(select == "h")
            {
                Console.WriteLine("Ручной ввод данных\n");

                string strNumber = "";
                const string EXIT_SYMBOL = "Z";

                for (int i = 0; i < MAX_COUNT; i++)
                {
                    strNumber = inputNumber($"Введите число. (Максимум {MAX_COUNT} чисел) Для прекращения ввода чисел введите {EXIT_SYMBOL}:", EXIT_SYMBOL);

                    if (strNumber.ToUpper() != EXIT_SYMBOL)
                    {
                        countAbsolutely += processing(int.Parse(strNumber), i + 1);
                        Console.WriteLine("\n");
                    }
                    else
                        break;
                }
            } 
            else
            {
                Console.WriteLine("Генерация случайных чисел\n");

                MyInput myInput = new MyInput();
                int count = myInput.inputData($"Сколько сгенерировать случайных чисел? (Не более {MAX_COUNT}) Для {MAX_COUNT} нажмите Enter: \n", 0, MAX_COUNT, DEFAULT_COUNT);

                int randomNumber;
                string number;

                Random rnd = new Random();
                Console.WriteLine("Сгенерированные данные:\n");

                for (int i = 0; i < count; i++) ////Цикл с параметром
                {
                    randomNumber = rnd.Next(MIN_RANDOM, MAX_RANDOM);
                    countAbsolutely += processing(randomNumber, i+1);
                    
                }
            }

            if(countAbsolutely == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nДанные не содержат совершенных чисел!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nКоличество совершенных чисел: {countAbsolutely}\n");
                Console.ResetColor();
            }

        }
    }

    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Варинат №6. Ларионов Никита Юрьевич. гр. 110з\n");

            bool isGo = true;


            while (isGo)    ////Цикл с предусловием
            {
                Console.WriteLine("\nВведите номер задачи: ");

                Console.WriteLine("\n1) " + TasksInfo.TASK_1);
                Console.WriteLine("\n3) " + TasksInfo.TASK_3);
                Console.WriteLine("\n7) " + TasksInfo.TASK_7);
                Console.WriteLine("\n9) " + TasksInfo.TASK_9);

                Console.WriteLine("\nДля выхода введите \"0\": ");

                string selectStr = Console.ReadLine();

                switch (selectStr)
                {
                    case "1" : 
                        Task1 task1 = new Task1();
                        while (!task1.init()) ;
                        break;

                    case "3" :
                        Task3 task3 = new Task3();
                        task3.init();
                        break;

                    case "7":
                        Task7 task7 = new Task7();
                        task7.init();
                        break;

                    case "9":
                        Task9 task9 = new Task9();
                        task9.init();
                        break;

                    case "0": 
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }
            }

        }

    }

}