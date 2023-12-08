using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
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
                    TeamId = 7,
                    //Id = 0,
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
                            null)
                        {
                            //Id = 1,
                            //SubTasks = new List<Task>()
                            //{
                            //    new Task()
                            //    {
                            //        //Id = 2,
                            //        Title = "Zad 1 modułu przetwarzania dźwieku",
                            //        Description = "Zad 1 modułu",
                            //        Priority = TaskPriority.Medium,
                            //        Status = TaskStatus.Completed,
                            //        Type = TaskType.TechnicalIssue,
                            //        StartDate = null,
                            //        EndDate = null
                            //    },
                            //    new Task()
                            //    {
                            //        //Id = 3,
                            //        Title = "Zad 2 modułu przetwarzania dźwieku",
                            //        Description = "Zad 2 modułu przetwarzania dźwieku",
                            //        Priority = TaskPriority.Medium,
                            //        Status = TaskStatus.Completed,
                            //        Type = TaskType.TechnicalIssue,
                            //        StartDate = null,
                            //        EndDate = null
                            //    },
                            //}
                        }
                    }
                }
            };

            return projects;
        }
    }
}
