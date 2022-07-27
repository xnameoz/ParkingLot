using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCodeTechnicalTest
{
    public class Parking
    {
        public int[] SlotMotoBike { get; set; }
        public int[] SlotCar { get; set; }
        public VehicleInfo[] BikeInfo { get; set; }
        public VehicleInfo[] CarInfo { get; set; }

        public Parking(int slot) {
            SlotMotoBike = new int[slot];
            SlotCar = new int[slot];
            BikeInfo = new VehicleInfo[slot];
            CarInfo = new VehicleInfo[slot];
            //int val = 1;
            //for (int i = 0; i < slot; i++) {
            //    SlotMotoBike[i] = val;
            //    val++;
            //}
            
        }

    }

    public class ParkingLQ
    {
        public int ID { get; set; }
        public VehicleInfo BikeInfo { get; set; }
        public VehicleInfo CarInfo { get; set; }

    }
    public class VehicleInfo
    {
        public string SerialNo { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}

