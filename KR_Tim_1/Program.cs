// МЕТОДЫ
void GetArray(string[] array)  // метод ввода массива с консоли (клавиатуры)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Input {i + 1} array element and press enter: ");
        array[i] = Console.ReadLine()!;
    }
}

void ShowArray(string[] array) // метод вывода массива в консоль
{
    for (int i = 0; i < array.Length; i++)
        if (i == 0)
            Console.Write("['" + array[i] + "', '");
        else if (i < array.Length - 1)
            Console.Write(array[i] + "', '");   
        else
            Console.Write(array[i] + "']");  
}

int SortArray(string[] array) // метод для поиска построк с длиной менее n элементов
{
    int n = 3;                 // ЗАЧЕМ УДАЛЯТЬ ?, в  ЗАДАЧЕ СКАЗАНО: СОЗДАТЬ НОВЫЙ МАССИВ!
    int count = array.Length;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i].Length > n)
        {
            //array[i] = string.Empty;
            count--;
        }
    }
    return count;
}

// Основной код, где вызываем методы
Console.Write("Input quantity of array elements and press enter: ");
int arrayLength = Convert.ToInt32(Console.ReadLine()); // пользователь задаёт количество элементов исходного массива
string[] inputArray = new string[arrayLength];         // выделяется память в ОЗУ под исходный массив из строк
GetArray(inputArray);                                  // ввод исходного массива
ShowArray(inputArray);                                 // вывод исходного массива
int sortedArrayLength = SortArray(inputArray);         // поиск количества элементов в исходном массиве, удов-х условию (для выделения соот-й памяти в ОЗУ для хранения)
string[] newSortedArray = new string[sortedArrayLength]; // выделяется память в ОЗУ под новый массив из строк
int j = 0;                                             // счётчик для элементов нового массива (от 0 до sortedArrayLength-1)
for (int i = 0; i < inputArray.Length; i++)            // заполняем в соответсвии с условием 2-й массив
{
    if (inputArray[i].Length <= 3)
    {
        newSortedArray[j] = inputArray[i];
        j++;
    }
}
Console.Write(" -> ");
ShowArray(newSortedArray);                             // вывод нового массива
Console.WriteLine();