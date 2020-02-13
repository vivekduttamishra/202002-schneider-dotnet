using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Animals
{
    public abstract class Bird : Animal
    {
        public override string Breed()
        {
            return "Bird Lays Egg";
        }

        public override string Move()
        {
            return Fly();
        }
        public string Fly()
        {
            return "Bird Flies";
        }

    }

   public  class Parrot : Bird
    {
        public override string Eat()
        {
            return "Parrot is a Fruitarian";
        }

        public String HumanSpeak()
        {
            return "Parrot can speak like human";
        }
    }

   public  class Eagle: Bird
    {
        public string Hunt()
        {
            return "Eagle is a flying hunter";
        }

        public override string Eat()
        {
            return "Eagle is a flesh eater";
        }

        public  string Die()
        {
            return "Eagle Dies in air";
        }
    }
}
