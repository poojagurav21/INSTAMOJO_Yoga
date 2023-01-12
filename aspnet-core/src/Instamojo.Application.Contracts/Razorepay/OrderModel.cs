using System.Collections.Generic;

namespace Instamojo.Razorepay
{
    public class OrderModel
    {
        public float OrderAmount { get; set; }
        public string Name { get; set; }
        public float OrderAmountInSubUnits
        {
            get
            {
                return OrderAmount * 100;
            }
        }
        public string Currency { get; set; }
        public int Payment_Capture { get; set; }
        public Dictionary<string, string> Notes { get; set; }
    }
}
