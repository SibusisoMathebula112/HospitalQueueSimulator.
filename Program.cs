namespace HospitalQueueSimulator_
{
    internal class Program
    {
        //CONSTANTS:
        const int timeSpentWithPatient = 15;
        const string nameOfDoctor = "MATHEBULA";
        
        //Global variables:
        
        static int simulationTime, arrivalTime, treatmentTime, patientAge;
        static int menuNr, childAge;
        static string childPatient, adultPatient, patientName;
        static bool isPatientFinished = false;
        static string[] patientQueue = new string[10];
        static int patientCount = 0;
        static int currentMinutes = 15;
        static int currentHour = 07;

        static int waitingTime = 15;

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
            Console.WriteLine();


            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input. Enter a valid age: ");
                Console.WriteLine();
            }
            return age;
                
        }
        static void DisplaySimulationTime()
        {
            Console.Clear();
            Console.WriteLine(">>>>>>>>>>>>>><<<<<<<<<<<<<");
            Console.WriteLine("Display Simulation Time    ");
            Console.WriteLine();
            Console.WriteLine("The doctor arrives at: 07:00 ");
            Console.WriteLine("Current Time: {0}h{1}am ", currentHour, currentMinutes);
            Console.WriteLine("Patients Waiting: {0}", patientCount);
            Console.WriteLine("Estimated Waiting Time: {0} minutes", timeSpentWithPatient * patientCount);
            Console.WriteLine(">>>>>>>>>>>>>><<<<<<<<<<<<<");
            Console.WriteLine();
            

            DisplayQueue();

            Console.WriteLine("press any key to see the Menu...");
            Console.ReadKey();



        }
        static void DisplayQueue()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");   
            Console.WriteLine("          Patient Queue           ");
            Console.WriteLine();

            if (patientCount == 0)
            {
                Console.WriteLine("No patients in the queue");
            }
            else
            {
                for (int i = 0; i < patientCount; i++)
                {
                    Console.WriteLine((i + 1) + "." + patientQueue[i]);
                }
             Console.WriteLine("==================================");
            }
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
                childPatient = Console.ReadLine();
                Console.WriteLine("Please enter your child's age      ");
               
                while (!int.TryParse(Console.ReadLine(), out childAge) || childAge < 1 || childAge > 12)
                {
                    Console.WriteLine(childPatient + " Please enter age from 0 to 12");
                   
                }
                AddPatientToQueue(childPatient);
                Console.WriteLine("");
                Console.WriteLine("Dr {0} is treating {1}                ", nameOfDoctor, childPatient);
                Console.WriteLine();
                Console.WriteLine("The doctor is almost done");
                Console.WriteLine();
                Console.WriteLine("The next patient can enter the queue");
                Console.WriteLine("===================================");
                Console.WriteLine();


            }
            else if (menuNr == 2)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("         Adult's Doctor            ");
                Console.WriteLine();
                Console.WriteLine("Please enter your name");
                adultPatient = Console.ReadLine();
                AddPatientToQueue(adultPatient);
                Console.WriteLine("");
                Console.WriteLine("Dr {0} is treating {1}                ", nameOfDoctor, patientName);
                Console.WriteLine();
                Console.WriteLine("The doctor is almost done");
                Console.WriteLine();
                Console.WriteLine("The next patient can enter the queue");
                Console.WriteLine("===================================");
                Console.WriteLine();




            }
            else
            {
                Console.Clear();
                Console.WriteLine("You are leaving the Hospital    ");
                isPatientFinished = true;



            }
        }



        static bool isSimulationRunning()
        {
            return !isPatientFinished;
        }

        static void SimulationTime()
        {
            currentMinutes += timeSpentWithPatient;

            if (currentMinutes >= 60)
            {
                currentHour++;
                currentMinutes = 0;
            }

           





        }


       
        static void AddPatientToQueue(string patientName)
        {
            if (patientCount < patientQueue.Length)
            {
                patientQueue[patientCount] = patientName;
                patientCount++;
                Console.WriteLine(patientName + " added to the queue.");
                Console.WriteLine();


            }
            else
            {
                Console.WriteLine("The queue is full!");
            }
        }
       
        static void RemovePatientFromQueue()
        {
            if (patientCount > 0)
            {
                Console.WriteLine(patientQueue[0] + " has been treated.");

                for (int i = 0; i < patientCount - 1; i++)
                {
                    patientQueue[i] = patientQueue[i + 1];
                }
                patientCount--;



            }
        }
        static void Main()
            {
                StartingScreen();

                patientName = GetPatientName();
                patientAge = GetPatientAge();
                Console.WriteLine("Welcome," + patientName + "!");
                Console.WriteLine();

               
               
            while (isSimulationRunning())
            {
                DisplaySimulationTime();
                Menu();

                int menuNr = ShowMenuNr(3);

                ProcessMenuNr(menuNr);

                SimulationTime();



                Console.WriteLine();










                
          


                }
                ExitProgram();
            }
            static void ExitProgram()

            {
                Console.WriteLine("Thank you {0} for coming,get well soon!", patientName);
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

