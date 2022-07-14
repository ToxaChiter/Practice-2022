
using Practice;


int[] array = new int[11];
for (int i = 0; i < array.Length; i++)
    array[i] = i + 1;


BitMask bitMask = new(array);    //new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}

//BitMask.ShowBulean(new int[] {1, 3, 4, 7, 10, 15, 20});


//DateTime start = DateTime.Now;
//try
//{
//    bitMask.ShowBoolean();
//}
//catch (Exception ex)
//{
//    Console.WriteLine("\n\t\tError\n");
//}
//TimeSpan spent = DateTime.Now - start;
//Console.WriteLine(spent);

int[] A = new int[] {1, 6, 4, 7, 9, 9};
Console.WriteLine($"Array A:\t{string.Join(", ", A)}\n");
int[] B = new int[] { 1, 4, 4, 5, 8, 9};
Console.WriteLine($"Array B:\t{string.Join(", ", B)}\n\n\n");

int[] C = bitMask.Intersection(A, B);
Console.WriteLine($"Intersection:\t{string.Join(", ", C)}\n");

C = bitMask.Union(A, B);
Console.WriteLine($"Union:\t{string.Join(", ", C)}\n");

C = bitMask.Difference(A, B);
Console.WriteLine($"Difference (A - B):\t{string.Join(", ", C)}\n");

C = bitMask.Difference(B, A);
Console.WriteLine($"Difference (B - A):\t{string.Join(", ", C)}\n");

C = bitMask.SymmetricalDifference(A, B);
Console.WriteLine($"SymmetricalDifference:\t{string.Join(", ", C)}\n");

C = bitMask.Negation(A);
Console.WriteLine($"Negation (A):\t{string.Join(", ", C)}\n");

C = bitMask.Negation(B);
Console.WriteLine($"Negation (B):\t{string.Join(", ", C)}\n");



Console.Clear();