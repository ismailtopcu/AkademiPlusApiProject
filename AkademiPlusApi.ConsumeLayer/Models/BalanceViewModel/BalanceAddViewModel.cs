using System;

namespace AkademiPlusApi.ConsumeLayer.Models.BalanceViewModel
{
    public class BalanceAddViewModel
    {
        public string AccountNumber { get; set; }
        public Decimal CustomerBalance { get; set; }
        public string Currency { get; set; }
    }
}
