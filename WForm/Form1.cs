using BusinessLogicLayer;
using DTOModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm
{
    public partial class Form1 : Form
    {
        protected StoreService _StoreService;
        protected List<userDTO> users;

        public Form1()
        {
            _StoreService = new StoreService();
            users = _StoreService.GetAllStudent();
            UpdateStudentList();

            InitializeComponent();
        }
        private void UpdateStudentList()
        {
            BindingList<userDTO> bindingList = new BindingList<userDTO>(users);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = bindingList;

            dataGridView1_CellContentClick.DataSource = bindingSource;
            userNavigator.BindingSource = bindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
