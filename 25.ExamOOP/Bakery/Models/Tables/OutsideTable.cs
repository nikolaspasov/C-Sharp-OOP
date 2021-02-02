using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        public OutsideTable
            (int tableNumber, int capacity, decimal pricePerPerson)
            : base(tableNumber, capacity, 3.50m)
        {
        }
        public override string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
               sb.AppendLine($"Table: {TableNumber}");
               sb.AppendLine($"Type: {nameof(OutsideTable)}");
               sb.AppendLine($"Capacity: {Capacity}");
               sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().Trim();
        }
        
    }
}
