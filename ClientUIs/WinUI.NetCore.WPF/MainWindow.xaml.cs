using System.Text;
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
using ClientServices.Dtos;

namespace WinUI.NetCore.WPF
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

        private async void ButtonLoadData_OnClick(object sender, RoutedEventArgs e)
        {
            // cast items into a list of TodoItemDto
            var items = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // check if the items is not null
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