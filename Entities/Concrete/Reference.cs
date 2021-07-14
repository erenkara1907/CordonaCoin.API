using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Reference:IEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string FullName { get; set; }
        public double Amount { get; set; }
        public DateTime date { get; set; }
    }
}
