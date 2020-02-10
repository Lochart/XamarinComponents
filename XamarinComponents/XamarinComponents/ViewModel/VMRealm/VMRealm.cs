using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinComponents
{
    public class VMRealm : Function
    {
        /// <summary>
        /// Модель данных редактируемой таблицы студентов
        /// </summary>
        private StudentTable EditStudent;

        /// <summary>
        /// Комманда добавление студентов
        /// </summary>
        public ICommand CommandAddStudent { get; }

        /// <summary>
        /// Комманда обновление студентов
        /// </summary>
        public ICommand CommandUpdateStudentName { get; }
        
        /// <summary>
        /// Комманда скрытия PopupOptionView
        /// </summary>
        public ICommand CommandPopupCanceled { get; }

        /// <summary>
        /// OptionView - отображения окна выбора
        /// </summary>
        public bool OptionViewIsVisible { get; set; }

        /// <summary>
        /// EditView - отображения окна выбора
        /// </summary>
        public bool EditViewIsVisible { get; set; }

        /// <summary>
        /// Имя студентов
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Редактирование имя студентов
        /// </summary>
        public string EditStudentName { get; set; }

        /// <summary>
        /// Список студентов
        /// </summary>
        public List<StudentTable> StudentSource { get; set; }

        /// <summary>
        /// Список выборов
        /// </summary>
        public List<ModelOptionItems> OptionItems { get; set; }

        public VMRealm()
        {
            OptionItems = new List<ModelOptionItems>();
            CommandAddStudent = new Command(AddStudent);
            CommandPopupCanceled = new Command(PopupCanceled);
            CommandUpdateStudentName = new Command(UpdateStudentName);

            StudentSource = AllListStudentTable();
        }

        /// <summary>
        /// Метод запрос на получение данных студентов
        /// </summary>
        /// <returns> Возврощает список студентов</returns>
        private List<StudentTable> AllListStudentTable() => RealmDB.All<StudentTable>().ToList();

        /// <summary>
        /// Метод поиска студента по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возврощает данные студента</returns>
        private StudentTable FindStudent(int id) => RealmDB.All<StudentTable>().First(b => b.StudentID == id);

        /// <summary>
        /// Метод добавление студентов
        /// </summary>
        private void AddStudent()
        {
            var students = AllListStudentTable();
            var maxStudentId = 0;

            if (students.Count != 0)
                maxStudentId = students.Max(s => s.StudentID);

            var student = new StudentTable
            {
                StudentID = maxStudentId + 1,
                StudentName = StudentName
            };

            RealmDB.Write(() =>
            {
                RealmDB.Add(student);
            });

            StudentName = null;
            StudentSource = AllListStudentTable();
            OnPropertyChanged("");
        }

        /// <summary>
        /// Метод выбора действий
        /// </summary>
        /// <param name="item"></param>
        public void ChoiceOption(ModelOptionItems item)
        {
            switch (item.OptionText)
            {

                case "Edit":
                    OptionViewIsVisible = false;
                    EditViewIsVisible = true;
                    EditStudent = FindStudent(item.StudentId);
                    EditStudentName = EditStudent.StudentName;
                    break;

                case "Delete":
                    var removeStudent = FindStudent(item.StudentId);
                    using (var db = RealmDB.BeginWrite())
                    {
                        RealmDB.Remove(removeStudent);
                        db.Commit();
                    }
                    //await DisplayAlert("Success", "Student Deleted", "OK");
                    OptionViewIsVisible = false;
                    StudentSource = AllListStudentTable();
                    break;
                default:
                    OptionViewIsVisible = false;
                    break;
            }

            OptionItems.Clear();

            OnPropertyChanged("");
        }

        /// <summary>
        /// Метод загрузски данных вариантов
        /// </summary>
        /// <param name="item"></param>
        public void LoadOptionItems(StudentTable item)
        {
            OptionItems.Add(new ModelOptionItems { OptionText = "Edit", StudentId = item.StudentID });
            OptionItems.Add(new ModelOptionItems { OptionText = "Delete", StudentId = item.StudentID });
            OptionItems.Add(new ModelOptionItems { OptionText = "Cancel" });
            
            OptionViewIsVisible = true;
            OnPropertyChanged("");
        }

        /// <summary>
        /// Метод обновление студентов
        /// </summary>
        private void UpdateStudentName()
        {
            var selectedStudent = FindStudent(EditStudent.StudentID);

            using (var db = RealmDB.BeginWrite())
            {
                EditStudent.StudentName = EditStudentName;
                db.Commit();
            }

            //await DisplayAlert("Success", "Student Updated", "OK");

            EditStudentName = null;
            EditViewIsVisible = false;
            OnPropertyChanged("");
        }

        /// <summary>
        /// Скрыть PopupOptionView
        /// </summary>
        private void PopupCanceled()
        {
            EditViewIsVisible = false;
            OnPropertyChanged("");
        }
    }
}