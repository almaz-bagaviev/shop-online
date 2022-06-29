namespace ShopOnline.Views;

public partial class AddNewClientWindow : Window
{
    DataRow dataRow;

    public AddNewClientWindow()
    {
        InitializeComponent();
    }

    public AddNewClientWindow(DataRow dataRow) : this()
    {
        this.dataRow = dataRow;
        okBtn.Click += delegate
        {
            dataRow[1] = txtLastName.Text;
            dataRow[2] = txtFirstName.Text;
            dataRow[3] = txtMiddleName.Text;
            dataRow[4] = txtPhone.Text;
            dataRow[5] = txtEmail.Text;
            DialogResult = true;
        };

        cancelBtn.Click += delegate
        {
            DialogResult = false;
        };
    }
}
