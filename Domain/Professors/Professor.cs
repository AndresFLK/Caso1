using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Professor
{
    public class Professor
    {
        public Professor()
        {
        }

        public static Professor Create(int id, string firstName, string lastNmae ,string phoneNumber) {
            
            return new Professor
            {
                Id = id,
                FirstName = firstName,
                LastName = lastNmae,
                PhoneNumber = phoneNumber
            };
        }

        public static Professor Create(int id, Professor professor)
        {
            return new Professor
            {
                Id = id,
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                PhoneNumber = professor.PhoneNumber
            };
        }

        //------------Atributos de la clase---------
        [Key]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

    }//fin de la clase
}//fin del namespace
