using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientServices;
using ClientServices.Base;
using ClientServices.Dtos;

namespace WinForms.NetFx
{
    public partial class MainForm : Form
    {
        //
        ViewModelBase<TodoItemDto> _viewModel = new ViewModelBase<TodoItemDto>(TodoAction.BaseUrl);

        public MainForm()
        {
            InitializeComponent();
        }

        private async void buttonLoadData_Click(object sender, EventArgs e)
        {
            //
            this.dataGridViewTodos.AllowUserToAddRows = false;

            // cast items into a list of TodoItemDto
            var items = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // assert - check if the items is not null
            if (items != null)
            {
                if (items.Count >= 1)
                {
                    // add the items to datagrid
                    this.dataGridViewTodos.DataSource = items;

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
