using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace file_dz_8
{
    public class Project
    {
        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Срок начала проекта
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Срок окончания проекта
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Инициатор проекта 
        /// </summary>
        public string Initiator { get; set; }
        /// <summary>
        /// Ответственный за проект (тимлид)
        /// </summary>
        public string ResponsiblePerson { get; set; }
        /// <summary>
        /// Задачи по проекту
        /// </summary>
        public List<Task> Tasks { get; set; }
        /// <summary>
        /// Статус проекта
        /// </summary>
        public ProjectStatus Status { get; set; } 

        public Project(string description, DateTime startDate, DateTime endDate, string initiator, string responsiblePerson)
        {
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Initiator = initiator;
            ResponsiblePerson = responsiblePerson;
            Tasks = new List<Task>();
            Status = ProjectStatus.Project;
        }

        /// <summary>
        /// Методы для изменения статуса проекта
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetExecutionStatus()
        {
            if (Tasks.Count > 0 && Status == ProjectStatus.Project)
            {
                Status = ProjectStatus.Execution;
            }
            else
            {
                throw new InvalidOperationException("Нельзя перевести проект в исполнение, пока нет задач или проект уже в исполнении.");
            }
        }

        public void CloseProject()
        {
            if (Tasks.All(t => t.Status == TaskStatus.Completed))
            {
                Status = ProjectStatus.Closed;
            }
            else
            {
                throw new InvalidOperationException("Проект нельзя закрыть, пока не завершены все задачи.");
            }
        }
    }

    public enum ProjectStatus
    {
        /// <summary>
        /// Проект
        /// </summary>
        Project,
        /// <summary>
        /// Исполнение
        /// </summary>
        Execution,
        /// <summary>
        /// Закрыт
        /// </summary>
        Closed
    }
}
