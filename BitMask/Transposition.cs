namespace Practice;
/// <summary>
/// Класс, реализующий вывод всех перестановок заданного множества
/// </summary>
public static class Transposition
{   
    /// <summary>
    /// Счётчик
    /// </summary>
    private static int Counter;
    /// <summary>
    /// Средство записи в файл
    /// </summary>
    private static StreamWriter Writer;
    /// <summary>
    /// Перечисление порядков
    /// </summary>
    public enum Orders
    {
        Straight,
        Anti
    }
    /// <summary>
    /// Выводит все перестановки множества в выбранном порядке
    /// </summary>
    /// <param name="set">Исходное множество</param>
    /// <param name="order">Порядок перестановок</param>
    /// <param name="path">Путь для сохранения</param>
    public static void Write(int[] set, Orders order, string path)
    {
        List<int> list = new HashSet<int>(set).ToList();
        list.Sort();

        Counter = 0;
        Writer = new(path);

        switch (order)
        {
            case Orders.Straight:
                CreateStraight(ref list, "");
                break;

            case Orders.Anti:
                list.Reverse();
                CreateAnti(ref list, "");
                break;
        }

        Writer.Close();
        Writer.Dispose();
    }
    /// <summary>
    /// Выводит в лексиографическом порядке
    /// </summary>
    /// <param name="list">Ссылка на отсортированное множество</param>
    /// <param name="s">Конструируемая строка</param>
    private static void CreateStraight(ref List<int> list, string s)
    {
        if (list.Count == 1)
        {
            Writer.WriteLine($"{++Counter}.\t{s}, {list[0]}");
            return;
        }

        int length = list.Count, element;

        for (int i = 0; i < length; i++)
        {
            element = list[i];
            list.RemoveAt(i);

            if (s == "") CreateStraight(ref list, $"{element}");
            else CreateStraight(ref list, $"{s}, {element}");

            list.Insert(i, element);
        }
    }
    /// <summary>
    /// Выводит в антилексиографическом порядке
    /// </summary>
    /// <param name="list">Ссылка на отсортированное в обратном порядке множество</param>
    /// <param name="s">Конструируемая строка</param>
    private static void CreateAnti(ref List<int> list, string s)
    {
        if (list.Count == 1)
        {
            Writer.WriteLine($"{++Counter}.\t{list[0]}, {s}");
            return;
        }

        int length = list.Count, element;

        for (int i = 0; i < length; i++)
        {
            element = list[i];
            list.RemoveAt(i);

            if (s == "") CreateAnti(ref list, $"{element}");
            else CreateAnti(ref list, $"{element}, {s}");

            list.Insert(i, element);
        }
    }
}
