using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = employees.Select(e => new
            {
                e.ID,
                e.Name,
                e.Age,
                e.Department
            }).ToList();
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtDepartment.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || employees.Any(emp => emp.ID == txtID.Text))
            {
                MessageBox.Show("Invalid or duplicate ID.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Invalid Age.");
                return;
            }

            employees.Add(new Employee
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Age = age,
                Department = txtDepartment.Text
            });

            RefreshGrid();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var employee = employees.FirstOrDefault(emp => emp.ID == txtID.Text);
            if (employee == null)
            {
                MessageBox.Show("Employee not found.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Invalid Age.");
                return;
            }

            employee.Name = txtName.Text;
            employee.Age = age;
            employee.Department = txtDepartment.Text;

            RefreshGrid();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var employee = employees.FirstOrDefault(emp => emp.ID == txtID.Text);
            if (employee != null)
            {
                employees.Remove(employee);
                RefreshGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Select a valid employee.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvEmployees.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
            }
        }
    }

    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
}
