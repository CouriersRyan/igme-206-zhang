namespace Abstraction_Polymorphism_Demo.Pets
{
    public class Snake : Pet
    {
        public Snake(string name, DateTime birthday)
            : base(name, birthday, "snake")
        {
        }

        public override void Speak()
        {
            Console.WriteLine(this.Name + " says HISS.");
        }
    }
}
