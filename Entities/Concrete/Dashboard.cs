using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Dashboard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double DepositWalletBalance { get; set; }
        public double InterestWalletBalance { get; set; }
        public double TotalDeposit { get; set; }
        public double TotalWithdraw { get; set; }
        public double TotalInvest { get; set; }
        public double ReferralEarnings { get; set; }
    }
}
