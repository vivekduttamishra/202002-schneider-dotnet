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
                Console.WriteLine("Animal is "+animal);
                Console.WriteLine(animal.Move());
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Breed());
                Console.WriteLine(animal.Die());
                Console.WriteLine();

               // Console.WriteLine(animal.Hunt());
            }

            Console.WriteLine("Special Eagle's Death");
            Eagle eagle = new Eagle();
            Console.WriteLine(eagle.Die());

        }
    }
}
