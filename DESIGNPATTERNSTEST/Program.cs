using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESIGNPATTERNSTEST
{
    internal class Program
    {
        // Define the pizza class
        public class Pizza
        {
            public string Size { get; set; }
            public string Crust { get; set; }
            public List<string> Toppings { get; set; }
        }

        // Define the pizza builder interface
        public interface IPizzaBuilder
        {
            void SetSize(string size);
            void SetCrust(string crust);
            void AddTopping(string topping);
            Pizza GetPizza();
        }

        // Implement the pizza builder interface
        public class PizzaBuilder : IPizzaBuilder
        {
            private Pizza _pizza = new Pizza();

            public void SetSize(string size)
            {
                _pizza.Size = size;
            }

            public void SetCrust(string crust)
            {
                _pizza.Crust = crust;
            }

            public void AddTopping(string topping)
            {
                if (_pizza.Toppings == null)
                {
                    _pizza.Toppings = new List<string>();
                }

                _pizza.Toppings.Add(topping);
            }

            public Pizza GetPizza()
            {
                return _pizza;
            }
        }

        // Define the pizza director
        public class PizzaDirector
        {
            private IPizzaBuilder _builder;

            public PizzaDirector(IPizzaBuilder builder)
            {
                _builder = builder;
            }

            public void MakePizza()
            {
                _builder.SetSize("Large");
                _builder.SetCrust("Thin");
                _builder.AddTopping("Pepperoni");
                _builder.AddTopping("Mushrooms");
            }
        }

        // Example usage
        static void Main(string[] args)
        {
            // Create a new pizza builder
            var builder = new PizzaBuilder();

            // Create a new pizza director
            var director = new PizzaDirector(builder);

            // Make a pizza using the director
            director.MakePizza();

            // Get the finished pizza
            var pizza = builder.GetPizza();

            // Output the pizza details
            Console.WriteLine($"Size: {pizza.Size}, Crust: {pizza.Crust}, Toppings: {string.Join(", ", pizza.Toppings)}");
        }

    }
}
