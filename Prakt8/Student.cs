namespace Prakt8
{
    // Структура для хранения информации о студенте
    public struct Student
    {
        // Поля структуры
        public string Surname;
        public bool NeedsDormitory;
        public int Experience;
        public bool Worked;
        public string Education;
        public string Language;

        // Конструктор структуры
        public Student(
            string surname,
            bool needsDormitory,
            int experience,
            bool worked,
            string education,
            string language)
        {
            Surname = surname;
            NeedsDormitory = needsDormitory;
            Experience = experience;
            Worked = worked;
            Education = education;
            Language = language;
        }

        // Формирование строки с информацией о студенте
        public override string ToString()
        {
            string dormitory = NeedsDormitory ? "да" : "нет";
            string worked = Worked ? "да" : "нет";

            return $"{Surname} | Общежитие: {dormitory} | " +
                   $"Стаж: {Experience} | Работал: {worked} | " +
                   $"Окончил: {Education} | Язык: {Language}";
        }
    }
}