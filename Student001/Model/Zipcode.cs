using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class Zipcode
    {
        public int zipcodeId { get; set; } //PK
        //[Key] // måske virker dettte -PK
        public int zipcode { get; set; }
        public string city { get; set; }
        public List<Student> student { get; set; }
    }
}
