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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login(object sender, RoutedEventArgs e)


        {

            ExaminationEntities1 context = new ExaminationEntities1();
            //if (isStudent.IsChecked == true)
            //{
            //    string namestudent = txtUserId.Text.ToString();
            //    string passwordstudent = txtPassword.Password.ToString();

            //    var query
            //        = from student in context.students
            //          join users in context.users
            //          on student.StuEmail equals users.Email
            //          select new { users.Email, users.Password };



            //    foreach (var item in query)
            //    {
            //        if (item.Email == namestudent && item.Password == passwordstudent)
            //        {
            //            MessageBox.Show("welcome");
            //        }
            //        else
            //        {
            //            MessageBox.Show("te user name or password is invalid");
            //        }
            //    }



            //}
            //else if (isinstructor.IsChecked == true)
            //{
            //    string namestructor = txtUserId.Text.ToString();
            //    string passwordstructor = txtPassword.Password.ToString();

            //    var query
            //        = from managers in context.instructors
            //          join instructors in context.users
            //         on managers.InsEmail equals instructors.Email
            //          where instructors.Type == "instructor"
            //          select new { instructors.Email, instructors.Password, instructors.Type }; 


            //    foreach (var item in query)
            //    {
            //        if (item.Email == namestructor && item.Password == passwordstructor)
            //        {
            //            InstructorDashboard formInstructor = new InstructorDashboard(txtUserId.Text);
            //            formInstructor.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("te user name or password is invalid");
            //        }
            //    }
            //}
            //else if  (ismanager.IsChecked == true)
            //{
            //    string namemanager = txtUserId.Text.ToString();
            //    string passwordmanager = txtPassword.Password.ToString();

            //    var query
            //         = from managers in context.instructors
            //           join instructors in context.users
            //          on managers.InsEmail equals instructors.Email
            //           where instructors.Type == "manager"
            //           select new { instructors.Email, instructors.Password, instructors.Type };

            //    foreach (var item in query)
            //    {
            //        if (item.Email == namemanager && item.Password == passwordmanager)
            //        {
            //            MessageBox.Show("welcome manager");
            //        }

            //         else
            //        {
            //        MessageBox.Show("te user name or password is invalid");
            //    }
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("please select type");
            //}
            string namestudent = txtUserId.Text.ToString();
            string passwordstudent = txtPassword.Password.ToString();

            if (isinstructor.IsChecked == true)
            {
                user query = (from user in context.users
                              where user.Email == namestudent && user.Password == passwordstudent && user.Type == "instructor"
                              select user).FirstOrDefault();
                if (query != null)
                {
                    InstructorDashboard formInstructor = new InstructorDashboard(txtUserId.Text);
                    formInstructor.Show();
                    //ManagerDashboard i = new ManagerDashboard();
                    //i.Show();
                    //StudentDashboard u = new StudentDashboard();
                    //u.Show();
                }
                else
                    MessageBox.Show("error");
            }
            else if (ismanager.IsChecked == true)
            {
                user query = (from user in context.users
                              where user.Email == namestudent && user.Password == passwordstudent && user.Type == "manager"
                              select user).FirstOrDefault();
                if (query != null)
                {
                    ManagerDashboard formInstructor = new ManagerDashboard();
                    formInstructor.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("error");

            }
            else if (isStudent.IsChecked == true)
            {
                user query = (from user in context.users
                              where user.Email == namestudent && user.Password == passwordstudent && user.Type == "student"
                              select user).FirstOrDefault();
                if (query != null)
                {
                    StudentDashboard s = new StudentDashboard(txtUserId.Text);
                    s.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("error");

            }
        }
    }
}
