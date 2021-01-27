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
        /// <summary>
        /// The name of the entry
        /// </summary>
        /// <example>John Doe</example>
        public string Name { get; set; }
        /// <summary>
        /// The type of phone book entry
        /// </summary>
        /// <example>Cellphone</example>
        public PType PType { get; set; }
        /// <summary>
        /// The phone number
        /// </summary>
        /// <example>+355696542518</example>
        public string Number { get; set; }


    }

    public enum PType {
        Cellphone = 1,
        Work = 2,
        Home = 3
    }
}
