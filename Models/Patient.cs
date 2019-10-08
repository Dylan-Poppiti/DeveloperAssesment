using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebCore.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName ="varchar(20)")]
        public string FirstName { get; set; }

        [Column(TypeName ="varchar(30)")]
        public string LastName { get; set; }

        [Column(TypeName ="varchar(250)")]
        public string Address { get; set; }

        [Column(TypeName="varchar(50)")]
        public string City { get; set; }

        [Column(TypeName="char(2)")]
        public string State { get; set; }

        [Column(TypeName ="char(5)")]
        public string ZipCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName ="char(1)")]
        public string Gender { get; set; }
        
        public Patient()
        {

        }

        public Patient(int nid, string nFN, string nLN, string nDOB, string nG, string nA, string nC, string nS, string nZ)
        {
            Id = nid;
            FirstName = nFN;
            LastName = nLN;
            DateOfBirth = Convert.ToDateTime(nDOB);
            Gender = nG;
            Address = nA;
            City = nC;
            State = nS;
            ZipCode = nZ;
        }

        //public override string ToString()
        //{
        //    return Id + " " + FirstName + " " + LastName + " " + Address + " " + City + " " + State + " " + ZipCode + " " + DateOfBirth + " " + Gender;
        //}

        public string ToJson()
        {
            string JsonString = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return JsonString;
        }
    }
}

