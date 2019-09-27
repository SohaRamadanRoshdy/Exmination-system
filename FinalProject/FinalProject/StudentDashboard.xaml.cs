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
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        int z = 1;
        int userID;
        int selectedExamId;
        ExaminationEntities1 contect3 = new ExaminationEntities1();
        List<question> getQuestionsOfExam;
        string CurrentQuestion;
        int QCounter;
        int i = 0;
        public List<exam> getAllAssignedExams()
        {
            var query = (from exam in contect3.exams
                         join thisStudent in contect3.rel_exam_student
                         on exam.ExamCode equals thisStudent.ExamCode
                         where thisStudent.StuId == userID && thisStudent.Taken == false
                         select exam).ToList();
            return query;
        }
        public List<exam> getAllSubmittedExams()
        {
            var query = (from exam in contect3.exams
                         join thisStudent in contect3.rel_exam_student
                         on exam.ExamCode equals thisStudent.ExamCode
                         where thisStudent.StuId == userID && thisStudent.Taken == true
                         select exam).ToList();
            return query;
        }
        public void getStuentExamListView()
        {
            List<exam> allAssignedExams = getAllAssignedExams();
            List<exam> allSubmittedExams = getAllSubmittedExams();
            List<StudentExamListView> myAlistview = new List<StudentExamListView>();
            List<StudentExamListView> mySlistview = new List<StudentExamListView>();
            int ITB = (from studenty in contect3.students
                       where studenty.StuId == userID
                       select studenty.ITBid).FirstOrDefault();
            int intakeName = (from intak in contect3.intakes
                              where intak.IntakeNo == (from itb in contect3.rel_branch_track_intake
                                                       where itb.id == ITB
                                                       select itb.intack).FirstOrDefault()
                              select intak.IntakeNumber).FirstOrDefault();
            string BranchName = (from branch in contect3.branches
                                 where branch.BranchId == (from itb in contect3.rel_branch_track_intake
                                                           where itb.id == ITB
                                                           select itb.branchID).FirstOrDefault()
                                 select branch.Name).FirstOrDefault();
            foreach (var exam in allAssignedExams)
            {
                StudentExamListView stuExam = new StudentExamListView();
                string courseName = (from couuse in contect3.courses
                                     where couuse.CourseId == ((from ec in contect3.course_exam
                                                                where ec.Exam_Id == exam.ExamCode
                                                                select ec.Course_Id).FirstOrDefault())
                                     select couuse.Name).FirstOrDefault();
                var gradeQuery = from grrade in contect3.rel_student_qusetion_exam
                                 where grrade.ExamCode == selectedExamId && grrade.QustCode == userID
                                 select grrade.DegreeMark;
                float grade = 0f;
                foreach (var item in gradeQuery)
                {
                    grade += (float)item;
                }
                stuExam.Name = "";
                stuExam.Type = exam.Type;
                stuExam.Course = courseName;
                stuExam.Branch = BranchName;
                stuExam.Intake = intakeName;
                stuExam.Grade = grade;
                stuExam.MinDegree = exam.MinDegree;
                stuExam.MaxDegree = exam.MaxDegree;
                stuExam.Date = exam.Date;
                myAlistview.Add(stuExam);
            }
            foreach (var exam in allSubmittedExams)
            {
                StudentExamListView stuExam = new StudentExamListView();
                string courseName = (from couuse in contect3.courses
                                     where couuse.CourseId == ((from ec in contect3.course_exam
                                                                where ec.Exam_Id == exam.ExamCode
                                                                select ec.Course_Id).FirstOrDefault())
                                     select couuse.Name).FirstOrDefault();
                var gradeQuery = from grrade in contect3.rel_student_qusetion_exam
                                 where grrade.ExamCode == selectedExamId && grrade.QustCode == userID
                                 select grrade.DegreeMark;
                float grade = 0f;
                foreach (var item in gradeQuery)
                {
                    grade += (float)item;
                }
                stuExam.Name = "";
                stuExam.Type = exam.Type;
                stuExam.Course = courseName;
                stuExam.Branch = BranchName;
                stuExam.Intake = intakeName;
                stuExam.Grade = grade;
                stuExam.MinDegree = exam.MinDegree;
                stuExam.MaxDegree = exam.MaxDegree;
                stuExam.Date = exam.Date;
                mySlistview.Add(stuExam);
            }
            try
            {
                exams.Items.Clear();
                finishedexams.Items.Clear();
            }
            catch (Exception rt)
            { }
            exams.ItemsSource = myAlistview;
            finishedexams.ItemsSource = mySlistview;

        }
        public StudentDashboard()
        {
            InitializeComponent();
            userID = 1; //this id must be placed before the function getStuentExamListView it depend on it
            getStuentExamListView();
        }
        public StudentDashboard(string name)
        {
            InitializeComponent();
            userID = (from stuID in contect3.students
                      where stuID.StuEmail == name
                      select stuID.StuId).FirstOrDefault();
            //this id must be placed before the function getStuentExamListView it depend on it
            getStuentExamListView();
        }
        private void stu_exam(object sender, RoutedEventArgs e)
        {
            getStuentExamListView();
            Canvas.SetZIndex(stuExams, ++z);
        }
        private void stu_grades(object sender, RoutedEventArgs e)
        {
            getStuentExamListView();
            Canvas.SetZIndex(stuGrades, ++z);
        }
        private void exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                StudentExamListView selectedExam = exams.SelectedItem as StudentExamListView;
                selectedExamId = (from exam in contect3.exams
                                  where exam.Name == selectedExam.Course
                                  select exam.ExamCode).FirstOrDefault();
            }
            catch (Exception er)
            {

            }
        }
        private void take_exam(object sender, RoutedEventArgs e)
        {
            if (selectedExamId > 0)
            {
                rel_exam_student ess = (from es in contect3.rel_exam_student
                                        where es.ExamCode == selectedExamId && es.StuId == userID
                                        select es).First();
                ess.Taken = true;
                contect3.SaveChanges();
                getQuestionsOfExam = (from Q in contect3.questions
                                      join E in contect3.exam_qusetion
                                      on Q.QustCode equals E.Question_Id
                                      where E.Exam_Id == selectedExamId
                                      select Q).ToList();
                QCounter = getQuestionsOfExam.Count();
                // getting the first question
                question questionIndex = getQuestionsOfExam.ElementAt(i);
                string QuestionContent = "";
                if (questionIndex.type == "text")
                {
                    var Question = (from qs in contect3.textquestions
                                    where qs.QustCode == questionIndex.QustCode
                                    select qs).FirstOrDefault();
                    QuestionContent = Question.question;
                    CurrentQuestion = "text";
                    Canvas.SetZIndex(textAnswer, ++z);
                }
                if (questionIndex.type == "MSQ")
                {
                    QuestionContent = (from qs in contect3.multichoices
                                       where qs.QustCode == questionIndex.QustCode
                                       select qs.question).FirstOrDefault();
                    List<string> choise = (from choisse in contect3.msqmultivalues
                                           where choisse.MCQCode == (from qs in contect3.multichoices
                                                                     where qs.QustCode == questionIndex.QustCode
                                                                     select qs.MCQCode).FirstOrDefault()
                                           select choisse.ModelAnswer).ToList();
                    A.Content = choise.ElementAt(0);
                    B.Content = choise.ElementAt(1);
                    C.Content = choise.ElementAt(2);
                    D.Content = choise.ElementAt(3);
                    CurrentQuestion = "mcq";
                    Canvas.SetZIndex(msqAnswer, ++z);
                }
                if (questionIndex.type == "true&false")
                {
                    QuestionContent = (from qs in contect3.qtruefalses
                                       where qs.QustCode == questionIndex.QustCode
                                       select qs.question).FirstOrDefault();
                    CurrentQuestion = "tf";
                    Canvas.SetZIndex(tfAnswer, ++z);
                }
                question.Content = QuestionContent;
                Canvas.SetZIndex(stuQuestion, ++z);
            }
            else
            {
                MessageBox.Show("Get Out");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int QID = getQuestionsOfExam.ElementAt(i).QustCode;
            if ((i + 2) == QCounter)
            {
                next.Content = "Submit";
            }
            double Degree = (from d in contect3.exam_qusetion
                             where d.Question_Id == QID && d.Exam_Id == selectedExamId
                             select d.Grade).FirstOrDefault();
            //to submit the current answer of question
            if (CurrentQuestion == "text")
            {
                string Answer = studentTextAswer.Text;
                string ModelAnswer = (from m in contect3.textquestions
                                      where m.QustCode == QID
                                      select m.ModelAnswer).FirstOrDefault();
                rel_student_qusetion_exam submitQues = new rel_student_qusetion_exam();
                submitQues.QustCode = getQuestionsOfExam.ElementAt(i).QustCode;
                submitQues.ExamCode = selectedExamId;
                submitQues.StudentId = userID;
                submitQues.Answer = Answer;
                submitQues.ModelAnswer = ModelAnswer;
                if (ModelAnswer == Answer)
                    submitQues.DegreeMark = Degree;
                else
                    submitQues.DegreeMark = 0;
                contect3.rel_student_qusetion_exam.Add(submitQues);
            }
            else if (CurrentQuestion == "mcq")
            {
                bool right = false;
                List<string> Answer = new List<string>();
                List<string> ModelAnswer = (from m in contect3.multichoices
                                            join v in contect3.msqmultivalues
                                            on m.MCQCode equals v.MCQCode
                                            where m.QustCode == QID
                                            select v.ModelAnswer).ToList();
                if (A.IsChecked == true)
                {
                    Answer.Add(A.Content.ToString());
                }
                if (B.IsChecked == true)
                {
                    Answer.Add(B.Content.ToString());
                }
                if (C.IsChecked == true)
                {
                    Answer.Add(C.Content.ToString());
                }
                if (D.IsChecked == true)
                {
                    Answer.Add(D.Content.ToString());
                }
                if (ModelAnswer.Count == Answer.Count)
                {
                    int j = 0;
                    if (ModelAnswer.Contains(Answer.ElementAt(j)))
                    {
                        j++;
                        right = true;
                    }
                    else
                    {
                        right = false;
                    }
                }
                rel_student_qusetion_exam submitQues = new rel_student_qusetion_exam();
                submitQues.QustCode = getQuestionsOfExam.ElementAt(i).QustCode;
                submitQues.ExamCode = selectedExamId;
                submitQues.StudentId = userID;
                foreach (var item in Answer)
                {
                    submitQues.Answer += item + ",";
                }
                foreach (var item in ModelAnswer)
                {
                    submitQues.ModelAnswer += item + ",";
                }
                if (right == true)
                    submitQues.DegreeMark = Degree;
                if (right == false)
                    submitQues.DegreeMark = 0;
                contect3.rel_student_qusetion_exam.Add(submitQues);
            }
            else if (CurrentQuestion == "tf")
            {
                string Answer;
                string ModelAnswer = (from m in contect3.qtruefalses
                                      where m.QustCode == QID
                                      select m.ModelAnswer).FirstOrDefault();
                if (T.IsChecked == true)
                    Answer = "true";
                else
                    Answer = "false";
                rel_student_qusetion_exam submitQues = new rel_student_qusetion_exam();
                submitQues.QustCode = getQuestionsOfExam.ElementAt(i).QustCode;
                submitQues.ExamCode = selectedExamId;
                submitQues.StudentId = userID;
                submitQues.Answer = Answer;
                submitQues.ModelAnswer = ModelAnswer;
                if (ModelAnswer == Answer)
                    submitQues.DegreeMark = Degree;
                else
                    submitQues.DegreeMark = 0;
                contect3.rel_student_qusetion_exam.Add(submitQues);
            }
            contect3.SaveChanges();












            i++;
            if (i + 1 > QCounter)
            {
                CurrentQuestion = "theEnd";
                Canvas.SetZIndex(ExamSubmit, ++z);
                getStuentExamListView();

            }
            else
            {
                try
                {
                    //to get the next question
                    question questionIndex = getQuestionsOfExam.ElementAt(i);
                    string QuestionContent = "";
                    if (questionIndex.type == "text")
                    {
                        var Question = (from qs in contect3.textquestions
                                        where qs.QustCode == questionIndex.QustCode
                                        select qs).FirstOrDefault();
                        QuestionContent = Question.question;
                        CurrentQuestion = "text";
                        Canvas.SetZIndex(textAnswer, ++z);
                    }
                    if (questionIndex.type == "MSQ")
                    {
                        QuestionContent = (from qs in contect3.multichoices
                                           where qs.QustCode == questionIndex.QustCode
                                           select qs.question).FirstOrDefault();
                        List<string> choise = (from choisse in contect3.msqmultivalues
                                               where choisse.MCQCode == (from qs in contect3.multichoices
                                                                         where qs.QustCode == questionIndex.QustCode
                                                                         select qs.MCQCode).FirstOrDefault()
                                               select choisse.ModelAnswer).ToList();
                        A.Content = choise.ElementAt(0);
                        B.Content = choise.ElementAt(1);
                        C.Content = choise.ElementAt(2);
                        D.Content = choise.ElementAt(3);
                        CurrentQuestion = "mcq";
                        Canvas.SetZIndex(msqAnswer, ++z);
                    }
                    if (questionIndex.type == "true&false")
                    {
                        QuestionContent = (from qs in contect3.qtruefalses
                                           where qs.QustCode == questionIndex.QustCode
                                           select qs.question).FirstOrDefault();
                        CurrentQuestion = "tf";
                        Canvas.SetZIndex(tfAnswer, ++z);
                    }
                    question.Content = QuestionContent;
                }
                catch (Exception h)
                {

                }
            }
        }


    }
}
