using System;

namespace RedSquirrel.Models
{
    public class Food : OwnedObject
    {
        public Int32?  Id { get; set;}
        public String Name { get; set; }
    }
}