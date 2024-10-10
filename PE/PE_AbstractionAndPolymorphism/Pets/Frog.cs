namespace Abstraction_Polymorphism_Demo.Pets
{
    public class Frog : Pet
    {
        public Frog(string name, DateTime birthday)
            : base(name, birthday, "frog")
        {
        }

        public override void Speak()
        {
            Console.WriteLine(this.Name + " says RIBBIT.");
        }
    }
}
