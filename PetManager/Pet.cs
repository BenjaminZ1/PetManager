using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManager {
    public class Pet {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthday { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - Birthday.Year;
                if (Birthday.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public Pet() { }

        public Pet(DateTime birthday)
        {
            Birthday = birthday;
        }


        public int GetHashCode(Pet obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^ (obj.Breed != null ? obj.Breed.GetHashCode() : 0);
            }
        }

    }
}
