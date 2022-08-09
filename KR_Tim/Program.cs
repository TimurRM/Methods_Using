

void GetArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Input {i + 1} array element: ");
        array[i] = Console.ReadLine();
    }
}


void ShowArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == 0)
        {
        Console.Write("['" + array[i] + "', '");
        }
        else if (i < array.Length - 1)
        {
        Console.Write(array[i] + "', '");   
        }
        else
        {
        Console.Write(array[i] + "']");  
        }
        
    }
}


int SortArray(string[] array)
{
    int n = 3;
    int count = array.Length;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i].Length > n)
        {
        count--;
        }
        
    }
    return count;
}


bool endOdProgram = false;
    do
    {
            Console.Write("Input quantity of array elements: ");
            int arrayLength = Convert.ToInt32(Console.ReadLine());

            string[] inputArray = new string[arrayLength];
            GetArray(inputArray);
            ShowArray(inputArray);
            int sortedArrayLength = SortArray(inputArray);
            string[] SortedArray = new string[sortedArrayLength];

            int count = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].Length  <= 3)
                {
                    SortedArray[count] = inputArray[i];
                    count++;
                }
            }

            Console.Write(" -> ");
            ShowArray(SortedArray);

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("Do you want to continue? (press \"yes\" or \"Y\")");
                string exitCondition = Convert.ToString(Console.ReadLine());
                if (exitCondition == "Y")
                    endOdProgram = true;
    } while(endOdProgram);