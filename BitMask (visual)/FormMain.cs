namespace BitMask_Visual;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
        tabControl1.TabPages.Clear();
        IsMdiContainer = true;
        FormSetOperations form1 = new();
        AddNewTab(form1);

        FormTranspositions form2 = new();
        AddNewTab(form2);

        tabControl1.SelectedTab = tabControl1.TabPages[0];
    }

    private void AddNewTab(Form child)
    {
        TabPage tab = new(child.Text);
        child.TopLevel = false;
        child.Parent = tab;
        child.Visible = true;
        tabControl1.TabPages.Add(tab);
        child.WindowState = FormWindowState.Normal;
        child.FormBorderStyle = FormBorderStyle.None;
    }
}
