using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Animals
{
    public abstract class Animal
    {
        public abstract string Eat(); //I don't know the implementation detail
        public abstract string Move();
        public abstract string Breed();
        
        //NOT ABSTRACT
        public  string Die()
        {
            return "Animal Died";
        }

        public bool IsDomestic
        {
            get { return this is IDomestic; }
        }

        public override string ToString()
        {
            return GetType().Name+"#"+GetHashCode();
        }
    }
}
