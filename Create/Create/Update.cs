using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Create
{
    public partial class Update : Form
    {
        private StudentManagement Business;
        private int Student_Id;
        public Update(int id)
        {
            InitializeComponent();
            this.Business = new StudentManagement();
            this.Student_Id = id;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateStudentForm_Load;
        }
        void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var student = this.Business.GetStudent(this.Student_Id);
            this.txtCode.Text = student.Code;
            this.txtName.Text = student.Name;
            this.rdbFemale.Checked = true;
            if (student.Gender == true)
            {
                this.rdbMale.Checked = true;
            }
            this.txtHomeTown.Text = student.Home_town;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var gender = true;
            if (rdbFemale.Checked == true)
            {
                gender = false;
            }
            var hometown = this.txtHomeTown.Text;
            this.Business.UpdateStudent(this.Student_Id,code,name,hometown,gender);
            MessageBox.Show("Update student successfuly");
            this.Close();
        }
    }
}
