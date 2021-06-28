using POCO;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Console_Application
{
    class ProgramUI
    {
        protected readonly DeveloperRepo _developerProgramRepo = new DeveloperRepo();
        protected readonly DevTeamRepo _devTeamProgramRepo = new DevTeamRepo();

        public void Run()
        {
            StartDeveloperList();
            KomodoDisplayMenu();
        }

        public void KomodoDisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select:\n" +
                    "1. Display all Developers\n" +
                    "2. Display all Developer Teams\n" +
                    "3. Add New Developer\n" +
                    "4. Add New Developer Team\n" +
                    "5. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayAllDevelopers();
                        break;
                    case "2":
                        DisplayAllDevTeams();
                        KomodoDisplayMenuDevTeam();
                        break;
                    case "3":
                        AddNewDeveloper();
                        break;
                    case "4":
                        AddNewDevTeam();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5");
                        PressAnyKey();
                        break;
                }
            }
        }

        private void KomodoDisplayMenuDevTeam()
        {
            Console.WriteLine(
                "Modify Team Members:\n" +
                "1. Display all Teams and Members\n" +
                "2. Add Member to Team\n" +
                "3. Remove Member from Team\n" +
                "4. Return to Main Menu\n");
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 4");
                    PressAnyKey();
                    break;
            }
        }

        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please Complete the Follinging Three Fields to Add a new Developer.");

            Console.Write("Developer Full Name:");
            string fullName = Console.ReadLine();

            Console.Write("Developer Six Digit ID Number:");
            int idNumber = int.Parse(Console.ReadLine());

            Console.Write("Developer Has Access to Pluralsight True/False:");
            bool pluralSight = bool.Parse(Console.ReadLine());

            Developer developer = new Developer(fullName, idNumber, pluralSight);

            _developerProgramRepo.AddDeveloperToDirectory(developer);
        }

        private void AddNewDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Complete the Follinging Two Fields to Add a new Developer Team.");

            Console.Write("Developer Team Name:");
            string teamName = Console.ReadLine();

            Console.Write("Developer Team Four Digit ID Number:");
            int teamId = int.Parse(Console.ReadLine());

            DevTeam devTeam = new DevTeam(teamName, teamId);

            _devTeamProgramRepo.AddDevTeamToDirectory(devTeam);
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerProgramRepo.GetDevelopers();

            foreach (Developer content in listOfDevelopers)
            {
                DisplayDevelopers(content);
            }

            PressAnyKey();
        }

        private void DisplayAllDevTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeamProgramRepo.GetDevTeams();

            foreach (DevTeam content in listOfDevTeams)
            {
                DisplayDevTeams(content);
            }

            Console.WriteLine("Press any key to view options.");
            Console.ReadLine();
        }

        private void DisplayDevelopers(Developer content)
        {
            Console.WriteLine($"Full Name: {content.FullName}\n" +
                $"Id Number: {content.IdNumber}\n" +
                $"Pluralsight: {content.PluralSight}\n");
        }

        private void DisplayDevTeams(DevTeam content)
        {
            Console.WriteLine($"Team Name: {content.TeamName}\n" +
                $"Id Number: {content.TeamId}\n");
        }

        private void DispllayAllDevTeamMembers()
        {

        }
        private void DisplayDevTeamMembers()
        {

        }

        private void StartDeveloperList()
        {
            Developer john = new Developer("John Smith", 605941, true);
            Developer robert = new Developer("Robert Johnson", 605248, false);
            Developer james = new Developer("James Williams", 605618, true);
            Developer michael = new Developer("Michael Brown", 605483, false);
            Developer david = new Developer("David Jones", 605702, true);
            Developer mary = new Developer("Mary Davis", 605357, false);
            Developer sarah = new Developer("Sarah Garcia", 605276, true);
            Developer jessica = new Developer("Jessica Miller", 605140, false);
            Developer ashley = new Developer("Ashley Wilson", 605529, true);
            Developer emily = new Developer("Emily Moore", 605842, false);

            _developerProgramRepo.AddDeveloperToDirectory(john);
            _developerProgramRepo.AddDeveloperToDirectory(robert);
            _developerProgramRepo.AddDeveloperToDirectory(james);
            _developerProgramRepo.AddDeveloperToDirectory(michael);
            _developerProgramRepo.AddDeveloperToDirectory(david);
            _developerProgramRepo.AddDeveloperToDirectory(mary);
            _developerProgramRepo.AddDeveloperToDirectory(sarah);
            _developerProgramRepo.AddDeveloperToDirectory(jessica);
            _developerProgramRepo.AddDeveloperToDirectory(ashley);
            _developerProgramRepo.AddDeveloperToDirectory(emily);


            DevTeam mind = new DevTeam("Mind Benders", 5672);
            DevTeam cap = new DevTeam("Capitalist Crew", 5641);
            DevTeam inno = new DevTeam("Innovation Geeks", 5689);


            _devTeamProgramRepo.AddDevTeamToDirectory(mind);
            _devTeamProgramRepo.AddDevTeamToDirectory(cap);
            _devTeamProgramRepo.AddDevTeamToDirectory(inno);

            mind.AddDeveloperToTeam(john);
            mind.AddDeveloperToTeam(mary);
            cap.AddDeveloperToTeam(robert);
            cap.AddDeveloperToTeam(sarah);
            inno.AddDeveloperToTeam(james);
            inno.AddDeveloperToTeam(sarah);
        }
    }
}
