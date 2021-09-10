using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class PatientList : List<Patient>
    {
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}