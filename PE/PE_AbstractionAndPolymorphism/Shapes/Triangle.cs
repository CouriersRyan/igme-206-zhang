namespace Abstraction_Polymorphism_Demo.Shapes
{
    // Triangles are any shape with three sides.
    class Triangle : Shape
    {
        // fields
        private double width;
        private double height;

        // properties
        /// <summary>
        /// Same implementation of Triangle area as CalculateArea()
        /// </summary>
        public override double Area {
        get
            {
                return width * height * 0.5;
            }
        }

        // constructors
        /// <summary>
        /// Constructor for a Triangle shape as its width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Triangle(double width, double height) : base("triangle")
        {
            this.width = width;
            this.height = height;
        }

        // methods
        /// <summary>
        /// Returns area of a triangle using the formula:
        /// (width * height)/2
        /// </summary>
        /// <returns></returns>
        public override double CalculateArea()
        {
            return width * height * 0.5;
        }
    }
}
