using ClientServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientServices;
using ClientServices.Base;

namespace WinUI.NetFx.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        ViewModelBase<TodoItemDto> _viewModel = new ViewModelBase<TodoItemDto>(TodoAction.BaseUrl);

        public MainWindow()
        {
            InitializeComponent();
        }


        // get the todos list async
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // cast items into a list of TodoItemDto
            var items = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // assert - check if the items is not null
            if (items != null)
            {
                if (items.Count >= 1)
                {
                    // add the items to datagrid
                    this.DataGridMain.ItemsSource = items;

                    MessageBox.Show("Data items loaded from ViewModel!");
                }
                else
                {
                    MessageBox.Show("Data items load failed");
                }
            }
        }


    }
}
