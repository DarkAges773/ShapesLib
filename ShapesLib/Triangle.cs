namespace ShapesLib
{
	public class Triangle : IShape
	{
		private float[] sides;
		public float[] Sides { get { return sides; } }
		public float SideA { get => sides[0]; set { ValidateSide(value); sides[0] = value; } }
		public float SideB { get => sides[1]; set { ValidateSide(value); sides[1] = value; } }
		public float SideC { get => sides[2]; set { ValidateSide(value); sides[2] = value; } }

		
		/// <summary>
		/// Instantiates new trianle with sides A, B and C. Sides should be more than zero
		/// </summary>
		/// <param name="sideA"></param>
		/// <param name="sideB"></param>
		/// <param name="sideC"></param>
		public Triangle(float sideA, float sideB, float sideC)
		{
			sides = new float[3];
			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
		}

		/// <summary>
		/// Calculates the area of a triangle from three sides
		/// </summary>
		/// <param name="sideA">Lenght of the side A</param>
		/// <param name="sideB">Lenght of the side B</param>
		/// <param name="sideC">Lenght of the side C</param>
		/// <returns>Area of the triangle</returns>
		public static float Heron(float sideA, float sideB, float sideC)
		{
			// Heron's formula for calculating the area of a triangle, using only its sides: https://en.wikipedia.org/wiki/Heron%27s_formula

			float perimeter = sideA + sideB + sideC;
			float semiPerimeter = perimeter / 2;
			float area = (float)Math.Sqrt(
					semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter * sideC)
					);
			return area;
		}
		/// <summary>
		/// Calculates the hypotenuse of a triangle with legs A and B
		/// </summary>
		/// <param name="legA">Lenght of the leg A</param>
		/// <param name="legB">Lenght of the leg A</param>
		/// <returns>Hypotenuse of the triangle</returns>
		public static float Pythagorean(float legA, float legB)
		{
			// Pythagorean theorem for calculating a hypotenuse from two legs of a triangle: https://en.wikipedia.org/wiki/Pythagorean_theorem

			float hypotenuse = (float)Math.Sqrt(
				Math.Pow(legA, 2) + Math.Pow(legB, 2)
				);
			return hypotenuse;
		}

		/// <summary>
		/// Determines if the triangle is right angled
		/// </summary>
		/// <returns>true if the angle has right angle</returns>
		public bool HasRightAngle()
		{
			// We will use Pythagorean theorem to calculate the hypotenuse of a triangle with said legs
			// if the calculated hypotenuse will equal to actual hypotenuse of a triangle, then the triangle is right angled.

			float[] sidesOrderedAsc = sides.OrderBy(f => f).ToArray();
			float legA = sidesOrderedAsc[0];
			float legB = sidesOrderedAsc[1];
			float hypotenuse = sidesOrderedAsc[2];

			bool result = hypotenuse == Pythagorean(legA, legB);

			return result;
		}
		/// <summary>
		/// Calculates the area of the triangle
		/// </summary>
		/// <returns>Area of the triangle</returns>
		public float GetArea()
		{
			return Heron(SideA, SideB, SideC);
		}
		private void ValidateSide(float side)
		{
			// i think the triangle should not become a line, nor its sides have negative values
			// so each side should have a value greater than zero
			if (side <= 0) throw new ArgumentOutOfRangeException(nameof(side), side, "Side of a triangle can't be less than or equal to 0");
		}
	}
}
