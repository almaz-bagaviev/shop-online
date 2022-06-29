using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShopOnline.Views;

public partial class FullTableWindow : Window
{
    FullTableModel fullTableModel;
    
    public FullTableWindow()
    {
        InitializeComponent();
        fullTableModel = new(fullTableDataGrid);
        fullTableModel.FullTable();
    }
}
