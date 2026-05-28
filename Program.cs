namespace HospitalQueueSimulator_
{
    internal class Program
    {
        
        const int timeSpentWithPatient = 15;
        const string nameOfDoctor = "MATHEBULA";



        //const int MAXIMUM_MINUTES_PER_DAY = ;


        //Global variables:
        static string patientName;
        static int simulationTime, arrivalTime, treatmentTime, patientAge;
        static int menuNr;
        static bool isPatientFinished = false;
        static string[] patientQueue = new string[10];
        static int patientCount = 0;

        static int waitingTime = 0;

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
            int age;
            Console.Write("Please enter your age: ");


            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input. Enter a valid age: ");
            }
            return age;
                
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
                Console.WriteLine("===================================");
                Console.WriteLine("         Children's Doctor         ");
                Console.WriteLine();
                Console.WriteLine("Please enter your child's name     ");
                string nameOfPatient = Console.ReadLine();
                Console.WriteLine("Dr {0} is available                ", nameOfDoctor);
                Console.WriteLine();
            }
            else if (menuNr == 2)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("         Adult's Doctor            ");
                Console.WriteLine();

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
            waitingTime = timeSpentWithPatient * patientCount;


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
            Console.WriteLine("Patients Wating: {0}", patientCount);
            Console.WriteLine("Estimated Waiting Time: {0}", timeSpentWithPatient * patientCount);
            Console.WriteLine(">>>>>>>>>>>>>><<<<<<<<<<<<<");
            Console.WriteLine();
            Console.WriteLine("press any key to see the Menu...");
            Console.ReadKey();

            DisplayQueue();



        }
        static void AddPatientToQueue(string patientName)
        {
            if (patientCount < patientQueue.Length)
            {
                patientQueue[patientCount] = patientName;
                patientCount++;
                Console.WriteLine(patientName + " added to the queue.");
            }
            else
            {
                Console.WriteLine("The queue is full!");
            }
        }
        static void DisplayQueue()
        {
            Console.WriteLine();
            Console.WriteLine("Current Patient Queue: ");
            for (int i = 0; i < patientCount; i++)
            {
                Console.WriteLine((i + 1) + "." + patientQueue[i]);
            }

            }
        static void Main()
            {
                StartingScreen();

                patientName = GetPatientName();
                patientAge = GetPatientAge();
                
                AddPatientToQueue(patientName);

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

