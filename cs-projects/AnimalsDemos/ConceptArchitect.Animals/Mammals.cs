using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Animals
{
    public abstract class Mammal : Animal
    {
        public override string Breed()
        {
            return "Mammals gives brith to baby";
        }
    }

    public class Cow : Mammal
    {
        public override string Eat()
        {
            return "Cow is Grasseater";
        }
        public override string Move()
        {
            return "Cow moves on Land";
        }

        public string ProvidesMilk()
        {
            return "Cow Provides Milk";
        }
    }

    public class Deer : Mammal
    {
        public override string Eat()
        {
            return "Deer is Grasseater";
        }
        public override string Move()
        {
            return "Deer moves on Land";
        }
    }

    public class Horse : Mammal
    {
        public override string Eat()
        {
            return "Horse is Grasseater";
        }
        public override string Move()
        {
            return "Horse moves on Land";
        }
        public string Ride()
        {
            return "Horse is a great ride";
        }
    }

    public class Camel : Mammal
    {
        public override string Eat()
        {
            return "Camel is Grasseater";
        }
        public override string Move()
        {
            return "Camel moves on Land";
        }

        public string Ride()
        {
            return "Horse is a desert ride";
        }
    }

    public abstract class Cat : Mammal
    {
        public override string Eat()
        {
            return Hunt()+": Cat is flesh eater";
        }
        public override string Move()
        {
            return "Cat moves on land";
        }

        public string Hunt()
        {
            return "Cat Hunts its prey";
        }
    }

    public class Dog : Mammal
    {
        public override string Eat()
        {
            return Hunt() + ": Dog is flesh eater";
        }
        public override string Move()
        {
            return "Dog moves on land";
        }

        public string Hunt()
        {
            return "Dog Hunts its prey";
        }
    }

    public class Tiger : Cat
    { }



}
