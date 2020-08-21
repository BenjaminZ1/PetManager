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
        public override bool Equals(object obj)
        {
            if (!(obj is Pet))
            {
                return object.Equals(obj, this);
            }
            var pet = (Pet)obj;
            return Birthday.Equals(pet.Birthday) && string.Equals(this.Name, pet.Name) &&
                   string.Equals(this.Breed, pet.Breed);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Breed != null ? this.Breed.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.Birthday.GetHashCode();
                return hashCode;
            }
        }

    }
}
