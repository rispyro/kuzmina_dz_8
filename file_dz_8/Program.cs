using file_dz_8;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        var users = new List<string>
        {
            "Гомза Арина", "Закиров Айназ", "Квятковский Всеволод", "Меркулова Софья", "Осипов Семён", "Рахматуллина Алия", "Садриев Салават", "Фазылов Раис", "Харламова Анна", "Целоусов Игорь"
        };

        var project = new Project("Разработка нового приложения", DateTime.Today, DateTime.Today.AddMonths(6), "Гомза Арина", "Квятковский Всеволод");

        AddTasks(project, users);

        foreach (var task in project.Tasks)
        {
            Console.WriteLine($"\nЗадача '{task.Description}' \nСтатус: {task.Status}, Исполнитель: {task.Executor}");
        }
    }
    /// <summary>
    /// метод для добавления задач в проект
    /// </summary>
    /// <param name="project"></param>
    /// <param name="users"></param>
    private static void AddTasks(Project project, List<string> users)
    {
        var random = new Random(); 

        var tasks = new List<Task>
        {
            new Task("Разработать прототип интерфейса для нового приложения", DateTime.Today.AddDays(30), "Гомза Арина", "Гомза Арина") { Status = GetRandomStatus(random) },
            new Task("Провести анализ требований к новому приложению", DateTime.Today.AddDays(60), "Закиров Айназ", "Закиров Айназ") { Status = GetRandomStatus(random) },
            new Task("Создать базу данных для хранения информации о пользователях ", DateTime.Today.AddDays(90), "Квятковский Всеволод", "Квятковский Всеволод") { Status = GetRandomStatus(random) },
            new Task("Реализовать функционал регистрации пользователей в приложении", DateTime.Today.AddDays(120), "Меркулова Софья", "Меркулова Софья") { Status = GetRandomStatus(random) },
            new Task("Написать модуль тестирования для проверки функциональности приложения", DateTime.Today.AddDays(150), "Осипов Семён", "Осипов Семён") { Status = GetRandomStatus(random) },
            new Task("Подготовить документацию по использованию нового приложения", DateTime.Today.AddDays(180), "Рахматуллина Алия", "Рахматуллина Алия") { Status = GetRandomStatus(random) },
            new Task("Разработать механизм уведомлений для отправки сообщений", DateTime.Today.AddDays(210), "Садриев Салават", "Садриев Салават") { Status = GetRandomStatus(random) },
            new Task("Интегрировать платежную систему в новое приложение", DateTime.Today.AddDays(240), "Фазылов Раис", "Фазылов Раис") { Status = GetRandomStatus(random) },
            new Task("Настроить аналитику для сбора статистики", DateTime.Today.AddDays(270), "Харламова Анна", "Харламова Анна") { Status = GetRandomStatus(random) },
            new Task("Организовать процесс поддержки пользователей после запуска приложения", DateTime.Today.AddDays(300), "Целоусов Игорь", "Целоусов Игорь") { Status = GetRandomStatus(random) }
        };

        foreach (var task in tasks)
        {
            project.Tasks.Add(task);
        }
    }

    /// <summary>
    /// Метод для генерации случайного статуса задачи
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    private static TaskStatus GetRandomStatus(Random random)
    {
        return (TaskStatus)random.Next(Enum.GetNames(typeof(TaskStatus)).Length); // Выбор случайного статуса из перечисления
    }
}