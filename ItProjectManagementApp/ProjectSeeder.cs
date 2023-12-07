using ItProjectManagementApp.Entities;
using ItProjectManagementApp.Enums;
using Task = ItProjectManagementApp.Entities.Task;
using TaskStatus = ItProjectManagementApp.Enums.TaskStatus;

namespace ItProjectManagementApp
{
    public class ProjectSeeder
    {
        private readonly ProjectDbContext _dbContext;

        public ProjectSeeder(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Projects.Any())
                {
                    var projects = GetProjects();

                    _dbContext.Projects.AddRange(projects);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Project> GetProjects()
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    Id = 0,
                    Name = "Projekt aplikacja webowa do karaoke",
                    Description = "Aplikacja webowa do karaoke",
                    StartDate = null,
                    EndDate = null,
                    Tasks = new List<Task>()
                    {
                        new Task()
                        {
                            Id = 0,
                            Title = "Postawienie szkieletu",
                            Description = "Celem zadania jest postawienie szkieletu",
                            Priority = TaskPriority.Medium,
                            Status = TaskStatus.Completed,
                            Type = TaskType.TechnicalIssue,
                            StartDate = new DateTime(2024, 2, 1),
                            EndDate = new DateTime(2025, 3, 2),
                        },
                        new Task()
                        {
                            Id = 1,
                            Title = "Moduł przetwarzania dźwieku",
                            Description = "Celem zadania utworzenie modułu przetwarzania dźwięku",
                            Priority = TaskPriority.High,
                            Status = TaskStatus.InProgress,
                            Type = TaskType.UserStory,
                            StartDate = null,
                            EndDate = null,
                            SubTasks = new List<Task>()
                            {
                                new Task()
                                {
                                    Id = 2,
                                    Title = "Zad 1 modułu przetwarzania dźwieku",
                                    Description = "Zad 1 modułu",
                                    Priority = TaskPriority.Medium,
                                    Status = TaskStatus.Completed,
                                    Type = TaskType.TechnicalIssue,
                                    StartDate = null,
                                    EndDate = null
                                },
                                new Task()
                                {
                                    Id = 3,
                                    Title = "Zad 2 modułu przetwarzania dźwieku",
                                    Description = "Zad 2 modułu przetwarzania dźwieku",
                                    Priority = TaskPriority.Medium,
                                    Status = TaskStatus.Completed,
                                    Type = TaskType.TechnicalIssue,
                                    StartDate = null,
                                    EndDate = null
                                },
                            }
                        },
                    }
                }
            };

            return projects;
        }
    }
}
