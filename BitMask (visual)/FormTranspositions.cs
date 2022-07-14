using Practice;

namespace BitMask_Visual;

public partial class FormTranspositions : Form
{
    int[] set;
    SaveFileDialog saveFile;

    public FormTranspositions()
    {
        InitializeComponent();

        saveFile = new();
        saveFile.DefaultExt = "txt";
        saveFile.AddExtension = true;
        saveFile.CheckPathExists = true;
        saveFile.Filter = "Текстовые файлы(*.txt)|*.txt";
        saveFile.Title = "Сохранение";
        saveFile.CreatePrompt = true;
        saveFile.OverwritePrompt = true;

        Lexi.Click += new EventHandler(Button_Click_Order);
        Anti.Click += new EventHandler(Button_Click_Order);
    }

    private void TextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == ((char)Keys.Enter))
        {
            bool canParse = true;
            foreach (var item in TextBoxAmount.Text.Trim().Split(' '))
            { canParse = canParse && int.TryParse(item, out int value); }

            if (TextBoxAmount.Text.Trim() == string.Empty) canParse = false;

            if (canParse)
            {
                string[] chars = TextBoxAmount.Text.Trim().Split(' ');
                HashSet<int> numbers = new();
                int temp;
                foreach (var item in chars)
                {
                    temp = int.Parse(item);
                    if (temp > 0) numbers.Add(temp);
                }
                set = numbers.ToArray();
                Array.Sort(set);



                Lexi.Visible = true;
                Anti.Visible = true;

                TextBoxReadOnly.Text = "Выберите порядок перестановок";
                TextBoxAmount.Enabled = false;
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

    private void Button_Click_Order(object sender, EventArgs e)
    {
        MessageBox.Show(
         $"Выберите файл для сохранения перестановок",
         "Внимание",
         MessageBoxButtons.OK,
         MessageBoxIcon.None,
         MessageBoxDefaultButton.Button1,
         MessageBoxOptions.DefaultDesktopOnly);


        if (saveFile.ShowDialog() == DialogResult.Cancel)
        {
            Lexi.Visible = false;
            Anti.Visible = false;

            TextBoxReadOnly.Text = "Введите элементы множества через пробел";
            TextBoxAmount.Clear();
            TextBoxAmount.Enabled = true;

            return;
        }

        Button button = (Button)sender;

        switch (button.Name)
        {
            case "Lexi":
                Transposition.Write(set, Transposition.Orders.Straight, saveFile.FileName);
                break;
            case "Anti":
                Transposition.Write(set, Transposition.Orders.Anti, saveFile.FileName);
                break;
        }

        MessageBox.Show(
         $"Успешно сохранено",
         "Результат",
         MessageBoxButtons.OK,
         MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button1,
         MessageBoxOptions.DefaultDesktopOnly);

        Lexi.Visible = false;
        Anti.Visible = false;

        TextBoxReadOnly.Text = "Введите элементы множества через пробел";
        TextBoxAmount.Clear();
        TextBoxAmount.Enabled = true;
    }
}
