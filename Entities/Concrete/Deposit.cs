using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Deposit:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
