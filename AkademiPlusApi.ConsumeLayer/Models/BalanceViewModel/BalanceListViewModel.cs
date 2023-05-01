using System;

namespace AkademiPlusApi.ConsumeLayer.Models.BalanceViewModel
{
    public class BalanceListViewModel
    {
        public int BalanceID { get; set; }
        public string AccountNumber { get; set; }
        public Decimal CustomerBalance { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
    }
}
