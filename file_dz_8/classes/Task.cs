using System;

namespace file_dz_8
{
    public class Task
    {
        private string v1;
        private DateTime dateTime;
        private TaskStatus assigned;
        private string v2;

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Срок выполнения задачи
        /// </summary>
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Инициатор задачи
        /// </summary>
        public string Initiator { get; set; }
        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public string Executor { get; set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatus Status { get; set; }
        /// <summary>
        /// Отчет по задаче
        /// </summary>
        public Report Report { get; set; }

        public Task(string description, DateTime deadline, string initiator, string executor)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Executor = executor;
            Status = TaskStatus.Assigned;
        }

        /// <summary>
        /// Методы для изменения статуса задачи
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void StartWork()
        {
            if (Status == TaskStatus.Assigned)
            {
                Status = TaskStatus.InProgress;
            }
            else
            {
                throw new InvalidOperationException("Задача не может перейти в работу, если она не назначена.");
            }
        }

        public void DelegateTask(string newExecutor)
        {
            if (Status == TaskStatus.Assigned || Status == TaskStatus.OnCheck)
            {
                Executor = newExecutor;
                Status = TaskStatus.Assigned;
            }
            else
            {
                throw new InvalidOperationException("Задачу невозможно передать другому исполнителю, если она уже выполняется или выполнена.");
            }
        }

        public void CompleteTask(Report report)
        {
            if (Status == TaskStatus.InProgress)
            {
                Report = report;
                Status = TaskStatus.Completed;
            }
            else
            {
                throw new InvalidOperationException("Задача не может быть завершена, если она не в процессе выполнения.");
            }
        }

        public void SendForReview()
        {
            if (Status == TaskStatus.InProgress)
            {
                Status = TaskStatus.OnCheck;
            }
            else
            {
                throw new InvalidOperationException("Задача не может быть отправлена на проверку, если она не в процессе выполнения.");
            }
        }

        public void ApproveTask()
        {
            if (Status == TaskStatus.OnCheck)
            {
                Status = TaskStatus.Completed;
            }
            else
            {
                throw new InvalidOperationException("Задача не может быть утверждена, если она не на проверке.");
            }
        }

        public void ReturnForRevision()
        {
            if (Status == TaskStatus.OnCheck)
            {
                Status = TaskStatus.InProgress;
            }
            else
            {
                throw new InvalidOperationException("Задача не может быть возвращена на доработку, если она не на проверке.");
            }
        }
    }

    public enum TaskStatus
    {
        /// <summary>
        /// Назначена
        /// </summary>
        Assigned,
        /// <summary>
        /// В работе
        /// </summary>
        InProgress,
        /// <summary>
        /// На проверке
        /// </summary>
        OnCheck,
        /// <summary>
        /// Выполнена
        /// </summary>
        Completed
    }
}
