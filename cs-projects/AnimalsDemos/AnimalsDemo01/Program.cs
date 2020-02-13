using ConceptArchitect.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo01
{
    class Program
    {
        static void Main2()
        {
            Tiger tiger = new Tiger();

            Console.WriteLine(tiger.Eat());
            Console.WriteLine(tiger.Hunt());

            Animal animal = tiger;
            Console.WriteLine(animal.Eat());
            

            Tiger tiger2 = (Tiger)animal; //do it at my risk!

            Console.WriteLine(   tiger.Hunt() );



        }


        static void Main(string[] args)
        {
            Animal[] animals =
            {
                new Tiger(),
                new Deer(),
                new Horse(),
                //new Bird(),
                new Snake(),
                new Cow(),
                //new Animal(),
                new Crocodile(),
                new Parrot(),
               // new Reptile(),
                new Camel(),
                //new Mammal(),
                //new Cat(),
                new Eagle(),
                new Dog(),
                
            };

            


            foreach(var animal in animals)
            {
                if (animal.IsDomestic)
                    Console.Write("Domestic ");
                Console.WriteLine("Animal is " + animal);
                
                Console.WriteLine(animal.Move());
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Breed());

                //de-abstraction <--- NOT RECOMMENDED!
                //HuntIfYouAreATiger(animal);

                //re-abstraction
                HuntIfYouAreAHunter(animal);

                RideIfRideable(animal);

                Console.WriteLine(animal.Die());

                Console.WriteLine();
            }

            Console.WriteLine("Special Eagle's Death");
            Eagle eagle = new Eagle();
            Console.WriteLine(eagle.Die());

        }

        private static void RideIfRideable(Animal animal)
        {
            IRideable rideable = animal as IRideable; //returns null if conversion fails
            if(rideable!=null)
                Console.WriteLine(rideable.Ride());
        }

        private static void HuntIfYouAreAHunter(Animal animal)
        {
            if (animal is IHunter)
            {
                IHunter tiger = (IHunter)animal; //throws exception if conversion fails
                Console.WriteLine(tiger.Hunt());
            }
        }


        private static void HuntIfYouAreATiger(Animal animal)
        {
            if (animal is Tiger)
            {
                Tiger tiger = (Tiger)animal;
                Console.WriteLine(tiger.Hunt());
            }
        }

        void ScratchPad()
        {
            Tiger tiger = new Tiger();
            tiger.Hunt();
            Animal animal = tiger;
            

        }
    }
}
