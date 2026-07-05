using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.storage;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using System;
using System.Threading.Channels;


namespace IntelligencePipeline.Pipeline
{
    class Program
    {
       


           
            public static void Main(string[] args)
            {
            ;
            int choise = -1;
                while (choise!= 6)
                {
                    Console.WriteLine(stati());
                    Console.WriteLine("\n--- Intelligence Report Pipeline System ---");
                    Console.WriteLine("1. Enter Drone Report");
                    Console.WriteLine("2. Enter Soldier Report");
                    Console.WriteLine("3. Enter Radar Report");
                    Console.WriteLine("4. Enter Signal Report");
                    Console.WriteLine("5. Display System Statistics");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            CreateDroneReport();
                            break;
                        case "2":
                            CreateSoldierReport();
                            break;
                        case "3":
                            CreateRadarReport();
                            break;
                        case "4":
                            CreateSignalReport();
                            break;
                       case "5":
                         stati();
                        break;
                    case "6":
                            break;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
            }

            private static (int id, DateTime ts, double lat, double lon, string desc) PromptCommonFields()
            {
                Console.Write("Enter Report ID (integer): ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Timestamp (yyyy-MM-dd HH:mm): ");
                DateTime ts = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Latitude: ");
                double lat = double.Parse(Console.ReadLine());

                Console.Write("Enter Longitude: ");
                double lon = double.Parse(Console.ReadLine());

                Console.Write("Enter Description: ");
                string desc = Console.ReadLine();

                return (id, ts, lat, lon, desc);
            }

            private static void CreateDroneReport()
            {
                var common = PromptCommonFields();

                Console.Write("Enter Altitude: ");
                int altitude = int.Parse(Console.ReadLine());

                Console.Write("Enter Image Quality (1-100): ");
                int imageQuality = int.Parse(Console.ReadLine());

                DroneReport report = new DroneReport(common.id, common.ts, common.lat, common.lon, common.desc, altitude, imageQuality);

               ReportPipline pipeline = new ReportPipline();
            pipeline.ProcessReport(report);
            Console.WriteLine("Report sent to processing pipeline.");
           
            }

            private static void CreateSoldierReport()
            {
                var common = PromptCommonFields();

                Console.Write("Enter Soldier Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Soldier ID (7 digits): ");
                string soldierId = Console.ReadLine();

                Console.Write("Enter Unit: ");
                string unit = Console.ReadLine();

                Console.Write("Enter Confidence Level (1-5): ");
                int confidence = int.Parse(Console.ReadLine());

                SoldierReport report = new SoldierReport(common.id, common.ts, common.lat, common.lon, common.desc, name, soldierId, unit, confidence);
               
                Console.WriteLine("Report sent to processing pipeline.");
            }

            private static void CreateRadarReport()
            {
                var common = PromptCommonFields();

                Console.Write("Enter Speed: ");
                int speed = int.Parse(Console.ReadLine());

                Console.Write("Enter Direction (0-360): ");
                int direction = int.Parse(Console.ReadLine());

                Console.Write("Enter Distance: ");
                int distance = int.Parse(Console.ReadLine());

                RadarReport report = new RadarReport(common.id, common.ts, common.lat, common.lon, common.desc, speed, direction, distance);
              ReportPipline pipeline = new ReportPipline();
               pipeline.ProcessReport(report);
            Console.WriteLine("Report sent to processing pipeline.");
            }

            private static void CreateSignalReport()
            {
                var common = PromptCommonFields();

                Console.Write("Enter Frequency: ");
                double frequency = double.Parse(Console.ReadLine());

                Console.Write("Enter Content: ");
                string content = Console.ReadLine();

                Console.WriteLine("Select Language: 0=Hebrew, 1=Arabic, 2=English, 3=Russian, 4=Other");
                Console.Write("Enter Language Code: ");
                Language language = (Language)int.Parse(Console.ReadLine());

                Console.Write("Enter Signal Strength (-120 to 0): ");
                int strength = int.Parse(Console.ReadLine());

                SignalReport report = new SignalReport(common.id, common.ts, common.lat, common.lon, common.desc, frequency, content, language, strength);
                ReportPipline pipeline = new ReportPipline();
               pipeline.ProcessReport(report);
            Console.WriteLine("Report sent to processing pipeline.");
            }
        private static int stati()
        {
            ReportRepository reportre = new ReportRepository();
            int sumi = reportre.GetTotalCount();
            return sumi;
           
        }
        

       
    }
}


    
            
        
    


    

