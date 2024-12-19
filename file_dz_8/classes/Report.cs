using System;
namespace file_dz_8
{
    public class Report
    {
        /// <summary>
        /// Текст отчета
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime CompletionDate { get; set; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        public string Executor { get; set; } 

        public Report(string text, DateTime completionDate, string executor)
        {
            Text = text;
            CompletionDate = completionDate;
            Executor = executor;
        }
    }
}
