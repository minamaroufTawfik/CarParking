using System;
using CarParking.Core.Entities.Base;

namespace CarParking.Core.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
