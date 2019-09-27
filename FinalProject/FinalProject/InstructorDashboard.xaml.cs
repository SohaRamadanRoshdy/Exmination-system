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
    public class studentListView
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Track { set; get; }
    }
    public class examListView
    {
        public int ExamCode { set; get; }
        public string ExamName { set; get; }
        public string Type { set; get; }
        public DateTime Date { set; get; }
    }
    public class checkedd
    {
        private bool chec = true;
        public bool check
        {
            set { chec = value; }
            get { return chec; }
        }
    }
    class Quesition
    {
        public int IDeas { get; set; }
        public String TextQuesition { get; set; }
        public String Type { get; set; }
        public String course { get; set; }
        public int Degree { get; set; }
    }
    class QuestionOfSubmittedExam
    {
        public int StudentId { get; set; }
        public int QustCode { get; set; }
        public int ExamCode { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public string ModelAnswer { get; set; }
        public string Answer { get; set; }
        public double DegreeMark { get; set; }
    }
    class BranchClass
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
    }
    class corseadd
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short MaxDegree { get; set; }
        public short MinDegree { get; set; }
        public string instructorName { get; set; }


    }
    class IntakeClass
    {
        public int IntakeNo { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public int IntakeNumber { get; set; }
    }
    class showInstrctor
    {
        public string FirstName { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public int Branchid { get; set; }
        public string Branchname { get; set; }
    }
    class ShowStudentData
    {
        public string StuEmail { get; set; }
        public int StuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatrailStatus { get; set; }
        public System.DateTime BirthDate { get; set; }
        public System.DateTime JoinDate { get; set; }
        public int ITBid { get; set; }
        public int Intake { get; set; }
        public string Track { get; set; }
        public string Branch { get; set; }

        public int IntakeID { get; set; }
        public int BranchID { get; set; }
        public int TrackID { get; set; }


    }
    class StudentExamListView
    {
        public int ExamCode { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public string Course { set; get; }
        public string Branch { set; get; }
        public int Intake { set; get; }
        public float Grade { set; get; }
        public float MaxDegree { set; get; }
        public float MinDegree { set; get; }
        public DateTime Date { set; get; }
    }
    class TrackClass
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public System.DateTime Year { get; set; }
    }
    /// <summary>
    /// Interaction logic for InstructorDashboard.xaml
    /// </summary>
    public partial class InstructorDashboard : Window
    {
        int z = 1;
        ExaminationEntities1 context2 = new ExaminationEntities1();
        List<int> sID = new List<int>();

        //selected question index
        List<int> SelectedQuestionsss = new List<int>();
        //selected question object
        List<Quesition> QuestionWithGrades = new List<Quesition>();

        //selected student object
        List<int> selecteStudentstoExam = new List<int>();

        //the selected exam to students
        exam selectedExamToStudents = new exam();

        List<string> courses = new List<string>();
        public int ExamDegree { get; set; }
        public int questionsDegree { get; set; }
        string username;
        string CourseNName;
        public List<rel_exam_student> getAllSubmittedStuExams()
        {
            var courseID = (from c in context2.courses
                            where c.Name == CourseNName
                            select c.CourseId).FirstOrDefault();
            var query = (from thisStudent in context2.rel_exam_student
                         join coursee in context2.course_exam
                         on thisStudent.ExamCode equals coursee.Exam_Id
                         where coursee.Course_Id == courseID && thisStudent.Taken == true
                         select thisStudent).ToList();
            return query;
        }
        public void getStuentExamListView()
        {
            List<rel_exam_student> allSubmittedExams = getAllSubmittedStuExams();
            List<StudentExamListView> mySlistview = new List<StudentExamListView>();

            foreach (var item in allSubmittedExams)
            {
                StudentExamListView stuExam = new StudentExamListView();
                exam exam = (from e in context2.exams
                             where e.ExamCode == item.ExamCode
                             select e).FirstOrDefault();
                student stu = (from s in context2.students
                               where s.StuId == item.StuId
                               select s).FirstOrDefault();
                string courseName = CourseNName;
                float grade = 0f;
                stuExam.ExamCode = exam.ExamCode;
                stuExam.Name = stu.StuEmail;
                stuExam.Type = exam.Type;
                stuExam.Branch = "Not Needed";
                stuExam.Intake = 0;
                stuExam.Grade = grade;
                stuExam.MinDegree = exam.MinDegree;
                stuExam.MaxDegree = exam.MaxDegree;
                stuExam.Date = exam.Date;
                mySlistview.Add(stuExam);
                try
                {
                    Studentsexams.Items.Clear();
                }
                catch (Exception rt)
                { }
                Studentsexams.Items.Add(stuExam);
            }


        }
        public List<int> getInstructorCourses()
        {
            // ExaminationEntities cc = new ExaminationEntities();
            //MessageBox.Show(username);
            int query =
                (from instructor in context2.instructors
                 where instructor.InsEmail == username
                 select instructor.InsId).FirstOrDefault();
            // MessageBox.Show(query);

            try
            {
                List<int> query2 =
                    (from courseInstructor in context2.rel_instructor_cource
                     where courseInstructor.InsId == query
                     select courseInstructor.CourseId).ToList();

                return query2;
            }
            catch (Exception er)
            {
                MessageBox.Show("you don't have any courses you can enter the dashboard when you have courses");
                this.Close();
                return new List<int>();
            }
        }
        public void FillInstructorCourseFields()
        {
            List<int> query2 = getInstructorCourses();
            foreach (var item in query2)
            {
                // MessageBox.Show(item.ToString());
                CourseNName =
                             (from coursess in context2.courses
                              where coursess.CourseId == item
                              select coursess.Name).FirstOrDefault();
                //fill all the combo boxes in the instructor form
                IstuctorCourse.Items.Add(CourseNName.ToString());
                examCoure.Items.Add(CourseNName.ToString());
                questionCourse.Items.Add(CourseNName.ToString());
                InstuctorCourse.Items.Add(CourseNName.ToString());
                InstuctorCourse1.Items.Add(CourseNName.ToString());
                InstuctorCourse2.Items.Add(CourseNName.ToString());
                Coure.Items.Add(CourseNName.ToString());
                Course.Items.Add(CourseNName.ToString());
            }
        }
        public List<student> getAllStudentsofCourse(string CourseName)
        {
            int courseID = (from cours in context2.courses
                            where cours.Name == CourseName
                            select cours.CourseId).FirstOrDefault();
            var query = (from student in context2.students
                         join courss in context2.rel_course_student
                         on student.StuId equals courss.StuId
                         where courss.CourseId == courseID
                         select student).ToList();
            return query;
        }
        public List<exam> getAllExamsofCourse(string CourseName)
        {
            int courseID = (from cours in context2.courses
                            where cours.Name == CourseName
                            select cours.CourseId).FirstOrDefault();
            var query = (from exam in context2.exams
                         join courss in context2.course_exam
                         on exam.ExamCode equals courss.Exam_Id
                         where courss.Course_Id == courseID
                         select exam).ToList();
            return query;
        }
        public string getStudentTrack(student item)
        {
            var trackName = (from track in context2.tracks
                             where track.TrackId == (
                             (from itb in context2.rel_branch_track_intake where itb.id == item.ITBid select itb.trackID).FirstOrDefault())
                             select track.TrackName).FirstOrDefault();
            return trackName;
        }
        public InstructorDashboard(string name)
        {
            try
            {
                InitializeComponent();
                username = name;
                FillInstructorCourseFields();
                getStuentExamListView();
                comboBoxofexamType.Items.Add("exam");
                comboBoxofexamType.Items.Add("corrective");
                comboBoxofexamType.SelectedIndex = 1;
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

        }

        public InstructorDashboard()
        {
            try
            {
                InitializeComponent();
                FillInstructorCourseFields();
                comboBoxofexamType.Items.Add("exam");
                comboBoxofexamType.Items.Add("corrective");
                comboBoxofexamType.SelectedIndex = 0;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.ToString());
            }

        }
        ~InstructorDashboard()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        private void add_question(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(allquestions, ++z);
        }

        private void add_exam(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(allexams, ++z);
        }

        private void assign_student_to_Exam(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(examsonsystem, ++z);
        }
        private void add_new_question(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(questionType, ++z);
        }

        private void mcq_question(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(mcqquestionpanel, ++z);
        }

        private void text_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(textquestionpanel, ++z);
        }

        private void tf_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(tfquestionpanel, ++z);
        }

        private void newExam(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(exampanel, ++z);
        }

        private void submit_exam(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateofExam = ExamDate.DisplayDate;
                int munites = 0;
                string[] number = ExamTime.Text.Split(':', ',');
                if (number.Length == 1)
                    munites = 0;
                else if (number.Length > 1)
                    munites = int.Parse(number[1]);
                else
                    MessageBox.Show("please enter the time of exam");
                var hour = int.Parse(number[0]) + int.Parse(duration.Text.ToString());
                DateTime examDateTimeBegin = new DateTime(dateofExam.Year, dateofExam.Month, dateofExam.Day, int.Parse(number[0]), munites, 0);
                //TimeSpan examDateTimeBegin = new TimeSpan(examDateTime.Day, int.Parse(number[0]), munites, 0);
                DateTime examDateTimeEnd = new DateTime(examDateTimeBegin.Year, examDateTimeBegin.Month, examDateTimeBegin.Day, hour, munites, 0);

                if (int.Parse(sumOfQuestionGrades.Text) == ExamDegree && examDateTimeBegin != null
                    && SelectedQuestionsss.Count > 0 && int.Parse(duration.Text.ToString()) > 0)
                {
                    //the questions that selected to the exam 
                    List<Quesition> questions = new List<Quesition>();
                    questions.AddRange(QuestionWithGrades.Where(r => SelectedQuestionsss.Contains(r.IDeas)));

                    //this list to match from question in class i made to put to the class
                    //the entity framework has made (the elements is added in the foreach t7t)
                    List<exam_qusetion> Exams_questions = new List<exam_qusetion>();

                    //the course of the question
                    //List<course_question> course_qus = new List<course_question>();
                    //course_qus.Add(new course_question { Course_ID = 1, Qust_codr = 4 });

                    //getting the course ID of the selected course
                    var courseId =
                    (from courseID in context2.courses
                     where courseID.Name == CourseNName
                     select courseID.CourseId).FirstOrDefault();

                    List<question> DBquestions = new List<question>();
                    foreach (var item in questions)
                    {
                        question qus = new question
                        {
                            QustCode = item.IDeas,
                            type = item.Type
                        };
                        DBquestions.Add(qus);
                        Exams_questions.Add(new exam_qusetion
                        {
                            Question_Id = item.IDeas,
                            Grade = item.Degree
                        });
                    }

                    List<course_exam> courseOfExam = new List<course_exam>();
                    var exams = new exam()
                    {
                        Name = CourseNName,
                        Type = comboBoxofexamType.SelectedItem.ToString(), //must be exam of corrective
                        Date = examDateTimeBegin,
                        EndTime = examDateTimeEnd,
                        MaxDegree = (short)ExamDegree,
                        course_exam = courseOfExam,
                        exam_qusetion = Exams_questions,
                    };
                    context2.exams.Add(exams);

                    context2.course_exam.Add(new course_exam { Course_Id = courseId});
                    context2.SaveChanges();
                    MessageBox.Show("Exam Has been Added");
                    /* ExamDegree // this is the degree of the exam
                     IstuctorCourse // this is the course of the exam
                     comboBoxofexamType // this combo box is the 
                     Exams_questions // this is the list of quetions
                     examDateTimeBegin // this is the begin time for exam
                     examDateTimeEnd //this is the end time for the exam */
                }
                else
                {
                    totalQgrade.Visibility = Visibility.Visible;
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Please Enter a valid Information");
            }
        }

        private void submit_degrees(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(AnsweredQuestions, ++z);
        }

        private void eDegree_LostFocus(object sender, RoutedEventArgs e)

        {
            if (eDegree.Text.ToString() != "" || eDegree.Text.ToString() != null)
            {
                coursequestions.IsEnabled = true;
                try
                {
                    ExamDegree = int.Parse(eDegree.Text.ToString());
                    if (ExamDegree > 0)
                        BindedExamGrade.Text = int.Parse(eDegree.Text.ToString()).ToString();
                }
                catch (Exception execeptionn)
                {
                    MessageBox.Show(execeptionn.Message);
                    coursequestions.IsEnabled = false;
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)

        {
            CheckBox ch = sender as CheckBox;
            int qid = int.Parse(ch.Content.ToString());
            if (SelectedQuestionsss.Contains(qid))
            {
                SelectedQuestionsss.Remove(qid);
            }
            else
            {
                SelectedQuestionsss.Add(qid);
            }
            sumOfQuestionGrades.Text = QuestionWithGrades.Where(r => SelectedQuestionsss.Contains(r.IDeas)).Sum(r => r.Degree).ToString();

        }

        private void questionGrade_LostFocus(object sender, RoutedEventArgs e)

        {
            TextBox questionGrade = sender as TextBox;
            if (questionGrade.Text != "" || questionGrade.Text != null)
            {
                try
                {
                    bool valid = int.Parse(questionGrade.Text) > 0;
                    if (valid)
                    {
                        var q = questionGrade.DataContext as Quesition;
                        if (QuestionWithGrades.Contains(q))
                            QuestionWithGrades.RemoveAt(QuestionWithGrades.LastIndexOf(q));
                        q.Degree = int.Parse(questionGrade.Text.ToString());
                        QuestionWithGrades.Add(q);
                        sumOfQuestionGrades.Text = QuestionWithGrades.Where(r => SelectedQuestionsss.Contains(r.IDeas)).Sum(r => r.Degree).ToString();
                    }
                }
                catch (Exception exeception)
                {
                    MessageBox.Show("Go to hell");
                }
            }
        }

        private void IstuctorCourse_SelectionChanged_1(object sender, SelectionChangedEventArgs e)

        {
            var CourseName = sender as ComboBox;
            CourseNName = CourseName.SelectedItem.ToString();
            //MessageBox.Show(CourseName.SelectedItem.ToString());

            var query =
            (from Idcourse in context2.courses
             where Idcourse.Name == CourseNName
             select Idcourse.CourseId).FirstOrDefault();

            var query2 =
                (from coursee in context2.course_question
                 where query == coursee.Course_ID
                 select coursee.Qust_codr).ToList();

            var query3 =
                         (from questions in context2.questions
                          where query2.Contains(questions.QustCode)
                          select questions).ToList();

            List<Quesition> ListOfClassQuesitions = new List<Quesition>();

            foreach (var item in query3)
            {
                //Question.Degree = item.Degree;
                //Question.type = item.type;

                if (item.type == "text")
                {
                    var query4
                        = (from questions in context2.questions
                           join textQuestion in context2.textquestions
                           on questions.QustCode equals textQuestion.QustCode
                           where questions.QustCode == item.QustCode
                           select textQuestion.question).FirstOrDefault();

                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4;
                    ListOfClassQuesitions.Add(ClassQuestion);
                }
                else if (item.type == "MSQ")
                {
                    var query4
                        = (from questions in context2.questions
                           join mcq in context2.multichoices
                           on questions.QustCode equals mcq.QustCode
                           select mcq.question).FirstOrDefault();

                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4;
                    ListOfClassQuesitions.Add(ClassQuestion);


                }
                else if (item.type == "true&false")
                {
                    var query4
                        = (from questions in context2.questions
                           join tf in context2.qtruefalses
                           on questions.QustCode equals tf.QustCode
                           select tf.question).FirstOrDefault();


                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4.ToString();
                    ListOfClassQuesitions.Add(ClassQuestion);
                }


            }

            coursequestions.ItemsSource = ListOfClassQuesitions;
        }



        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox ch = sender as CheckBox;
            int qid = int.Parse(ch.Content.ToString());
            if (SelectedQuestionsss.Contains(qid))
            {
                SelectedQuestionsss.RemoveAt(qid);
                sumOfQuestionGrades.Text = QuestionWithGrades.Where(r => SelectedQuestionsss.Contains(r.IDeas)).Sum(r => r.Degree).ToString();
            }
            else
            {
                SelectedQuestionsss.Add(qid);
                sumOfQuestionGrades.Text = QuestionWithGrades.Sum(r => r.Degree).ToString();
            }
        }





        private void questionCourse_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            questionss.Items.Clear();
            var CourseName = sender as ComboBox;
            var CourseNName = CourseName.SelectedItem.ToString();
            //MessageBox.Show(CourseName.SelectedItem.ToString());

            var query =
            (from Idcourse in context2.courses
             where Idcourse.Name == CourseNName
             select Idcourse.CourseId).FirstOrDefault();

            var query2 =
                (from coursee in context2.course_question
                 where query == coursee.Course_ID
                 select coursee.Qust_codr).ToList();

            var query3 =
                         (from questions in context2.questions
                          where query2.Contains(questions.QustCode)
                          select questions).ToList();

            List<Quesition> ListOfClassQuesitions = new List<Quesition>();

            foreach (var item in query3)
            {
                //Question.Degree = item.Degree;
                //Question.type = item.type;

                if (item.type == "text")
                {
                    var query4
                        = (from questions in context2.questions
                           join textQuestion in context2.textquestions
                           on questions.QustCode equals textQuestion.QustCode
                           where questions.QustCode == item.QustCode
                           select textQuestion.question).FirstOrDefault();

                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4;
                    ListOfClassQuesitions.Add(ClassQuestion);
                }
                else if (item.type == "MSQ")
                {
                    var query4
                        = (from questions in context2.questions
                           join mcq in context2.multichoices
                           on questions.QustCode equals mcq.QustCode
                           select mcq.question).FirstOrDefault();

                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4;
                    ListOfClassQuesitions.Add(ClassQuestion);


                }
                else if (item.type == "true&false")
                {
                    var query4
                        = (from questions in context2.questions
                           join tf in context2.qtruefalses
                           on questions.QustCode equals tf.QustCode
                           select tf.question).FirstOrDefault();


                    Quesition ClassQuestion = new Quesition();
                    ClassQuestion.IDeas = int.Parse(item.QustCode.ToString());
                    ClassQuestion.Degree = int.Parse(item.Degree.ToString());
                    ClassQuestion.Type = item.type;
                    ClassQuestion.TextQuesition = query4.ToString();
                    ListOfClassQuesitions.Add(ClassQuestion);
                }


            }

            foreach (var item in ListOfClassQuesitions)
            {


                questionss.Items.Add(item);
                // questionss.Items.Clear();
            }
            //  questionss.ItemsSource = ListOfClassQuesitions;
        }

        private void examsincourse(object sender, SelectionChangedEventArgs e)
        {
            var CourseName = sender as ComboBox;
            var CourseNName = CourseName.SelectedItem.ToString();
            //MessageBox.Show(CourseName.SelectedItem.ToString());

            var query =
            (from Idcourse in context2.courses
             where Idcourse.Name == CourseNName
             select Idcourse.CourseId).FirstOrDefault();

            var query2 =
                (from coursee in context2.course_exam
                 where coursee.Course_Id == query
                 select coursee.Exam_Id).ToList();

            var query3 = (from exam in context2.exams
                          where query2.Contains(exam.ExamCode)
                          select exam).ToList();

            List<StudentExamListView> ListOfClassExams = new List<StudentExamListView>();

            foreach (var item in query3)
            {
                StudentExamListView ex = new StudentExamListView();
                ex.Date = item.Date;
                ex.Grade = 0;
                ex.ExamCode = item.ExamCode;
                ex.MinDegree = item.MinDegree;
                ex.MaxDegree = item.MaxDegree;
                ex.Name = item.Name;
                ex.Type = item.Type;
                ex.Intake = 0;
                ex.Branch = "";
                ex.Course = "";
                ListOfClassExams.Add(ex);
            }
            exams.ItemsSource = ListOfClassExams;
        }

        private void Coure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CourseName = sender as ComboBox;
            //fill the exam list
            var CourseNName = Coure.SelectedItem.ToString();
            List<exam> exams = getAllExamsofCourse(CourseNName);
            List<examListView> examstoBeViewd = new List<examListView>();
            foreach (var item in exams)
            {
                examListView ex = new examListView { ExamCode = item.ExamCode, ExamName = item.Name, Type = item.Type, Date = item.Date };
                examstoBeViewd.Add(ex);
            }
            avaialableExams.ItemsSource = examstoBeViewd;

            //fill the students list
            CourseNName = Coure.SelectedItem.ToString();
            List<student> students = getAllStudentsofCourse(CourseNName);
            List<studentListView> studentstoBeViewd = new List<studentListView>();
            AvaialableStudents.Items.Clear();
            foreach (var item in students)
            {
                ListViewItem d = new ListViewItem();
                
                   studentListView st = new studentListView { ID = item.StuId, Name = item.FirstName + " " + item.LastName, Track = getStudentTrack(item) };
                AvaialableStudents.Items.Add(st);

            }
            //AvaialableStudents.Items[0].SubItems[5].BackColor = System.Drawing.Color.Red;
            //AvaialableStudents.ItemsSource = studentstoBeViewd;
        }

        private void avaialableExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            examListView po = avaialableExams.SelectedItem as examListView;
            List<int> qu = (from y in context2.rel_exam_student
                            where y.ExamCode == po.ExamCode
                            select y.StuId).ToList();
            foreach (var stu in AvaialableStudents.Items)
            {
                var d = stu as studentListView;
                foreach (var exa in qu)
                {
                    if (d.ID == exa)
                    {
                        checkedd f = new checkedd();
                        f.check = true;
                    }
                }
            }
        }
        private void choose_Students(object sender, RoutedEventArgs e)
        {
            CheckBox ch = sender as CheckBox;
            int studentID = int.Parse(ch.Content.ToString());
            if (selecteStudentstoExam.Contains(studentID))
            {
                selecteStudentstoExam.Remove(studentID);
            }
            else
            {
                selecteStudentstoExam.Add(studentID);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                examListView examo = avaialableExams.SelectedItem as examListView;
                int ExamCode = (from exam in context2.exams
                                where exam.Name == examo.ExamName
                                select exam.ExamCode).FirstOrDefault();
                foreach (var item in selecteStudentstoExam)
                {
                    context2.rel_exam_student.Add(new rel_exam_student { StuId = item, ExamCode = ExamCode });
                }
                context2.SaveChanges();
            }
            catch(Exception d)
            {
                MessageBox.Show("already assigned");
            }
        }

        private void txt_save_Click(object sender, RoutedEventArgs e)
        {
            var course_id =
            (from Idcourse in context2.courses
             where Idcourse.Name == CourseNName
             select Idcourse.CourseId).FirstOrDefault();

            List<course_question> course_quest = new List<course_question>();
            course_quest.Add(new course_question { Course_ID = course_id, Qust_codr = 1 });
            try
            {
                if (qText.Text.Length < 3 && qAnswer.Text.Length < 3)
                {
                    MessageBox.Show("please enter correct question");
                }
                else
                {
                    List<textquestion> textQ = new List<textquestion>();
                    textQ.Add(new textquestion { question = qText.Text, ModelAnswer = qAnswer.Text });
                    var quest = new question()
                    {
                        type = "text",
                        textquestions = textQ,
                        Degree = int.Parse(qDegree.Text),
                        course_question = course_quest

                    };
                    context2.questions.Add(quest);
                    context2.SaveChanges();
                    questionss.Items.Add(quest);
                    MessageBox.Show("Done");

                }
            }
            catch (Exception rr)
            {
                MessageBox.Show("invaild stored");

            }
            // var question = qText.Text;


        }

        private void msq_save_Click(object sender, RoutedEventArgs e)
        {
            var course_id =
                       (from Idcourse in context2.courses
                        where Idcourse.Name == CourseNName
                        select Idcourse.CourseId).FirstOrDefault();
            // MessageBox.Show(course_id.ToString());

            var q = new question()
            {
                type = "MCQ",
                Degree = double.Parse(qDegree1.Text),


            };
            q = context2.questions.Add(q);
            context2.SaveChanges();

            var courses = new course_question()
            {
                Qust_codr = q.QustCode,
                Course_ID = course_id
            };
            courses = context2.course_question.Add(courses);
            context2.SaveChanges();

            var ques = new multichoice()
            {
                question1 = q,
                question = qText1.Text,
            };
            ques = context2.multichoices.Add(ques);
            context2.SaveChanges();
            bool A, B, C, D;
            if (checkboxA.IsChecked == true)
                A = true;
            else
                A = false;
            if (checkboxB.IsChecked == true)
                B = true;
            else
                B = false;
            if (checkboxC.IsChecked == true)
                C = true;
            else
                C = false;
            if (checkboxD.IsChecked == true)
                D = true;
            else
                D = false;
            var multi1 = new msqmultivalue()
            {
                MCQCode = ques.MCQCode,
                ModelAnswer = textA.Text,
                correct = A
            };
            var multi2 = new msqmultivalue()
            {
                MCQCode = ques.MCQCode,
                ModelAnswer = textB.Text,
                correct = B
            };
            var multi3 = new msqmultivalue()
            {
                MCQCode = ques.MCQCode,
                ModelAnswer = textC.Text,
                correct = C
            };
            var multi4 = new msqmultivalue()
            {
                MCQCode = ques.MCQCode,
                ModelAnswer = textD.Text,
                correct = D
            };
            context2.msqmultivalues.Add(multi1);
            context2.msqmultivalues.Add(multi2);
            context2.msqmultivalues.Add(multi3);
            context2.msqmultivalues.Add(multi4);
            context2.SaveChanges();
            questionss.Items.Add(ques);
            MessageBox.Show("Done");

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Course_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CourseName = sender as ComboBox;
            var CourseNName = CourseName.SelectedItem.ToString();
            getStuentExamListView();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentExamListView StEx = Studentsexams.SelectedItem as StudentExamListView;
                var studentID = (from u in context2.students
                                 where u.StuEmail == StEx.Name
                                 select u.StuId).FirstOrDefault();
                List<rel_student_qusetion_exam> query =
                    (from sqe in context2.rel_student_qusetion_exam
                     join se in context2.rel_exam_student
                     on sqe.StudentId equals se.StuId
                     where sqe.StudentId == studentID && sqe.ExamCode == StEx.ExamCode && se.Taken == true
                     select sqe).ToList();
                foreach (var item in query)
                {
                    string quetionn = "";
                    var qtype = (from q in context2.questions
                                 where q.QustCode == item.QustCode
                                 select q.type).FirstOrDefault();
                    if (qtype == "text")
                    {
                        quetionn = (from con in context2.textquestions
                                    where con.QustCode == item.QustCode
                                    select con.question).FirstOrDefault();
                    }
                    if (qtype == "MSQ")
                    {
                        quetionn = (from con in context2.multichoices
                                    where con.QustCode == item.QustCode
                                    select con.question).FirstOrDefault();
                    }
                    if (qtype == "true&false")
                    {
                        quetionn = (from con in context2.qtruefalses
                                    where con.QustCode == item.QustCode
                                    select con.question).FirstOrDefault();
                    }
                    QuestionOfSubmittedExam questionToBeViewed = new QuestionOfSubmittedExam();
                    questionToBeViewed.StudentId = item.StudentId;
                    questionToBeViewed.QustCode = item.QustCode;
                    questionToBeViewed.ExamCode = item.ExamCode;
                    questionToBeViewed.Question = quetionn;
                    questionToBeViewed.Type = qtype;
                    questionToBeViewed.Answer = item.Answer;
                    questionToBeViewed.ModelAnswer = item.ModelAnswer;
                    questionToBeViewed.DegreeMark = item.DegreeMark;
                    submitedQuestions.Items.Add(questionToBeViewed);
                }
                Canvas.SetZIndex(AnsweredQuestions, ++z);
            }
            catch (Exception fs)
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(StudentsSubmitedExam, ++z);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (var item in submitedQuestions.Items)
            {
                var d = item as QuestionOfSubmittedExam;
                rel_student_qusetion_exam query = (from g in context2.rel_student_qusetion_exam
                                                   where g.StudentId == d.StudentId && g.ExamCode == d.ExamCode && g.QustCode == d.QustCode
                                                   select g).FirstOrDefault();
                query.DegreeMark = d.DegreeMark;
                context2.SaveChanges();
                MessageBox.Show("Done");
            }
        }

        private void InstuctorCourse1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CourseName = sender as ComboBox;
            CourseNName = CourseName.SelectedItem.ToString();
        }

        private void truefalse_save(object sender, RoutedEventArgs e)
        {
            string answer;

            if (radioA.IsChecked == true)

            {
                answer = "true";

            }
            else
                answer = "false";
            var CourseName = sender as ComboBox;
            CourseNName = InstuctorCourse2.SelectedItem.ToString();

            var course_id =
            (from Idcourse in context2.courses
             where Idcourse.Name == CourseNName
             select Idcourse.CourseId).FirstOrDefault();

            List<course_question> course_quest = new List<course_question>();

            course_quest.Add(new course_question { Course_ID = course_id });
            var q = new question()
            {
                type = "treue&false",
                Degree = int.Parse(qDegree2.Text),
                course_question = course_quest

            };
            q = context2.questions.Add(q);
            context2.SaveChanges();


            var tfq = new qtruefalse()
            {
                QustCode = q.QustCode,
                question = qText2.Text,
                ModelAnswer = answer


            };
            context2.qtruefalses.Add(tfq);
            context2.SaveChanges();
            questionss.Items.Add(tfq);
            MessageBox.Show("Done");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
        Quesition qselected = new Quesition();
        private void questionss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qselected = questionss.SelectedItem as Quesition;
        }

        private void remove_Click_4(object sender, RoutedEventArgs e)
        {
            int id = qselected.IDeas;
            string type = qselected.Type;


            if (questionss.SelectedItem != null)
            {
                Quesition tt = (Quesition)questionss.SelectedItem;

                var quet =
           (from quesst in context2.questions
            where quesst.QustCode == tt.IDeas
            select quesst).FirstOrDefault();
                questionss.Items.Remove(questionss.SelectedItem);
                context2.questions.Remove(quet);
                context2.SaveChanges();

            }
            else
            {
                MessageBox.Show("false");

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentExamListView exa = exams.SelectedItem as StudentExamListView;
                exam quet = (from t in context2.exams
                            where t.ExamCode == exa.ExamCode
                            select t).FirstOrDefault();
                
                context2.exams.Remove(quet);
                context2.SaveChanges();
                exams.Items.Remove(exa);
                Canvas.SetZIndex(exampanel, ++z);
            }
            catch (Exception dds)
            {

            }
        }

    }
}
