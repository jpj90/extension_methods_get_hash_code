using System;
using System.Collections.Generic;
using System.Reflection;
using ExtensionMethods;

namespace MyCode
{
  class Program
  {
    // inspiration from https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2019
    public static void Main()
    {
      Console.WriteLine("program starting...");

      Person person1 = new Person
      {
        name = "Anna",
        age = 33,
        profession = "Marketeer",
        isHipster = true
      };
      Person person2 = new Person
      {
        name = "John",
        age = 33,
        profession = "Farmer",
        isHipster = true
      };

      List<PropertyInfo> exclusionProperties = new List<PropertyInfo> { person1.GetType().GetProperty("name"), typeof(Person).GetProperty("profession") }; // two ways of accomplishing this
      Console.WriteLine("Comparing person {0} with person {1}, equality test yielded: {2}",person1.name, person2.name, person1.GetHashCode(exclusionProperties) == person2.GetHashCode(exclusionProperties));
      Console.ReadLine();

    }
  }

  public class Person
  {

    public string name { get; set; }
    public int age { get; set; }
    public string profession { get; set; }
    public bool isHipster { get; set; }

    public override string ToString()
    {
      return String.Format("Person: name: {0}, age: {1}, profession: {2}", name, age, profession);
    }
  }
}
