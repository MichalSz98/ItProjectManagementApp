using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;

namespace ItProjectManagementApp
{
    public class ProjectSeeder
    {
        private readonly ApplicationContext _dbContext;

        public ProjectSeeder(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Teams.Any())
                {
                    var teams = GetTeams();

                    _dbContext.Teams.AddRange(teams);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Projects.Any())
                {
                    var projects = GetProjects();

                    _dbContext.Projects.AddRange(projects);
                    _dbContext.SaveChanges();

                    var taskToUpdate = SetTaskSubtasks(_dbContext.Tasks);
                    _dbContext.Tasks.Update(taskToUpdate);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.TaskDependencies.Any())
                {
                    var taskToUpdate = SetTaskDependencies(_dbContext.Tasks);
                    _dbContext.Tasks.Update(taskToUpdate);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Team> GetTeams()
        {
            return new List<Team>()
            {
                new Team()
                {
                    Name = "Team dźwiekowy",
                    Users = new List<User>()
                    {
                        new User()
                        {
                            Name = "Jan",
                            Surname = "Nowak",
                            Role = UserRole.Programmer,
                            Email = "janNowak@gmail.com",
                            Phone = "665 665 665"
                        },
                        new User()
                        {
                            Name = "Antoni",
                            Surname = "Błaszczyk",
                            Role = UserRole.Analyst,
                            Email = "antonib@gmail.com",
                            Phone = "665 665 665"
                        }
                    }
                },
                new Team()
                {
                    Name = "Team obrazu",
                    Users = new List<User>()
                    {
                        new User()
                        {
                            Name = "Jan",
                            Surname = "Kaszub",
                            Role = UserRole.ScrumMaster,
                            Email = "m.szmeja98@gmail.com",
                            Phone = "665 665 665"
                        }
                    }
                }
            };
        }

        private IEnumerable<Project> GetProjects()
        {
            var projects = new List<Project>()
            {
                new Project(
                    "Projekt aplikacja webowa do karaoke",
                    "Aplikacja webowa do karaoke",
                    null,
                    null
                    )
                {
                    TeamId = 1,
                    Tasks = new List<Task>()
                    {
                        new Task("Postawienie szkieletu",
                            "Celem zadania jest postawienie szkieletu",
                            TaskPriority.Medium,
                            TaskStatus.Completed,
                            TaskType.TechnicalIssue,
                            new DateTime(2024, 2, 1),
                            new DateTime(2025, 3, 2)),
                        new Task("Moduł przetwarzania dźwieku",
                            "Celem zadania utworzenie modułu przetwarzania dźwięku",
                            TaskPriority.High,
                            TaskStatus.InProgress,
                            TaskType.UserStory,
                            null,
                            null),
                        new Task("Zad 1 modułu przetwarzania dźwieku",
                                 "Zad 1 modułu",
                                 TaskPriority.Medium,
                                 TaskStatus.Completed,
                                 TaskType.TechnicalIssue,
                                 null,
                                 null),
                        new Task("Zad 2 modułu przetwarzania dźwieku",
                                 "Zad 2 modułu",
                                 TaskPriority.Medium,
                                 TaskStatus.Completed,
                                 TaskType.TechnicalIssue,
                                 null,
                                 null)
                    }
                }
            };

            return projects;
        }

        private Task SetTaskSubtasks(DbSet<Task> tasks)
        {
            var userStoryTask = tasks.FirstOrDefault(x => x.Id == 2);
            var subtask1 = tasks.FirstOrDefault(x => x.Id == 3);
            var subtask2 = tasks.FirstOrDefault(x => x.Id == 4);

            userStoryTask.AddSubtask(subtask1);
            userStoryTask.AddSubtask(subtask2);

            return userStoryTask;
        }

        private Task SetTaskDependencies(DbSet<Task> tasks)
        {
            var firstTask = tasks.FirstOrDefault(x => x.Id == 1);
            var secondTask = tasks.FirstOrDefault(x => x.Id == 2);

            secondTask.AddDependency(firstTask);

            return secondTask;
        }
    }
}
