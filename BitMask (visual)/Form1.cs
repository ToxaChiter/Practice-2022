using Practice;

namespace BitMask_Visual;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        ListSets.Enter += ListSets_Enter;
        ListSets.Leave += ListSets_Leave;
        ListSets.DoubleClick += ListSets_DoubleClick;

        Texts = new string[][]{
            new string[]{
                "Выберите первое множество для операции \"Объединение\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое",
                "Выберите второе множество для операции \"Объединение\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое"},

            new string[]{
                "Выберите первое множество для операции \"Пересечение\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое",
                "Выберите второе множество для операции \"Пересечение\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое"},

            new string[]{
                "Выберите уменьшаемое множество для операции \"Разность\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое",
                "Выберите вычитаемое множество для операции \"Разность\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое"},

            new string[]{
                "Выберите первое множество для операции \"Симметрическая разность\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое",
                "Выберите второе множество для операции \"Симметрическая разность\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое"},

            new string[]{
                "Выберите множество для операции \"Дополнение\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое", 
                ""},

            new string[]{
                "Выберите множество для операции \"Построение булеана\"\r\n" +
                "Подсказка: двойной клик по множеству покажет его содержимое",
                ""}
        };
        Buttons = new Button[] {
            Union, 
            Intersection, 
            Difference, 
            SymmetricalDifference, 
            Negation,
            Bulean };
        foreach (Button button in Buttons)
        {
            button.Click += OperationButton_Click;
        }

        saveFile = new();
        saveFile.DefaultExt = "txt";
        saveFile.AddExtension = true;
        saveFile.CheckPathExists = true;
        saveFile.Filter = "Текстовые файлы(*.txt)|*.txt";
        saveFile.Title = "Сохранение";
        saveFile.CreatePrompt = true;
        saveFile.OverwritePrompt = true;
    }

    private void VisibleAll(bool isVisible)
    {
        foreach (Control component in Controls) component.Visible = isVisible;
    }

    private void VisibleButtons(bool isVisible)
    {
        foreach (Control component in Controls)
        {
            if (component is Button)
            {
                component.Visible = isVisible;
                component.Enabled = isVisible;
            }
        }
        Choice.Enabled = false;
    }



    private void TextBoxAmount_KeyPress_First(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == ((char)Keys.Enter))
        {
            if (int.TryParse(TextBoxAmount.Text, out int value))
            {
                VisibleAll(true);
                Choice.Enabled = false;
                ListSets.Enabled = false;
                TextBoxAmount.Visible = false;
                TextBoxReadOnly.Visible = false;
                TextBoxTip.Visible = false;

                int[] array = new int[value];
                for (int i = 0; i < array.Length; i++) { array[i] = i + 1; }

                MainBitMask = new BitMask(array);
                Sets.Add("Universum", array);
                ListSets.Items.Add("Universum");

                TextBoxAmount.Clear();

                TextBoxAmount.KeyPress -= new KeyPressEventHandler(TextBoxAmount_KeyPress_First);
            }
            else
            {
                TextBoxAmount.Clear();
                MessageBox.Show(
                    "Можно использовать только цифры! Попробуйте снова",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }

    private void TextBoxAmount_KeyPress_Set(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == ((char)Keys.Enter))
        {
            bool canParse = true;
            foreach (var item in TextBoxAmount.Text.Trim().Split(' ')) 
            { canParse = canParse && int.TryParse(item, out int value); }

            if (TextBoxAmount.Text.Trim() == string.Empty) canParse = true;

            if (canParse)
            {
                if (TextBoxAmount.Text.Trim() != string.Empty)
                {
                    string[] chars = TextBoxAmount.Text.Trim().Split(' ');
                    HashSet<int> numbers = new();
                    foreach (var item in chars)
                    {
                        numbers.Add(int.Parse(item));
                    }
                    int[] set = numbers.ToArray();
                    Array.Sort(set);
                    Sets.Add((string)ListSets.Items[^1], set);
                }
                else
                {
                    Sets.Add((string)ListSets.Items[^1], Array.Empty<int>());
                }


                VisibleButtons(true);

                TextBoxReadOnly.Visible = false;
                TextBoxAmount.Clear();
                TextBoxAmount.Visible = false;

                TextBoxAmount.KeyPress -= new KeyPressEventHandler(TextBoxAmount_KeyPress_Set);

                string message;
                if (Sets[(string)ListSets.Items[^1]].Length == 0)
                    message = $"Добавленное множество: пустое";
                else message =
                        $"Добавленное множество: {string.Join(", ", Sets[(string)ListSets.Items[^1]])}";
                MessageBox.Show(
                    message,
                    "Подсказка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                TextBoxAmount.Clear();
                MessageBox.Show(
                    "Не удалось преобразовать! Попробуйте снова\n" +
                    "Подсказка: используйте только цифры и символ пробела",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }

    private void TextBoxAmount_KeyPress_Name(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == ((char)Keys.Enter))
        {
            if (TextBoxAmount.Text.Trim() == string.Empty)
            {
                TextBoxAmount.Clear();
                return;
            }

            if (!Sets.ContainsKey(TextBoxAmount.Text))
            {
                ListSets.Items.Add(TextBoxAmount.Text);

                TextBoxAmount.KeyPress -= new KeyPressEventHandler(TextBoxAmount_KeyPress_Name);
                if (tempSet is null)
                {
                    TextBoxAmount.KeyPress += new KeyPressEventHandler(TextBoxAmount_KeyPress_Set);

                    TextBoxReadOnly.Text = "Введите элементы множества (через пробел)";
                    TextBoxAmount.Clear();
                    TextBoxAmount.PlaceholderText = "Используйте цифры и символ пробела";
                }
                else
                {
                    Sets.Add(TextBoxAmount.Text.Trim(), tempSet);

                    VisibleButtons(true);

                    TextBoxReadOnly.Visible = false;
                    TextBoxAmount.Clear();
                    TextBoxAmount.Visible = false;

                    TextBoxTip.Visible = false;
                    TextBoxTip.Text = string.Empty;

                    ListSets.Enabled = false;
                    ListSets.ClearSelected();
                    Choice.Enabled = false;

                    tempSet = null;

                    string message;
                    if (Sets[(string)ListSets.Items[^1]].Length == 0) 
                        message = $"Добавленное множество: пустое";
                    else message = 
                            $"Добавленное множество: {string.Join(", ", Sets[(string)ListSets.Items[^1]])}";
                    MessageBox.Show(
                        message,
                        "Подсказка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                TextBoxAmount.Clear();
                MessageBox.Show(
                    "Данное название уже используется! Попробуйте другое",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }

    private void AddSet_Click(object sender, EventArgs e)
    {
        VisibleButtons(false);
        AddSet.Visible = true;
        Choice.Visible = true;

        TextBoxReadOnly.Text = "Введите название множества";
        TextBoxAmount.Clear();
        TextBoxAmount.PlaceholderText = "";

        TextBoxReadOnly.Visible = true;
        TextBoxAmount.Visible = true;

        TextBoxAmount.KeyPress += new KeyPressEventHandler(TextBoxAmount_KeyPress_Name);
    }

    private void ListSets_Enter(object sender, EventArgs e)
    {
        Choice.Enabled = true;
    }

    private void ListSets_Leave(object sender, EventArgs e)
    {
        Choice.Enabled = false;
    }

    private void ListSets_DoubleClick(object sender, EventArgs e)
    {
        if (ListSets.SelectedItem is not null)
        {
            string name = (string)ListSets.SelectedItem;
            string message;
            if (Sets[name].Length == 0) message = $"Множество {name}: пустое";
            else message = $"Множество {name}: {string.Join(", ", Sets[name])}";
            MessageBox.Show(
                     message,
                     "Подсказка",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
        }
    }



    private void OperationButton_Click(object sender, EventArgs e)
    {
        if (sender is null or not Button) return;

        Button button = (Button)sender;
        SetOperation = button.Name switch
        {
            "Union" => SetOperations.Union,
            "Intersection" => SetOperations.Intersection,
            "Difference" => SetOperations.Difference,
            "SymmetricalDifference" => SetOperations.SymmetricalDifference,
            "Negation" => SetOperations.Negation,
            "Bulean" => SetOperations.Bulean,
            _ => SetOperations.Error
        };

        if (SetOperation == SetOperations.Error) return;

        TextBoxTip.Text = Texts[(int)SetOperation][0];

        VisibleButtons(false);

        Buttons[(int)SetOperation].Visible = true;

        Choice.Visible = true;
        TextBoxTip.Visible = true;
        ListSets.Enabled = true;

        Choice.Click += Choice_First_Click;
    }

    private void Choice_First_Click(object sender, EventArgs e)
    {
        if (ListSets.SelectedItem is not null)
        {
            Choice.Click -= Choice_First_Click;

            tempSet = Sets[(string)ListSets.SelectedItem];
            if (tempSet is null) throw new Exception("Choice_First_Click");


            switch (SetOperation)
            {
                case SetOperations.Negation:
                    ListSets.ClearSelected();

                    tempSet = MainBitMask.Negation(tempSet);

                    string message = string.Join(", ", tempSet);
                    if (message == string.Empty) message = "пустое";

                    SaveSet(message);
                    break;


                case SetOperations.Bulean:

                    MessageBox.Show(
                     $"Выберите файл для сохранения булеана",
                     "Внимание",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.None,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);

                    DialogResult dialogResult = saveFile.ShowDialog();
                    if (dialogResult == DialogResult.Cancel)
                    {
                        VisibleButtons(true);

                        TextBoxReadOnly.Visible = false;
                        TextBoxAmount.Clear();
                        TextBoxAmount.Visible = false;

                        TextBoxTip.Visible = false;
                        TextBoxTip.Text = string.Empty;

                        ListSets.Enabled = false;
                        ListSets.ClearSelected();
                        Choice.Enabled = false;

                        tempSet = null;
                        return;
                    }

                    BitMask.ShowBulean(tempSet, saveFile.FileName);

                    MessageBox.Show(
                     $"Успешно сохранено",
                     "Результат",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);


                    VisibleButtons(true);

                    TextBoxReadOnly.Visible = false;
                    TextBoxAmount.Clear();
                    TextBoxAmount.Visible = false;

                    TextBoxTip.Visible = false;
                    TextBoxTip.Text = string.Empty;

                    ListSets.Enabled = false;
                    ListSets.ClearSelected();
                    Choice.Enabled = false;

                    tempSet = null;
                    break;


                case SetOperations.Error:
                    throw new Exception("Choice_First_Click/SetOperations.Error");


                default:
                    TextBoxTip.Text = Texts[(int)SetOperation][1];
                    ListSets.ClearSelected();

                    Choice.Click += Choice_Second_Click;
                    break;
            }
        }
    }

    private void Choice_Second_Click(object sender, EventArgs e)
    {
        if (ListSets.SelectedItem is not null)
        {
            if (tempSet is null) throw new Exception("Null set");
            tempSet = SetOperation switch
            {
                SetOperations.Union =>
                MainBitMask.Union(tempSet, Sets[(string)ListSets.SelectedItem]),

                SetOperations.Intersection =>
                MainBitMask.Intersection(tempSet, Sets[(string)ListSets.SelectedItem]),

                SetOperations.Difference =>
                MainBitMask.Difference(tempSet, Sets[(string)ListSets.SelectedItem]),

                SetOperations.SymmetricalDifference =>
                MainBitMask.SymmetricalDifference(tempSet, Sets[(string)ListSets.SelectedItem]),

                _ => throw new NotImplementedException(
                    "Form1.Choice_Second_Click.switch (SetOperation) invalid value")
            };

            if (tempSet is null) throw new Exception("Choice_Second_Click");

            Choice.Click -= Choice_Second_Click;

            string message = string.Join(", ", tempSet);
            if (message == string.Empty) message = "пустое";

            SaveSet(message);
        }
    }

    private void SaveSet(string message)
    {
        DialogResult result = MessageBox.Show(
                     $"Полученное множество: {message}.\r\nЖелаете сохранить его?",
                     "Результат",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);

        if (result == DialogResult.Yes)
        {
            TextBoxReadOnly.Text = "Введите название множества";
            TextBoxAmount.Clear();
            TextBoxAmount.PlaceholderText = "";

            TextBoxReadOnly.Visible = true;
            TextBoxAmount.Visible = true;

            TextBoxTip.Visible = false;
            TextBoxTip.Text = string.Empty;

            ListSets.Enabled = false;
            ListSets.ClearSelected();
            Choice.Enabled = false;

            TextBoxAmount.KeyPress += new KeyPressEventHandler(TextBoxAmount_KeyPress_Name);
        }
        else
        {
            VisibleButtons(true);

            TextBoxReadOnly.Visible = false;
            TextBoxAmount.Clear();
            TextBoxAmount.Visible = false;

            TextBoxTip.Visible = false;
            TextBoxTip.Text = string.Empty;

            ListSets.Enabled = false;
            ListSets.ClearSelected();
            Choice.Enabled = false;

            tempSet = null;
        }
    }
}
