using System;

namespace Commander_Handbook
{
    public class Soldier
    {
        public string FIO { get; set; }
        public string Address { get; set; }
        public string ParentsAddress { get; set; }
        public string Citizenship { get; set; }
        public string Profession { get; set; }
        public string Rank { get; set; }
        public DateTime DateOfReceivingRank { get; set; }
        public string Education { get; set; }
        public string ServiceForm { get; set; }
        public DateTime StartOfService { get; set; }
        public DateTime EndOfService { get; set; }
        public string MilitaryFormation { get; set; }

        public Soldier()
        {
            DateOfReceivingRank = DateTime.Now;
            StartOfService = DateTime.Now;
            EndOfService = DateTime.Now;
        }

        public Soldier(string str)
        {
            string[] prop = str.Split('|');
            FIO = prop[0];
            Address = prop[1];
            ParentsAddress = prop[2];
            Citizenship = prop[3];
            Profession = prop[4];
            Rank = prop[5];

            var arr = prop[6].Split('.');
            DateOfReceivingRank = new DateTime(Convert.ToInt32(arr[2]),
                Convert.ToInt32(arr[1]),
                Convert.ToInt32(arr[0]));

            Education = prop[7];
            ServiceForm = prop[8];

            arr = prop[9].Split('.');
            StartOfService = new DateTime(Convert.ToInt32(arr[2]),
                Convert.ToInt32(arr[1]),
                Convert.ToInt32(arr[0]));

            arr = prop[10].Split('.');
            EndOfService = new DateTime(Convert.ToInt32(arr[2]),
                Convert.ToInt32(arr[1]),
                Convert.ToInt32(arr[0]));

            MilitaryFormation = prop[11];
        }

        public override string ToString()
        {
            string result = "";
            result += FIO + "|";
            result += Address + "|";
            result += ParentsAddress + "|";
            result += Citizenship + "|";
            result += Profession + "|";
            result += Rank + "|";
            result += DateOfReceivingRank.ToShortDateString().Substring(0, 10) + "|";
            result += Education + "|";
            result += ServiceForm + "|";
            result += StartOfService.ToShortDateString().Substring(0, 10) + "|";
            result += EndOfService.ToShortDateString().Substring(0, 10) + "|";
            result += MilitaryFormation + "|";
            return result;
        }
    }
}
