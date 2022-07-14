namespace Practice;
/// <summary>
/// Класс, реализующий операции над множествами
/// </summary>
public class BitMask
{
    /// <summary>
    /// Конструктор, задающий универсум
    /// </summary>
    /// <param name="Universum">Универсум</param>
    public BitMask(int[] Universum)
    {
        this.Universum = new HashSet<int>(Universum).ToList();
        this.Universum.Sort();
        ULength = this.Universum.Count;
    }


    /// <summary>
    /// Универсум множеств
    /// </summary>
    public List<int> Universum { get; }

    /// <summary>
    /// Мощность универсума
    /// </summary>
    private int ULength { get; }
    /// <summary>
    /// Счётчик
    /// </summary>
    private static int Counter;
    /// <summary>
    /// Средство записи в файл
    /// </summary>
    private static StreamWriter Writer;




    /// <summary>
    /// Метод-обёртка для создания булеана на универсуме
    /// </summary>
    /// <param name="set">Исходное множество</param>
    /// <param name="path">Путь для записи в файл</param>
    public static void ShowBulean(int[] set, string path)
    {
        int n = 0;
        Counter = 0;
        string s = "";
        Writer = new(path);
        
        set = set.ToHashSet().ToArray();
        CreateBulean(n, s, ref set);

        Writer.Close();
        Writer.Dispose();
    }

    /// <summary>
    /// Метод, строящий булеан
    /// </summary>
    /// <param name="n">Номер текущего элемента</param>
    /// <param name="s">Конструируемая строка вывода</param>
    /// <param name="set">Ссылка на исходное множество</param>
    private static void CreateBulean(int n, string s, ref int[] set)
    {
        if (n == set.Length)
        {
            Writer.WriteLine($"{++Counter}.\t{s}");
            return;
        }

        if (s == "") CreateBulean(n + 1, $"{set[n]}", ref set);
        else CreateBulean(n + 1, $"{s}, {set[n]}", ref set);

        CreateBulean(n + 1, s, ref set);
    }

    /// <summary>
    /// Метод создания битовой маски
    /// </summary>
    /// <param name="set">Множество, для которого строится маска</param>
    /// <returns>Битовая маска (логический массив)</returns>
    private bool[] CreateMask(int[] set)
    {
        HashSet<int> buffer = new(set);
        set = buffer.ToArray();
        Array.Sort(set);
        bool[] mask = new bool[ULength];

        for (int i = 0; i < ULength; i++)
            mask[i] = false;

        for (int i = 0, j = 0; i < mask.Length && j < set.Length; i++)
        {
            if (Universum[i] == set[j])
            {
                mask[i] = true;
                j++;
            }
        }
        return mask;
    }



    /// <summary>
    /// Метод, реализующий пересечение двух множеств
    /// </summary>
    /// <param name="A">Множество 1</param>
    /// <param name="B">Множество 2</param>
    /// <returns>Результирующее множество</returns>
    public int[] Intersection(int[] A, int[] B)
    {
        bool[] AMask = CreateMask(A);
        bool[] BMask = CreateMask(B);

        List<int> result = new();

        for (int i = 0; i < ULength; i++)
        {
            if (AMask[i] && BMask[i]) result.Add(Universum[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Метод, реализующий объединение двух множеств
    /// </summary>
    /// <param name="A">Множество 1</param>
    /// <param name="B">Множество 2</param>
    /// <returns>Результирующее множество</returns>
    public int[] Union(int[] A, int[] B)
    {
        bool[] AMask = CreateMask(A);
        bool[] BMask = CreateMask(B);

        List<int> result = new();

        for (int i = 0; i < ULength; i++)
        {
            if (AMask[i] || BMask[i]) result.Add(Universum[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Метод, реализующий разность двух множеств
    /// </summary>
    /// <param name="A">Множество 1</param>
    /// <param name="B">Множество 2</param>
    /// <returns>Результирующее множество</returns>
    public int[] Difference(int[] A, int[] B)
    {
        bool[] AMask = CreateMask(A);
        bool[] BMask = CreateMask(B);

        List<int> result = new();

        for (int i = 0; i < ULength; i++)
        {
            if (AMask[i] && !BMask[i]) result.Add(Universum[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Метод, реализующий симметрическую разность двух множеств
    /// </summary>
    /// <param name="A">Множество 1</param>
    /// <param name="B">Множество 2</param>
    /// <returns>Результирующее множество</returns>
    public int[] SymmetricalDifference(int[] A, int[] B)
    {
        bool[] AMask = CreateMask(A);
        bool[] BMask = CreateMask(B);

        List<int> result = new();

        for (int i = 0; i < ULength; i++)
        {
            if (AMask[i] ^ BMask[i]) result.Add(Universum[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Метод, реализующий операцию дополнения над множеством
    /// </summary>
    /// <param name="A">Исходное множество</param>
    /// <returns>Результирующее множество</returns>
    public int[] Negation(int[] A)
    {
        bool[] AMask = CreateMask(A);

        List<int> result = new();

        for (int i = 0; i < ULength; i++)
        {
            if (!AMask[i]) result.Add(Universum[i]);
        }

        return result.ToArray();
    }
}
