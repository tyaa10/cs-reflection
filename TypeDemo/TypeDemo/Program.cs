using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = getSurprize();
            Type type = result.GetType();
            Console.WriteLine(type.Name);

            /*foreach (var fieldInfo in type.GetFields())
            {
                Console.WriteLine($"field: {fieldInfo.Name}, value: {fieldInfo.GetValue(result)}");
            }*/

            /*foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (fieldInfo.Name == "name")
                {
                    fieldInfo.SetValue(result, "HelloName");
                }
            }

            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"field: {fieldInfo.Name}, value: {fieldInfo.GetValue(result)}");
            }*/

            foreach (var method in type.GetMethods())
            {
                if (method.Name == "ToString")
                {
                    
                    //new Object[] {,}
                    //new Object[] {new Object[] {42}}
                    Console.WriteLine(method.Invoke(result, null));
                }
            }
        }

        static dynamic getSurprize() {
            Random random = new Random();
            int variant = random.Next(1, 5);
            Console.WriteLine(variant);
            switch (variant)
            {
                case 1:
                    return new Person() { id = 1, Name = "Yurii"};
                case 2:
                    return new { id = 2f, name = "Vasia", age = 25 };
                case 3:
                    return new { id = 3, person = new Person() };
                default:
                    return new Person2() { id = 10, name = "Name" }; 
            }
        }
    }

    class Person {
        public int id;
        //public string name { get; set; }
        //public string name { get { return name; } set { name = (value != "") ? value : "NoName"; } }

        private string name;
        public string Name { get { return name; } set { name = (value != "") ? value : "NoName"; } }
    }

    class Person2
    {
        public int id;
        //public string name { get; set; }
        //public string name { get { return name; } set { name = (value != "") ? value : "NoName"; } }

        public string name;
        public override string ToString()
        {
            return $"id = {id}, name = {name}";
        }
    }
}
