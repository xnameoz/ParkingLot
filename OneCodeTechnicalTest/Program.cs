using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OneCodeTechnicalTest
{
    class Program
    {
        private static List<ParkingLQ> lp;
        static void Main(string[] args)
        {

            while (1 == 1)
            {
                Console.WriteLine("Input Command:");
                string line = Console.ReadLine();
                RunProgram(line);
            }

        }

        static string[] ParseCmd(string line) {
            string[] vRes = line.Split(' ');
            return vRes;
        }

        static bool IsOdd(int num) {
            if (num % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
           }
        }

        static void RunProgram(string cmd) {
            string[] prc = ParseCmd(cmd);
            string b = prc[0].Trim();
            switch (b)
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                case "create_parking_lot":
                    int slot=0;
                    if (prc[1] != "") { slot=Convert.ToInt16(prc[1]); }
                    if (slot > 0)
                    {
                        int id = 0;
                        lp = new List<ParkingLQ>();
                        for (int i = 0; i < slot; i++)
                        {
                            id += 1;
                            ParkingLQ k = new ParkingLQ() { ID = id  };
                            lp.Add(k);
                        }
                    }
                    break;
                case "park":

                    if (prc[3].ToString().Trim().ToLower() == "mobil") {
                        foreach (ParkingLQ p1 in lp) {
                            if (p1.CarInfo is null) {
                                var ls3 = (from w in lp
                                           where w.ID == p1.ID
                                           select w).FirstOrDefault();
                                if (ls3 != null) {
                                    VehicleInfo v = new VehicleInfo() { SerialNo = prc[1].ToString().Trim().ToLower(), Color = prc[2].ToString().Trim().ToLower(), Type = prc[3].ToString().Trim().ToLower() };
                                    ls3.CarInfo = v;
                                }
                               
                                Console.WriteLine("Allocated slot number: " + p1.ID.ToString());
                                break;
                            }
                        }
                    }
                    else if (prc[3].ToString().Trim().ToLower() == "motor") {
                        foreach (ParkingLQ p0 in lp)
                        {
                            if (p0.BikeInfo is null)
                            {
                                var ls4 = (from w in lp
                                           where w.ID == p0.ID
                                           select w).FirstOrDefault();
                                if (ls4 != null)
                                {
                                    VehicleInfo v = new VehicleInfo() { SerialNo = prc[1].ToString().Trim().ToLower(), Color = prc[2].ToString().Trim().ToLower(), Type = prc[3].ToString().Trim().ToLower() };
                                    ls4.BikeInfo = v;
                                }
                                Console.WriteLine("Allocated slot number: " + p0.ID.ToString());
                                break;
                            }
                        }
                    }
                    break;
                case "leave":
                    int p = Convert.ToInt16( prc[1]);
                    var ls5 = (from w in lp
                               where w.ID == p
                               select w).FirstOrDefault();
                    if (ls5 != null)
                    {
                        if (ls5.CarInfo.Type == "motor") { ls5.BikeInfo = null; } else if (ls5.CarInfo.Type == "mobil") { ls5.CarInfo = null; }
                    }
                    Console.WriteLine("Slot number " + ls5.ID.ToString() +" is free " );

                    break;
                case "status":
                    Console.WriteLine("{0,3}{1,20}{2,6}{3,10}", "Slot", "RegistrationNO", "Type", "Color");
                    foreach (ParkingLQ g in lp)
                    {
                        if ( g.CarInfo != null || g.BikeInfo != null)
                        {
                            Console.WriteLine("{0,3}{1,20}{2,6}{3,10}{4,20}{5,6}{6,10}  ", g.ID, g.CarInfo.SerialNo, g.CarInfo.Type, g.CarInfo.Color, g.BikeInfo.SerialNo,g.BikeInfo.Type,g.BikeInfo.Color);
                        }
                        else {
                           Console.WriteLine("{0,3}{1,20}{2,6}{3,10}", g.ID, "", "", ""); 
                        }
                    }
                    
                    break;
                case "type_of_vehicles":
                    var jml=0;
                    if (prc[1].ToLower() == "motor") { jml = lp.Count(n => n.BikeInfo != null);
                    } else if (prc[1].ToLower() == "mobil") { jml = lp.Count(n => n.CarInfo != null); }

                    Console.WriteLine(jml);
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    foreach (ParkingLQ z in lp)
                    {
                        if (z.CarInfo != null)
                        {
                            var trimmed = Regex.Replace(z.CarInfo.SerialNo, @"^[A-Za-z]+", "");
                            int y = Convert.ToInt32(trimmed);
                            if (IsOdd(y))
                            {
                                Console.Write(z.CarInfo.SerialNo + ",");
                            }
                        }
                        if (z.BikeInfo != null)
                        {
                            var trimmed = Regex.Replace(z.BikeInfo.SerialNo, @"^[A-Za-z]+", "");
                            int y = Convert.ToInt32(trimmed);
                            if (IsOdd(y))
                            {
                                Console.Write(z.BikeInfo.SerialNo + ",");
                            }
                        }
                    }

                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    foreach (ParkingLQ z in lp) {
                        if (z.CarInfo != null) {
                            var trimmed = Regex.Replace(z.CarInfo.SerialNo, @"^[A-Za-z]+", "");
                            int y = Convert.ToInt32(trimmed);
                            if (!IsOdd(y))
                            {
                                Console.Write(z.CarInfo.SerialNo + ",");
                            }
                        }
                        if (z.BikeInfo != null) {
                            var trimmed = Regex.Replace(z.BikeInfo.SerialNo, @"^[A-Za-z]+", "");
                            int y = Convert.ToInt32(trimmed);
                            if (!IsOdd(y))
                            {
                                Console.Write(z.BikeInfo.SerialNo + ",");
                            }
                        }
                    }
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    string color = prc[1].Trim();
                    var ls1 = (from w in lp
                               where w.BikeInfo.Color == color || w.CarInfo.Color == color
                               select w).FirstOrDefault();
                    Console.WriteLine("Allocated slot number: " + ls1.ID.ToString());
                    break;
                case "slot_number_for_registration_number":
                    string regno = prc[1].Trim();
                    var lsP = (from w in lp
                               where w.BikeInfo.SerialNo == regno || w.CarInfo.SerialNo==regno
                               select w).FirstOrDefault();
                    Console.WriteLine("Allocated slot number: " + lsP.ID.ToString());
                    break;
            }
        }
    }
}
