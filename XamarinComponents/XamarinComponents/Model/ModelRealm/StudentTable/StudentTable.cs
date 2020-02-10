using Realms;

namespace XamarinComponents
{
    /// <summary>
    /// Модель представления таблицы студентов
    /// </summary>
    public class StudentTable : RealmObject
    {
        /// <summary>
        /// StudentID - Id ключ
        /// </summary>
        [PrimaryKey]
        public int StudentID { get; set; }

        /// <summary>
        /// Имя студента
        /// </summary>
        public string StudentName { get; set; }
    }
}

