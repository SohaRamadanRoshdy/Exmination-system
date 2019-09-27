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
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for ManagerDashboard.xaml
    /// </summary>
    public partial class ManagerDashboard : Window
    {
        ExaminationEntities1 context3 = new ExaminationEntities1();
        public List<branch> getAllBranches()
        {
            var query = (from branch in context3.branches
                         select branch).ToList();
            return query;
        }
        public List<intake> getAllIntakes()
        {
            var query1 = (from intake in context3.intakes
                          select intake).ToList();
            return query1;
        }
        //public List<T> getAllTrackes()
        //{
        //    var query2 = (from track in context3.tracks
        //                 select new {
        //                     Year = track.Year ,
        //                     TrackName = track.TrackName,
        //                 }).ToList();
        //    return query2;
        //}
        int z = 1;
        public ManagerDashboard()
        {
            InitializeComponent();
            var query2 = (from track in context3.tracks
                          select new
                          {
                              TrackId = track.TrackId,
                              Year = track.Year,
                              TrackName = track.TrackName,
                          }).ToList();

            var query1 = (from intake in context3.intakes
                          select new
                          {
                              IntakeNo = intake.IntakeNo,
                              IntakeNumber = intake.IntakeNumber,
                              Year = intake.Year
                          }).ToList();

            var query3 = (from branches in context3.branches
                          select new
                          {
                              BranchId = branches.BranchId,
                              Name = branches.Name,
                              Year = branches.Year
                          }).ToList();

            List<IntakeClass> ListOfIntakeNumber = new List<IntakeClass>();
            List<TrackClass> ListOfTrackNumber = new List<TrackClass>();
            List<BranchClass> ListOfBranchNumber = new List<BranchClass>();

            foreach (var item in query1)
            {
                IntakeClass newIntake = new IntakeClass();
                newIntake.IntakeNo = item.IntakeNo;
                newIntake.IntakeNumber = item.IntakeNumber;
                newIntake.Year = item.Year;
                ListOfIntakeNumber.Add(newIntake);
            }


            foreach (var item in ListOfIntakeNumber)
            {
                intakesViewList.Items.Add(item);
            }

            foreach (var item in query2)
            {
                TrackClass newTrack = new TrackClass();
                newTrack.TrackId = item.TrackId;
                newTrack.TrackName = item.TrackName;
                newTrack.Year = item.Year;
                ListOfTrackNumber.Add(newTrack);
            }


            foreach (var item in ListOfTrackNumber)
            {
                track.Items.Add(item);
            }

            foreach (var item in query3)
            {
                BranchClass newBranch = new BranchClass();
                newBranch.BranchId = item.BranchId;
                newBranch.Name = item.Name;
                newBranch.Year = item.Year;
                ListOfBranchNumber.Add(newBranch);
            }


            foreach (var item in ListOfBranchNumber)
            {
                branch.Items.Add(item);
            }

            //intakes.ItemsSource =  query1;
            //branch.ItemsSource = getAllBranches();
            //track.ItemsSource = query2;


        }
        public ManagerDashboard(string username)
        {
            InitializeComponent();
            var query2 = (from track in context3.tracks
                          select new
                          {
                              TrackId = track.TrackId,
                              Year = track.Year,
                              TrackName = track.TrackName,
                          }).ToList();

            var query1 = (from intake in context3.intakes
                          select new
                          {
                              IntakeNo = intake.IntakeNo,
                              IntakeNumber = intake.IntakeNumber,
                              Year = intake.Year
                          }).ToList();

            var query3 = (from branches in context3.branches
                          select new
                          {
                              BranchId = branches.BranchId,
                              Name = branches.Name,
                              Year = branches.Year
                          }).ToList();

            List<IntakeClass> ListOfIntakeNumber = new List<IntakeClass>();
            List<TrackClass> ListOfTrackNumber = new List<TrackClass>();
            List<BranchClass> ListOfBranchNumber = new List<BranchClass>();

            foreach (var item in query1)
            {
                IntakeClass newIntake = new IntakeClass();
                newIntake.IntakeNo = item.IntakeNo;
                newIntake.IntakeNumber = item.IntakeNumber;
                newIntake.Year = item.Year;
                ListOfIntakeNumber.Add(newIntake);
            }


            foreach (var item in ListOfIntakeNumber)
            {
                intakesViewList.Items.Add(item);
            }

            foreach (var item in query2)
            {
                TrackClass newTrack = new TrackClass();
                newTrack.TrackId = item.TrackId;
                newTrack.TrackName = item.TrackName;
                newTrack.Year = item.Year;
                ListOfTrackNumber.Add(newTrack);
            }


            foreach (var item in ListOfTrackNumber)
            {
                track.Items.Add(item);
            }

            foreach (var item in query3)
            {
                BranchClass newBranch = new BranchClass();
                newBranch.BranchId = item.BranchId;
                newBranch.Name = item.Name;
                newBranch.Year = item.Year;
                ListOfBranchNumber.Add(newBranch);
            }


            foreach (var item in ListOfBranchNumber)
            {
                branch.Items.Add(item);
            }

            //intakes.ItemsSource =  query1;
            //branch.ItemsSource = getAllBranches();
            //track.ItemsSource = query2;


        }
        private void department(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(departments, ++z);
        }

        private void all_instructors(object sender, RoutedEventArgs e)
        {

            Canvas.SetZIndex(instructors, ++z);
        }

        private void all_courses(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(courses, ++z);
        }

        private void all_students(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(students, ++z);

        }

        private void intakes_GotFocus(object sender, RoutedEventArgs e)
        {
        }
        

        private void intakesViewList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void branch_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void instructorcourse_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
              (from c in context3.instructors
               select c.FirstName).ToList();

            foreach (var item in query)
            {
                instructorcourse.Items.Add(item.ToString());
            }
        }

        private void coursess_Loaded(object sender, RoutedEventArgs e)
        {
            List<corseadd> newcourse = new List<corseadd>();

            var query =
                (from q in context3.courses
                 select q).ToList();
            var query2 =
                (from c in context3.instructors
                 select new { c.FirstName, c.InsId }
                ).ToList();

            foreach (var item in query)
            {
                corseadd addinstance = new corseadd();
                addinstance.CourseId = item.CourseId;
                addinstance.Name = item.Name;
                addinstance.Description = item.Description;
                addinstance.MaxDegree = item.MaxDegree;
                addinstance.MinDegree = item.MinDegree;

                rel_instructor_cource instructorId = context3.rel_instructor_cource.Where(em => em.CourseId == item.CourseId).FirstOrDefault();
                foreach (var item2 in query2)
                {
                    if (instructorId.InsId == item2.InsId)
                    {
                        addinstance.instructorName = item2.FirstName;
                    }
                }
                newcourse.Add(addinstance);
                coursess.Items.Add(addinstance);
            }
        }

        private void addcourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                corseadd newcourse = new corseadd();

                newcourse.Name = coursename.Text.ToString();

                newcourse.MaxDegree = 100;

                newcourse.instructorName = instructorcourse.SelectedItem.ToString();

                instructor newins = context3.instructors.Where(em => em.FirstName == newcourse.instructorName).FirstOrDefault();

                rel_instructor_cource newcourseinstructor = new rel_instructor_cource();


                course newCourseAdd = new course();
                newCourseAdd.Name = coursename.Text.ToString();
                newCourseAdd.MinDegree = 50;
                newCourseAdd.MaxDegree = 100;
                newCourseAdd.Description = coursename.Text.ToString() + "is important";
                context3.courses.Add(newCourseAdd);
                context3.SaveChanges();
                newcourseinstructor.CourseId = newCourseAdd.CourseId;
                newcourseinstructor.InsId = newins.InsId;
                newcourseinstructor.Year = DateTime.Now;

                context3.rel_instructor_cource.Add(newcourseinstructor);
                context3.SaveChanges();
                coursess.Items.Add(newcourse);
            }
            catch(Exception f)
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void editcourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                corseadd selectedcrs = coursess.SelectedItem as corseadd;
                selectedcrs.Name = coursename.Text.ToString();
                selectedcrs.MaxDegree = short.Parse(degreee.Text.ToString());
                selectedcrs.instructorName = instructorcourse.SelectedItem.ToString();

                instructor newins = context3.instructors.Where(em => em.FirstName == selectedcrs.instructorName).FirstOrDefault();

                course updatecourse =
                    (from cr in context3.courses
                     where cr.Name == selectedcrs.Name && cr.MaxDegree == selectedcrs.MaxDegree
                     select cr).FirstOrDefault();
                updatecourse.Name = coursename.Text.ToString();
                updatecourse.MaxDegree = short.Parse(degreee.Text.ToString());
                updatecourse.MinDegree = 50;
                updatecourse.Description = updatecourse.Name + " is important";

                context3.SaveChanges();

                rel_instructor_cource updatecourseandinstructor = context3.rel_instructor_cource.Where(em => em.CourseId == updatecourse.CourseId).FirstOrDefault();
                updatecourseandinstructor.InsId = newins.InsId;
                context3.SaveChanges();
            }
            catch (Exception k)
            {

            }
        }

        private void coursess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            corseadd selectedcrs = coursess.SelectedItem as corseadd;
            coursename.Text = selectedcrs.Name;
            degreee.Text = selectedcrs.MaxDegree.ToString();
            instructorcourse.SelectedItem = selectedcrs.instructorName;
        }

        private void coursess_Loaded_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void courses_Loaded(object sender, RoutedEventArgs e)
        {
            List<corseadd> newcourse = new List<corseadd>();

            var query =
                (from q in context3.courses
                 select q).ToList();


            foreach (var item in query)
            {
                var query2 =
                        (from c in context3.instructors
                         join t in context3.rel_instructor_cource
                         on c.InsId equals t.InsId
                         where t.CourseId == item.CourseId
                         select new { c.FirstName, c.InsId }
                        ).FirstOrDefault();
                corseadd addinstance = new corseadd();
                addinstance.CourseId = item.CourseId;
                addinstance.Name = item.Name;
                addinstance.Description = item.Description;
                addinstance.MaxDegree = item.MaxDegree;
                addinstance.MinDegree = item.MinDegree;

                //rel_instructor_cource instructorId = context3.rel_instructor_cource.Where(em => em.CourseId == item.CourseId).First();
                //foreach (var item2 in query2)
                //{
                    //if (instructorId.InsId == item2.InsId)
                  //  {
                if(query2 != null)
                {
                    addinstance.instructorName = query2.FirstName;
                }
                else
                {
                    addinstance.instructorName = "No Instructor Assigned";
                }
                //}
                // }
                newcourse.Add(addinstance);
                coursess.Items.Add(addinstance);
            }
        }

        private void branchName_Loaded(object sender, RoutedEventArgs e)
        {
            var queryBracnh =
              (from c in context3.branches
               select c.Name).ToList();

            foreach (var item in queryBracnh)
            {
                branchName.Items.Add(item.ToString());
            }
        }

        private void addinstructor_Click(object sender, RoutedEventArgs e)
        {
            showInstrctor newinst = new showInstrctor();
            newinst.FirstName = instructorname.Text.ToString();
            newinst.Branchname = branchName.SelectedItem.ToString();
            newinst.Salary = decimal.Parse(salaryName.Text.ToString());

            instructor NewInstructorWasAdded = new instructor();
            user NewUserWasAdded = new user();

            NewUserWasAdded.Password = newinst.FirstName;
            NewUserWasAdded.Type = "instructor";
            NewUserWasAdded.Email = newinst.FirstName + "@gmail.com";
            context3.users.Add(NewUserWasAdded);
            context3.SaveChanges();

            int query =
                (from c in context3.branches
                 where c.Name == newinst.Branchname
                 select c.BranchId).FirstOrDefault();
            instructor newInstructorIsAdded = new instructor();
            newInstructorIsAdded.InsEmail = NewUserWasAdded.Email;

            newInstructorIsAdded.ManagerId = 1;
            newInstructorIsAdded.FirstName = newinst.FirstName;
            newInstructorIsAdded.LastName = newinst.FirstName;
            newInstructorIsAdded.MaritalStatus = "married";
            newInstructorIsAdded.BirthDate = DateTime.Now;
            newInstructorIsAdded.HireDate = DateTime.Now;
            newInstructorIsAdded.Job = "instructor";
            newInstructorIsAdded.Salary = newinst.Salary;
            newInstructorIsAdded.Branchid = query;
            context3.instructors.Add(newInstructorIsAdded);
            context3.SaveChanges();
            instructorss.Items.Add(newinst);
        }

        private void removeinstructor_Click(object sender, RoutedEventArgs e)
        {

            decimal x = decimal.Parse(salaryName.Text.ToString());

            int query =
                (from c in context3.branches
                 where c.Name == branchName.SelectedItem.ToString()
                 select c.BranchId).FirstOrDefault();

            instructor deleteinstructor =
               (from ins in context3.instructors
                where ins.FirstName == instructorname.Text.ToString() && ins.Salary == x
                && ins.Branchid == query
                select ins).FirstOrDefault();

            context3.instructors.Remove(deleteinstructor);
            context3.SaveChanges();
            showInstrctor removeFromList = new showInstrctor();
            removeFromList.FirstName = instructorname.Text.ToString();
            removeFromList.Branchname = branchName.SelectedItem.ToString();
            removeFromList.Salary = x;


            instructorss.Items.Remove(removeFromList);

        }

        private void updateinstructor_Click(object sender, RoutedEventArgs e)
        {
            showInstrctor updated = new showInstrctor();
            updated = instructorss.SelectedItem as showInstrctor;

            int query =
                (from c in context3.branches
                 where c.Name == branchName.SelectedItem.ToString()
                 select c.BranchId).FirstOrDefault();

            int query2 =
               (from c in context3.branches
                where c.Name == updated.Branchname
                select c.BranchId).FirstOrDefault();

            instructor deleteinstructor =
              (from ins in context3.instructors
               where ins.FirstName == updated.FirstName && ins.Salary == updated.Salary
               && ins.Branchid == query2
               select ins).FirstOrDefault();

            decimal x = decimal.Parse(salaryName.Text.ToString());

            deleteinstructor.FirstName = instructorname.Text.ToString();
            deleteinstructor.Salary = x;
            deleteinstructor.Branchid = query;

            context3.SaveChanges();
        }

        private void instructorss_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
               (from instructorInfo in context3.instructors
                select instructorInfo).ToList();

            List<showInstrctor> instructorclass = new List<showInstrctor>();
            var query2 =
               (from c in context3.branches
                select c).ToList();

            foreach (var item in query)
            {
                showInstrctor inst = new showInstrctor();
                inst.Salary = item.Salary;
                inst.Branchid = item.Branchid;
                inst.FirstName = item.FirstName;

                foreach (var item2 in query2)
                {
                    if (item.Branchid == item2.BranchId)
                    {
                        inst.Branchname = item2.Name;

                    }
                }
                instructorclass.Add(inst);

            }



            foreach (var item in instructorclass)
            {

                instructorss.Items.Add(item);
            }
        }

        private void instructorss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showInstrctor up = new showInstrctor();
            up = instructorss.SelectedItem as showInstrctor;
            instructorname.Text = up.FirstName;
            branchName.SelectedItem = up.Branchname;
            salaryName.Text = up.Salary.ToString();
        }

        private void intakestudent_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            (from intakes in context3.intakes
             select intakes.IntakeNumber).ToList();

            foreach (var item in query)
            {
                intakestudent.Items.Add(item.ToString());
            }
        }

        private void branchstudent_Loaded(object sender, RoutedEventArgs e)
        {

            var query =
             (from branche in context3.branches
              select branche.Name).ToList();

            foreach (var item in query)
            {
                branchstudent.Items.Add(item.ToString());
            }
        }

        private void tracksstudent_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            (from tracke in context3.tracks
             select tracke.TrackName).ToList();

            foreach (var item in query)
            {
                tracksstudent.Items.Add(item.ToString());
            }
        }

        private void addstudent_Click(object sender, RoutedEventArgs e)
        {
            track addtrackstudent = new track();
            intake addintakstudent = new intake();
            branch addbranchstudent = new branch();
            user studentuser = new user();
            rel_branch_track_intake ITb = new rel_branch_track_intake();

            student newstudent = new student();
            newstudent.StuId = int.Parse(idstudent.Text.ToString());
            newstudent.FirstName = studentFirstName.Text.ToString();
            newstudent.LastName = lastnamestudent.Text.ToString();
            newstudent.BirthDate = datestudent.DisplayDate;
            newstudent.StuEmail = emailstudent.Text.ToString();
            newstudent.MatrailStatus = "single";
            newstudent.JoinDate = DateTime.Now;
            addbranchstudent.Year = DateTime.Now;
            addbranchstudent.Name = branchstudent.SelectedItem.ToString();
            addtrackstudent.Year = DateTime.Now;
            addtrackstudent.TrackName = tracksstudent.SelectedItem.ToString();
            addintakstudent.IntakeNumber = int.Parse(intakestudent.SelectedItem.ToString());
            addintakstudent.Year = DateTime.Now;
            ShowStudentData newstudentwasadded = new ShowStudentData();
            newstudentwasadded.StuId = int.Parse(idstudent.Text.ToString());
            newstudentwasadded.StuEmail = emailstudent.Text.ToString();
            newstudentwasadded.FirstName = studentFirstName.Text.ToString();
            newstudentwasadded.LastName = lastnamestudent.Text.ToString();
            newstudentwasadded.Track = tracksstudent.SelectedItem.ToString();
            newstudentwasadded.Intake = int.Parse(intakestudent.SelectedItem.ToString());
            newstudentwasadded.Branch = branchstudent.SelectedItem.ToString();
            newstudentwasadded.BirthDate = DateTime.Now;

            studentuser.Email = newstudent.StuEmail;
            studentuser.Password = passswordstudent.Text.ToString();
            studentuser.Type = "student";


            int branchFindId
                = (from branches in context3.branches
                   where branches.Name == addbranchstudent.Name
                   select branches.BranchId).FirstOrDefault();

            int trackFindId
                =
                (from trackID in context3.tracks
                 where trackID.TrackName == addtrackstudent.TrackName
                 select trackID.TrackId).FirstOrDefault();

            int intakeFindId
                =
                (from intakeId in context3.intakes
                 where intakeId.IntakeNumber == addintakstudent.IntakeNumber
                 select intakeId.IntakeNo
                ).FirstOrDefault();

            ITb.intack = intakeFindId;
            ITb.trackID = trackFindId;
            ITb.branchID = branchFindId;


            int findITB =
            (
                from TIB in context3.rel_branch_track_intake
                where TIB.branchID == branchFindId && TIB.trackID == trackFindId && TIB.intack == intakeFindId
                select TIB.id
            ).Count();
            int lastindexOfTIB;
            lastindexOfTIB =
                       (from lastindexes in context3.rel_branch_track_intake
                        select lastindexes).Count();
            MessageBox.Show(lastindexOfTIB.ToString());
            if (findITB > 0)
            {
                int findITB2 =
            (
                from TIB in context3.rel_branch_track_intake
                where TIB.branchID == branchFindId && TIB.trackID == trackFindId && TIB.intack == intakeFindId
                select TIB.id
            ).FirstOrDefault();
                newstudent.ITBid = findITB2;
                context3.users.Add(studentuser);
                context3.students.Add(newstudent);
                context3.SaveChanges();
                lvUsers.Items.Add(newstudentwasadded);
            }
            else
            {
                newstudent.ITBid = lastindexOfTIB;
                ITb.id = lastindexOfTIB;
                context3.rel_branch_track_intake.Add(ITb);
                context3.SaveChanges();
                context3.users.Add(studentuser);
                context3.students.Add(newstudent);
                context3.SaveChanges();
                lvUsers.Items.Add(newstudentwasadded);
            }
        }

        private void editstudent_Click(object sender, RoutedEventArgs e)
        {
            ShowStudentData studentSelected = new ShowStudentData();
            studentSelected = lvUsers.SelectedItem as ShowStudentData;

            studentSelected.StuId = int.Parse(idstudent.Text.ToString());
            studentSelected.FirstName = studentFirstName.Text.ToString();
            studentSelected.LastName = lastnamestudent.Text.ToString();
            studentSelected.BirthDate = datestudent.DisplayDate;
            studentSelected.StuEmail = emailstudent.Text.ToString();
            studentSelected.Branch = branchstudent.SelectedItem.ToString();
            
            studentSelected.Track = tracksstudent.SelectedItem.ToString();
            studentSelected.Intake = int.Parse(intakestudent.SelectedItem.ToString());
            rel_branch_track_intake newaddedstudent = new rel_branch_track_intake();

            var getIntack =
                (from Ik in context3.intakes
                 select Ik).ToList();
            var getTrack =
                (from Ik in context3.tracks
                 select Ik).ToList();
            var getBracnh =
                (from Ik in context3.branches
                 select Ik).ToList();
            // but intake id in table intak student

            foreach (var item2 in getIntack)
            {
                if (studentSelected.Intake == item2.IntakeNumber)
                {
                    studentSelected.IntakeID = item2.IntakeNo;
                }
            }


            // put track name in class track


            foreach (var item2 in getTrack)
            {
                if (studentSelected.Track == item2.TrackName)
                {
                    studentSelected.TrackID = item2.TrackId;
                }
            }

            // put branch name in class branch


            foreach (var item2 in getBracnh)
            {
                if (studentSelected.Branch == item2.Name)
                {
                    studentSelected.BranchID = item2.BranchId;
                }
            }




            int findITB =
            (
                from TIB in context3.rel_branch_track_intake
                where TIB.branchID == studentSelected.BranchID && TIB.trackID == studentSelected.TrackID
                && TIB.intack == studentSelected.IntakeID
                select TIB.id
            ).Count();


            int lastindexOfTIB;


            lastindexOfTIB =
                       (from lastindexes in context3.rel_branch_track_intake
                        select lastindexes).Count();



            student updateStudentInformation =
                (from std in context3.students

                 where std.StuId == studentSelected.StuId
                 select std
                 ).FirstOrDefault();


            user newstudentuser = context3.users.Where(em => em.Email == studentSelected.StuEmail.ToString()).FirstOrDefault();
            newstudentuser.Email = updateStudentInformation.StuEmail;
            newstudentuser.Password = passswordstudent.Text.ToString();

            context3.SaveChanges();

            int findITB3 =
            (
               from TIB in context3.rel_branch_track_intake
               where TIB.branchID == studentSelected.BranchID && TIB.trackID == studentSelected.TrackID
               && TIB.intack == studentSelected.IntakeID
               select TIB.id
           ).FirstOrDefault();

            if (findITB > 0)
            {
                updateStudentInformation.StuEmail = studentSelected.StuEmail;
                updateStudentInformation.StuId = studentSelected.StuId;
                updateStudentInformation.FirstName = studentSelected.FirstName;
                updateStudentInformation.LastName = studentSelected.LastName;
                updateStudentInformation.BirthDate = DateTime.Now;
                updateStudentInformation.JoinDate = DateTime.Now;
                updateStudentInformation.MatrailStatus = "single";

                updateStudentInformation.ITBid = findITB3;
                 context3.SaveChanges();


            }
            else
            {
                updateStudentInformation.StuEmail = studentSelected.StuEmail;
                updateStudentInformation.StuId = studentSelected.StuId;
                updateStudentInformation.FirstName = studentSelected.FirstName;
                updateStudentInformation.LastName = studentSelected.LastName;
                updateStudentInformation.BirthDate = DateTime.Now;
                updateStudentInformation.JoinDate = DateTime.Now;
                updateStudentInformation.MatrailStatus = "single";
                newaddedstudent.trackID = studentSelected.TrackID;
                newaddedstudent.branchID = studentSelected.BranchID;
                newaddedstudent.intack = studentSelected.IntakeID;
                context3.rel_branch_track_intake.Add(newaddedstudent);
                updateStudentInformation.ITBid = newaddedstudent.id;
                context3.SaveChanges();


            }



        }

        private void lvUsers_Loaded(object sender, RoutedEventArgs e)
        {
            List<ShowStudentData> ShowStudentData = new List<ShowStudentData>();
            var query
                = (from std in context3.students
                   select std).ToList();

            foreach (var item in query)
            {
                ShowStudentData DataStudent = new ShowStudentData();
                DataStudent.BirthDate = item.BirthDate;
                DataStudent.StuEmail = item.StuEmail;
                DataStudent.JoinDate = item.JoinDate;
                DataStudent.FirstName = item.FirstName;
                DataStudent.LastName = item.LastName;
                DataStudent.ITBid = item.ITBid;
                DataStudent.MatrailStatus = item.MatrailStatus;
                DataStudent.StuId = item.StuId;
                ShowStudentData.Add(DataStudent);
            }
            var query2 =
                (from ITBtable in context3.rel_branch_track_intake
                 select ITBtable).ToList();


            foreach (var item in ShowStudentData)
            {

                foreach (var item2 in query2)
                {
                    if (item.ITBid == item2.id)
                    {
                        item.BranchID = item2.branchID;
                        item.TrackID = item2.trackID;
                        item.IntakeID = item2.intack;

                    }
                }
            }

            var getIntack =
                (from Ik in context3.intakes
                 select Ik).ToList();
            var getTrack =
                (from Ik in context3.tracks
                 select Ik).ToList();
            var getBracnh =
                (from Ik in context3.branches
                 select Ik).ToList();

            // but intake id in table intak student
            foreach (var item in ShowStudentData)
            {
                foreach (var item2 in getIntack)
                {
                    if (item.IntakeID == item2.IntakeNo)
                    {
                        item.Intake = item2.IntakeNumber;
                    }
                }
            }

            // put track name in class track

            foreach (var item in ShowStudentData)
            {
                foreach (var item2 in getTrack)
                {
                    if (item.TrackID == item2.TrackId)
                    {
                        item.Track = item2.TrackName;
                    }
                }
            }
            // put branch name in class branch

            foreach (var item in ShowStudentData)
            {
                foreach (var item2 in getBracnh)
                {
                    if (item.BranchID == item2.BranchId)
                    {
                        item.Branch = item2.Name;
                    }
                }
            }


            foreach (var item in ShowStudentData)
            {
                lvUsers.Items.Add(item);
            }

        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowStudentData studentSelected = new ShowStudentData();
            studentSelected = lvUsers.SelectedItem as ShowStudentData;

            idstudent.Text = studentSelected.StuId.ToString();
            studentFirstName.Text = studentSelected.FirstName;
            lastnamestudent.Text = studentSelected.LastName;
            datestudent.DisplayDate = studentSelected.BirthDate;
            emailstudent.Text = studentSelected.StuEmail;
            intakestudent.SelectedItem = studentSelected.Intake;
            tracksstudent.SelectedItem = studentSelected.Track;
            branchstudent.SelectedItem = studentSelected.Branch;
                
        }

        private void intakesViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IntakeClass intakeSelected = new IntakeClass();


            intakeSelected = intakesViewList.SelectedItem as IntakeClass;


            Intake_NumberTextBox.Text = intakeSelected.IntakeNumber.ToString();
            // intakdate.DisplayDate.Year = intakeSelected.Year;
            intakdate.Text = intakeSelected.Year.ToString();
        }

        private void AddIntake_Click(object sender, RoutedEventArgs e)
        {
            IntakeClass intakeAdd = new IntakeClass();
            intakeAdd.IntakeNumber = int.Parse(Intake_NumberTextBox.Text.ToString());
            intakeAdd.Year = intakdate.DisplayDate;
            //var counter = 1;
            var IntakeAddedToDataBase = new intake
            {
                IntakeNumber = intakeAdd.IntakeNumber,
                Year = intakdate.DisplayDate,
            };
            context3.intakes.Add(IntakeAddedToDataBase);
            context3.SaveChanges();
            intakesViewList.Items.Add(IntakeAddedToDataBase);
        }

        private void UpdateIntake_Click(object sender, RoutedEventArgs e)
        {
            IntakeClass intakeselect = new IntakeClass();
            intakeselect = intakesViewList.SelectedItem as IntakeClass;


            var query =
               (from intake in context3.intakes
                where intake.IntakeNumber == intakeselect.IntakeNumber
                select intake).FirstOrDefault();


            intake intakesupdated = context3.intakes.Where(em => em.IntakeNo == query.IntakeNo).FirstOrDefault();
            intakesupdated.IntakeNumber = int.Parse(Intake_NumberTextBox.Text.ToString());
            intakesupdated.Year = DateTime.Now;
            context3.SaveChanges();


        }

        private void RemoveIntake_Click(object sender, RoutedEventArgs e)
        {

            IntakeClass intakeselect = new IntakeClass();
            intakeselect = intakesViewList.SelectedItem as IntakeClass;


            var query =
               (from intake in context3.intakes
                where intake.IntakeNumber == intakeselect.IntakeNumber
                select intake).FirstOrDefault();


            intake intakesupdated = context3.intakes.Where(em => em.IntakeNo == query.IntakeNo).FirstOrDefault();
            context3.intakes.Remove(intakesupdated);
            context3.SaveChanges();
        }

        private void AddBranch_Click(object sender, RoutedEventArgs e)
        {

            BranchClass newBracnh = new BranchClass();
            newBracnh.Name = BranchLocation_textbox.Text.ToString();
            newBracnh.Year = branchdate.DisplayDate;
            var counter = 1;
            var BranchAddedToDataBase = new branch
            {
                BranchId = (++counter),
                Name = newBracnh.Name,
                Year = newBracnh.Year,
            };
            context3.branches.Add(BranchAddedToDataBase);
            context3.SaveChanges();
            branch.Items.Add(BranchAddedToDataBase);

        }

        private void updateBranch_Click(object sender, RoutedEventArgs e)
        {
            BranchClass branchselect = new BranchClass();
            branchselect = branch.SelectedItem as BranchClass;


            var query =
               (from branch in context3.branches
                where branch.Name == branchselect.Name
                select branch).FirstOrDefault();


            branch branchesupdated = context3.branches.Where(em => em.Name == query.Name).FirstOrDefault();
            branchesupdated.Name = (BranchLocation_textbox.Text.ToString());
            branchesupdated.Year = DateTime.Now;
            context3.SaveChanges();

        }

        private void removeBanch_Click(object sender, RoutedEventArgs e)
        {

            BranchClass brancheselect = new BranchClass();
            brancheselect = branch.SelectedItem as BranchClass;


            var query =
               (from branch in context3.branches
                where branch.Name == brancheselect.Name
                select branch).FirstOrDefault();


            branch branchesupdated = context3.branches.Where(em => em.Name == query.Name).FirstOrDefault();
            context3.branches.Remove(branchesupdated);
            context3.SaveChanges();
        }

        private void Trackadd_Click(object sender, RoutedEventArgs e)
        {
            TrackClass newTrack = new TrackClass();
            newTrack.TrackName = tracKName_textbOX.Text.ToString();
            newTrack.Year = trackdate.DisplayDate;
            var counter = 1;
            var trackAddedToDataBase = new track
            {
                TrackId = (++counter),
                TrackName = newTrack.TrackName,
                Year = newTrack.Year,
            };
            context3.tracks.Add(trackAddedToDataBase);
            context3.SaveChanges();
            track.Items.Add(trackAddedToDataBase);
        }

        private void updatetrack_Click(object sender, RoutedEventArgs e)
        {
            TrackClass trackselect = new TrackClass();
            trackselect = track.SelectedItem as TrackClass;


            var query =
               (from track in context3.tracks
                where track.TrackName == trackselect.TrackName
                select track).FirstOrDefault();


            track tracksupdated = context3.tracks.Where(em => em.TrackName == query.TrackName).FirstOrDefault();
            tracksupdated.TrackName = (tracKName_textbOX.Text.ToString());
            tracksupdated.Year = DateTime.Now;
            context3.SaveChanges();
        }

        private void removetrack_Click(object sender, RoutedEventArgs e)
        {
            TrackClass trackeselect = new TrackClass();
            trackeselect = track.SelectedItem as TrackClass;


            var query =
               (from track in context3.tracks
                where track.TrackName == trackeselect.TrackName
                select track).FirstOrDefault();


            track tracksupdated = context3.tracks.Where(em => em.TrackName == query.TrackName).FirstOrDefault();
            context3.tracks.Remove(tracksupdated);
            context3.SaveChanges();
        }
    }
}
