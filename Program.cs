namespace HospitalQueueSimulator_
{
    internal class Program
    {
        const int timeSpentWithPatient = 15;
        //CONSTANTS:



        //const int MAXIMUM_MINUTES_PER_DAY = ;


        //Global variables:
        static string patientName;
        static int simulationTime, arrivalTime, treatmentTime;
        static int menuNr;
        static bool isPatientFinished = false;
        
        static int waitingTime = 0;
        static int numberOfPatientsInTheQueue = 3;

        static void StartingScreen()
        {
            Console.Clear();
            Console.WriteLine("************************************");
            Console.WriteLine("      HOSPITAL QUEUE SIMULATOR      ");
            Console.WriteLine("************************************");
            Console.WriteLine();
            
        }
        static string GetPatientName()
        {
            Console.Write("Please enter your Name: ");
            return Console.ReadLine();

        }
        static int GetPatientAge()
        {
            return GetPatientAge();/////////;
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("************************************");
            Console.WriteLine("     Hospital Queue Simulator       ");
            Console.WriteLine("             MAIN MENU              ");
            Console.WriteLine();
            Console.WriteLine("1. Children's Doctor                ");
            Console.WriteLine("2. Adult's Doctor                   ");
            Console.WriteLine("3. Exit Hospital                    ");
            Console.WriteLine("************************************");
            Console.WriteLine();
            //Console.WriteLine("Please enter Menu Number 1, 2 or 3 to access...");
            //menuNr = Convert.ToInt16(Console.ReadLine());
        }
        static int ShowMenuNr(int maxOption)
        {
            

            do
            {
                Console.WriteLine("Please enter Menu Number 1, 2 or 3 to access...");
                menuNr = int.Parse(Console.ReadLine());
            }
            while (menuNr < 1 || menuNr > maxOption);

            return menuNr;
        }
        static void ProcessMenuNr(int menuNr)
        {
            if (menuNr == 1)
            {
                Console.Clear();
                Console.WriteLine("You chose to see children's doctor");
            }
            else if (menuNr == 2)
            {
                Console.Clear();
                Console.WriteLine("You chose to see adult's doctor   ");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You chose to exit the Hospital    ");
                isPatientFinished = true;   

                

            }
        }
        static bool isSimulationRunning()
        {
            return !isPatientFinished;
        }

        static void SimulationTime()
        {
            waitingTime = timeSpentWithPatient * numberOfPatientsInTheQueue;
            

        }


        static void DisplaySimulationTime()
        {
            //Console.Clear();
            Console.WriteLine(">>>>>>>>>>>>>><<<<<<<<<<<<<");
            Console.WriteLine("Display Simulation Time    ");
            Console.WriteLine();
            Console.WriteLine("The doctor arrives at 06:45");
            Console.WriteLine("Current Time: ");
            //Console.WriteLine("Doctor Status: {0}",isDoctorAvailable);
            Console.WriteLine("Patients Wating: {0}",numberOfPatientsInTheQueue);
            Console.WriteLine("Estimated Waiting Time: {0}",timeSpentWithPatient * numberOfPatientsInTheQueue);
            Console.WriteLine(">>>>>>>>>>>>>><<<<<<<<<<<<<");
            Console.WriteLine();
            Console.WriteLine("press any key to see the Menu...");
            Console.ReadKey();
        }
        static void Main()
        {
            StartingScreen();

            patientName = GetPatientName();

            Console.WriteLine("Welcome," + patientName + "!");
            Console.WriteLine();

            DisplaySimulationTime();
            Menu();

           while (isSimulationRunning())
            {
                

                int menuNr = ShowMenuNr(3);

               ProcessMenuNr(menuNr);

                SimulationTime();

               

                Console.WriteLine();

           
            }
                ExitOfProgram();
            }
           static void ExitOfProgram()

            {
                Console.WriteLine("Thank you {0} for coming,get well soon!", patientName);
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
        }
    }
}
