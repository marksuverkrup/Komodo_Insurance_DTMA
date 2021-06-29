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
                    "5. HR. Access to Pluralsight\n" +
                    "6. Exit\n");

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
                        AccessToPluralsight();
                        break;
                    case "6":
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
                "3. Remove Member From Team\n" +
                "4. Return to Main Menu\n");
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DispllayAllDevTeamMembers();
                    break;
                case "2":
                    AddMemberToTeam();
                    break;
                case "3":
                    RemoveMemberFromTeam();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 4");
                    PressAnyKey();
                    break;
            }
        }
        private void AddMemberToTeam()
        {
            Console.Clear();
            Console.WriteLine("What Developer would you like to add to a Team?");
            List<Developer> listOfDevelopers = _developerProgramRepo.GetDevelopers();
            int devcount = 0;
            foreach (Developer content in listOfDevelopers)
            {
                devcount++;
                Console.WriteLine($"{devcount}. {content.FullName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetDeveloperIndex = userInput - 1;

            if (targetDeveloperIndex >= 0 && targetDeveloperIndex <= listOfDevelopers.Count())
            {
                Developer targetDeveloper = listOfDevelopers[targetDeveloperIndex];

                Console.WriteLine("What Team Would you like to add this Developer to?");
                List<DevTeam> listOfDevTeams = _devTeamProgramRepo.GetDevTeams();
                int devtcount = 0;
                foreach (DevTeam content in listOfDevTeams)
                {
                    devtcount++;
                    Console.WriteLine($"{devtcount}. {content.TeamName}");
                }

                int userInputTeam = int.Parse(Console.ReadLine());
                int targetTeamIndex = userInputTeam - 1;

                if (targetTeamIndex >= 0 && targetTeamIndex <= listOfDevTeams.Count())
                {
                    DevTeam targetTeam = listOfDevTeams[targetTeamIndex];
                    targetTeam.AddDeveloperToTeam(targetDeveloper);
                    Console.WriteLine($"{targetDeveloper.FullName} has been successfully added to the {targetTeam.TeamName}");
                }
                else
                {
                    Console.WriteLine("There has been an error. Please enter a valid input.");
                    PressAnyKey();
                    AddMemberToTeam();
                }
            }
            else
            {
                Console.WriteLine("There has been an error. Please enter a valid input.");
                PressAnyKey();
                AddMemberToTeam();
            }
            PressAnyKey();
        }
        private void RemoveMemberFromTeam()
        {
            Console.Clear();
            Console.WriteLine("What Team Would you like to Remove a Developer from?");
            List<DevTeam> listOfDevTeams = _devTeamProgramRepo.GetDevTeams();
            int devtecount = 0;
            foreach (DevTeam content in listOfDevTeams)
            {
                devtecount++;
                Console.WriteLine($"{devtecount}. {content.TeamName}");
            }

            int userInputTeam = int.Parse(Console.ReadLine());
            int targetRemoveTeamIndex = userInputTeam - 1;
            DevTeam targetRemoveTeam = listOfDevTeams[targetRemoveTeamIndex];

            Console.WriteLine("What Developer would you like to Remove from this Team?");
            List<Developer> listOfDevTeamMembers = targetRemoveTeam._TeamMembers;
            int devmcount = 0;
            foreach (Developer content in listOfDevTeamMembers)
            {
                devmcount++;
                Console.WriteLine($"{devmcount}. {content.FullName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetRemoveDeveloperIndex = userInput - 1;
            Developer targetRemoveDeveloper = listOfDevTeamMembers[targetRemoveDeveloperIndex];
            targetRemoveTeam.RemoveDeveloperFromTeam(targetRemoveDeveloper);

            Console.WriteLine($"{targetRemoveDeveloper.FullName} has been successfully removed from the {targetRemoveTeam.TeamName}");

            PressAnyKey();
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

            int idNumber = AddNewDeveloperId();
            bool pluralSight = AddNewDeveloperPS();
            
            Developer developer = new Developer(fullName, idNumber, pluralSight);

            _developerProgramRepo.AddDeveloperToDirectory(developer);
        }
        private int AddNewDeveloperId()
        {
            Console.Write("Developer Six Digit ID Number:");
            int idNumber = 605000;
            int idNumberInput = int.Parse(Console.ReadLine());
            if (idNumberInput >= 100000 && idNumberInput <= 999999)
            {
                idNumber = idNumberInput;
            }
            else
            {
                Console.WriteLine("There has been an error. Please enter a valid input.");
                PressAnyKey();
                AddNewDeveloperId();
            }
            return idNumber;
        }
        private bool AddNewDeveloperPS()
        {
            Console.Write("Developer Has Access to Pluralsight True/False:");
            bool pluralSight = false;
            string pluralSightInput = Console.ReadLine();

            if (pluralSightInput == "T" || pluralSightInput == "t" || pluralSightInput == "True" || pluralSightInput == "true")
            {
                pluralSight = true;
            }
            else if (pluralSightInput == "F" || pluralSightInput == "f" || pluralSightInput == "False" || pluralSightInput == "false")
            {
                pluralSight = false;
            }
            else
            {
                Console.WriteLine("There has been an error. Please enter a valid input.");
                PressAnyKey();
                AddNewDeveloperPS();
            }
            return pluralSight;
        }
        private void AddNewDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Complete the Follinging Two Fields to Add a new Developer Team.");

            Console.Write("Developer Team Name:");
            string teamName = Console.ReadLine();
            int teamId = AddNewDevTeamId();

            DevTeam devTeam = new DevTeam(teamName, teamId);

            _devTeamProgramRepo.AddDevTeamToDirectory(devTeam);
        }
        private int AddNewDevTeamId()
        {
            Console.Write("Developer Team Four Digit ID Number:");
            int teamId = 5600;
            int teamIdInput = int.Parse(Console.ReadLine());
            if (teamIdInput >= 1000 && teamIdInput <= 9999)
            {
                teamId = teamIdInput;
            }
            else
            {
                Console.WriteLine("There has been an error. Please enter a valid input.");
                PressAnyKey();
                AddNewDevTeamId();
            }
            return teamId;
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
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamProgramRepo.GetDevTeams();

            foreach (DevTeam content in listOfDevTeams)
            {
                DisplayDevTeamMembers(content);
            }
            PressAnyKey();
        }
        private void DisplayDevTeamMembers(DevTeam content)
        {
            Console.WriteLine($"\n" +
                $"Team Name: {content.TeamName}" +
                $"");
            foreach (Developer content2 in content._TeamMembers)
            {
                Console.WriteLine($"Team Member: {content2.FullName}");
            }
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
        private void AccessToPluralsight()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerProgramRepo.GetDevelopers();
            foreach (Developer content in listOfDevelopers)
            {
                if (content.PluralSight == false)
                {
                    Console.WriteLine($"{content.FullName} does not have access to Pluralsight\n");
                }
            }
            PressAnyKey();
        }
    }
}
