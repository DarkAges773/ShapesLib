namespace ShapesLib
{
	public class Circle : IShape
	{
		private float radius;
		public float Radius { get => radius; set { ValidateRadius(value); radius = value; } }
		/// <summary>
		/// Instantiates new circle with radius. Radius should be more than zero
		/// </summary>
		/// <param name="radius"></param>
		public Circle(float radius)
		{
			Radius = radius;
		}

		/// <summary>
		/// Calculates area of a circle with specified radius
		/// </summary>
		/// <param name="radius"></param>
		/// <returns>Area of a circle</returns>
		public static float CircleArea(float radius)
		{
			// the area of a circle: https://en.wikipedia.org/wiki/Area_of_a_circle
			float area = (float)(Math.Pow(radius, 2) * Math.PI);

			return area;
		}
		/// <summary>
		/// Returns area of the circle
		/// </summary>
		/// <returns>Area of the circle</returns>
		public float GetArea()
		{
			return CircleArea(radius);
		}
		private void ValidateRadius(float radius)
		{
			// the radius of a circle should not be negative or equal to zero
			if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), radius, "Radius of a circle can't be less than or equal to 0");
		}
	}
}
