using ClientServices;
using ClientServices.Base;
using ClientServices.Dtos;

namespace MauiDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        ViewModelBase<TodoItemDto> _viewModel = new ViewModelBase<TodoItemDto>(@"https://jsonplaceholder.typicode.com");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {

            // cast items into a list of TodoItemDto
            var items = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // check if the items is not null
            if (items != null)
            {
                if (items.Count >= 1)
                {
                    // add the items to datagrid
                    this.ListViewMain.ItemsSource = items;

                    await DisplayAlert("Success", "Data items loaded from ViewModel!", "OK");
                }
                else
                {
                    await DisplayAlert("Warning", "Data items load failed", "OK");
                }
            }

            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
