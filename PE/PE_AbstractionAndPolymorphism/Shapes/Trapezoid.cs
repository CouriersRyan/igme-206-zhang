namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Trapezoids are quadrilaterals with two parallel sides of different lengths.
    /// </summary>
    class Trapezoid : Shape
    {
        // fields
        private double base1;
        private double base2;
        private double height;

        // properties
        /// <summary>
        /// Same implementation of Trapezoid area as CalculateArea()
        /// </summary>
        public override double Area
        {
            get
            {
                return ((base1 + base2) * 0.5) *  height;
            }
        }

        // constructors
        /// <summary>
        /// Constructor for a Trapezoid shape as its two bases and height
        /// </summary>
        /// <param name="base1"></param>
        /// <param name="base2"></param>
        /// <param name="height"></param>
        public Trapezoid(double base1, double base2, double height) : base("trapezoid")
        {
            this.base1 = base1;
            this.base2 = base2;
            this.height = height;
        }

        // methods
        /// <summary>
        /// Returns area of a trapezoid using the formula:
        /// (base1 + base2)/2  *  height;
        /// </summary>
        /// <returns></returns>
        public override double CalculateArea()
        {
            return ((base1 + base2) * 0.5) * height;
        }
    }
}
