using System;
using System.Collections.Generic;

#nullable disable

namespace InteliAPI.Domains
{
    public partial class Usuario
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
