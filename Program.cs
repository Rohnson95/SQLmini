﻿namespace tempSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu();
            menu.StartMenu();
        }

        /*internal static void Menu()
        {
            bool isActive = true;
            Console.WriteLine("1. Hour Report\n2. Users\n3. Projects\n4. New Person\n5. New Project\n6.Update Existing User\n7.Update Existing Project\n8.Exit");

            while (isActive)
            {
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ClockHours();
                        break;

                    case "2":
                        Users();
                        break;
                    case "3":
                        Projects();
                        break;
                    case "4":
                        NewPerson();
                        break;
                    case "5":

                        break;
                    case "6":
                        UpdatePerson();
                        break;
                    case "7":
                        UpdateProject();
                        break;
                    case "8":
                        Environment.Exit(0);
                        isActive = false;
                        break;


                }
            }

        }*/

        internal static void ClockHours()
        {
            List<PersonModel> persons = DataAccess.Persons();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.Write("What is your name: ");
            string? name = Console.ReadLine();
            for (int i = 0; i < persons.Count; i++)
            {

                if (persons[i].person_name.Equals(name))
                {
                    int x = persons[i].id;
                    Console.ReadLine();
                    i = persons.Count;
                    Console.Write("Project: ");
                    string? project = Console.ReadLine();
                    for (int j = 0; j < projects.Count; j++)
                    {

                        int y = projects[j].id;
                        if (projects[j].project_name.Equals(project))
                        {
                            Console.ReadLine();
                            j = projects.Count;
                            Console.WriteLine("How many Hours:");
                            int hours = int.Parse(Console.ReadLine());
                            DataAccess.ProjectPerson(y, x, hours);
                        }
                    }
                }
                else if (i == persons.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }
            Console.WriteLine($"Done");
            Console.ReadLine();
            menu.StartMenu();
        }
        internal static void Users()
        {
            Console.Clear();
            List<PersonModel> persons = DataAccess.Persons();
            Console.WriteLine("USERS");
            foreach (PersonModel person in persons)
            {
                Console.WriteLine(person.person_name);
            }
            Console.ReadLine();
            menu.StartMenu();
        }
        internal static void Projects()
        {
            Console.Clear();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.WriteLine("PROJECTS");
            foreach (ProjectModel project in projects)
            {
                Console.WriteLine(project.project_name);
            }
            Console.ReadLine();
            menu.StartMenu();
        }
        internal static void NewPerson()
        {
            Console.Clear();
            Console.Write("Name: ");
            string? input = Console.ReadLine();
            DataAccess.NewPerson(input);
            Console.WriteLine("Name has been added!");
            Console.ReadLine();
            menu.StartMenu();
        }
        internal static void UpdatePerson()
        {
            Console.Clear();
            List<PersonModel> persons = DataAccess.Persons();
            Console.WriteLine("What Name Would You Like To Change:");
            string? old_name = Console.ReadLine();
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].person_name.Equals(old_name))
                {
                    int x = persons[i].id;
                    Console.WriteLine($"Name you want to change: {old_name} ID:{x}");
                    Console.Write($"New Name:");
                    string? new_name = Console.ReadLine();
                    Console.WriteLine($"old:{old_name} new:{new_name}");
                    DataAccess.UpdatePerson(x, new_name);
                    i = persons.Count;
                    Console.WriteLine("Done");
                    Console.ReadLine();
                    menu.StartMenu();
                }
                else if (i == persons.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }

        }
        internal static void UpdateProject()
        {
            Console.Clear();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.WriteLine("What Project Would You Like To Change:");
            string? old_project_name = Console.ReadLine();
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].project_name.Equals(old_project_name))
                {
                    int x = projects[i].id;
                    Console.Write($"Project name you want to change: {old_project_name} ID:{x}");
                    Console.Write($"New Project Name:");
                    string? new_project_name = Console.ReadLine();
                    Console.WriteLine($"old:{old_project_name} new:{new_project_name}");
                    DataAccess.UpdateProject(x, new_project_name);
                    i = projects.Count;
                    Console.WriteLine("Done");
                    Console.ReadLine();
                    menu.StartMenu();
                }
                else if (i == projects.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }

        }
        internal static void NewProject()
        {
            Console.Clear();
            Console.Write("New Projectname: ");
            string? input = Console.ReadLine();
            DataAccess.NewProject(input);
            Console.WriteLine("Project has been added!");
            Console.ReadLine();
            menu.StartMenu();
        }
        internal static void ModifyTime()
        {

            List<PersonModel> users = DataAccess.Persons();
            List<ProjectModel> projects = DataAccess.Projects();

            string[] strings = users.Select(user =>
            {
                return user.person_name;
            }).ToArray();

            int index = Helper.MenuIndexer(strings, true);
            int who = users[index].id;
            List<ProjectPersonModel> userproject = DataAccess.ProjectPeople(who);
            string[] userpArr = userproject.Select(userp =>
            {
                return userp.project_name + " " + userp.hours + " hours";

            }).ToArray();


            if (index == strings.Length) { menu.StartMenu(); }
            else
            {
                //string proj = userproject[index].id;
                //int projectIndex = Helper.MenuIndexer(projectArr, false);
                string wohin = ($"{strings[index]}");

                //Console.WriteLine(who);

                //Console.WriteLine($"Person: {strings[index]} \nProject: {projArray[projectIndex]}");
            }
            int projectIndex = Helper.MenuIndexer(userpArr, true);
            if (projectIndex == userpArr.Length)
            {
                menu.StartMenu();
            }
            Console.Write("Adjust Hours clocked to: ");
            int input = int.Parse(Console.ReadLine());
            int type = userproject[projectIndex].id;
            DataAccess.UpdateHours(type, input);
            Console.WriteLine($"Done,hours have been adjusted");
            menu.StartMenu();

        }
    }
}
