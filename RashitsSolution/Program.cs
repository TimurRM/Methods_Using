
// Задача: Написать программу, которая из имеющегося массива строк формирует массив из строк, 
// длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.
// Примеры:
// ["hello", "2", "world", ":-)"] -> ["2", ":-)"]
// ["1234", "1567", "-2", "computer science"] -> ["-2"]
// ["Russia", "Denmark", "Kazan"] -> []

/* Вариант решения встроенными методами C# */
// ++++++++  блок методов ++++++++  
void PrintArray(string[] arrayForOutput)                 // метод 1 - форматированный вывод массива строк в консоль
{
    Console.WriteLine("[" + string.Join(", ", arrayForOutput) + "] -> ");
}
uint LokigForSecondArrayLength(string[] arrayParent)     // метод 2 - поиск размерности массива для рещультата
{
    uint result = 0; //количетво элементов массива, удовлетворяющих условию "<= 3"
    foreach (string element in arrayParent)
        if(element.Length <= 3) result++;
    return result;
}
string[] GetSecondArray(string[] arrayParent, uint size)  // метод 3 - поиск размерности массива для рещультата
{
    string[] result = new string[size];     //объявление массива и резервирование память в ОЗУ
    int i = 0;
    foreach (string element in arrayParent)
        if(element.Length <= 3) 
        {
            result[i] = element;            //заполнение второго массива, согласно условию задачи
            i++;
        }
    return result;
}
bool TryRunProgramAgain(bool endOfInputStrings)          // метод 4 - перезапускаем ввод массива строк или финиш?
{
    string messageForUser = Environment.NewLine + "Вы хотите ввести новую строку? - введите да/нет и нажмите enter: ";
    Console.Write(messageForUser);
    // добъёмся от пользователя правильного ввода: только "да" или "нет" при этом любого регистра
    bool needToRepeatYesNo;
    do
    {
        needToRepeatYesNo = true;
        string userChoice = (Console.ReadLine()!).ToLower();
        //Console.WriteLine("userChoice = {1}", userChoice);
        if(userChoice == "да")
        {
            needToRepeatYesNo = false;
        }
        else if(userChoice == "нет")
        {
            needToRepeatYesNo = false;
            endOfInputStrings = true;
            Console.WriteLine();
        }
        else
        {
            needToRepeatYesNo = true;
            Console.Write("всё-таки \"да\" или \"нет\"? -> ");
        }
    } while(needToRepeatYesNo);
    return endOfInputStrings;
}


// ++++++++  основной код - тело метода main ++++++++  
Console.Clear();
bool endOfInputStrings = false;
while (!endOfInputStrings)
{
    //ввод строки с консоли через разделители (пробел, запятая, запятая+пробел):
    Console.WriteLine(Environment.NewLine + 
                    "Введите элементы строкового массива через разделители (пробел или запятые) и нажмите enter:");
    string inputData = Console.ReadLine()!;
        // Есть 4 варианта. Строка содержит: 1. null; 2. Строка пуста; 3. Строка содержит пробельные символы; 4. Строка содержит отображаемые данные
    bool inputDataContent = String.IsNullOrWhiteSpace(inputData); // проверка состояния  п. 1-3 (при вводе с консоли 1 не будет)
    if(inputDataContent)
    {
        Console.WriteLine(inputData + " - > введено что-то неясное, повторите вввод");
    }
    else  // РЕШЕНИЕ ЗАДАЧИ ЗДЕСЬ
    {
        Console.WriteLine("Результат выполнения программы:");
        // по набору разделителей зазбиение строки на массив
        char[] separators  = new char[]{',' , ' '};
        string[] arraySubStrings = inputData.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        PrintArray(arraySubStrings);
        if (arraySubStrings.Length == 1)
        {
            Console.WriteLine(" -> из одного элемента массив не сформируешь (по определию массива)");
        }
        else
        {
            // вызов 2го метода для поиска количесва найденных по условию задачи элементов
            uint secondArrayLength = LokigForSecondArrayLength(arraySubStrings);
            if(secondArrayLength == 0)   Console.WriteLine(" -> []");
            else
            {
                string[] arrayByTaskCondition = GetSecondArray(arraySubStrings, secondArrayLength);
                PrintArray(arrayByTaskCondition);
            }
        }
    }
    // завершаем программу или вводим новый массив строк?
    endOfInputStrings = TryRunProgramAgain(endOfInputStrings);
}
