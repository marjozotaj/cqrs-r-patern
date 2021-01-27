using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Presistence.DAL;

namespace Domain
{
    public class PhoneBook 
    {
        public PhoneBook(){}
        public PhoneBook(string name, PType pType, string number)
        {
            Id = Guid.NewGuid();
            Name = name;
            PType = pType;
            Number = number;
        }

        public Guid Id{get;set;}
        public string Name { get; set; }
        public PType PType { get; set; }
        public string Number { get; set; }


    }

    public enum PType {
        Cellphone = 1,
        Work = 2,
        Home = 3
    }
}
