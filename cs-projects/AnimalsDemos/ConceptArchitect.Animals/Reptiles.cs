using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Animals
{
    public abstract class Reptile :Animal,IHunter
    {

        public override string Move()
        {
            return "Reptile crawls";
        }
        public override string Breed()
        {
            return "Reptile Lays Egg";
        }
        public override string Eat()
        {
            return "Reptile is Flesh Eater";
        }

        //public virtual string Hunt()
        //{
        //    return "Reptile Hunts its Prey";
        //}

        public abstract string Hunt();

    }

    public class Crocodile: Reptile
    {
        public override string Hunt()
        {
            return "Crocodile is a great underwater hunter";
        }
    }

    public class Snake : Reptile
    {
        public override string Hunt()
        {
            return "Snake is a poisonous hunter";
        }
    }
}
