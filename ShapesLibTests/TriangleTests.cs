using AutoFixture.Xunit2;
using ShapesLib;

namespace ShapesLibTests
{
	public class TriangleTests
	{
		[Theory]
		[InlineData(0f, 0f, 0f)]
		[InlineData(-1f, 1f, 1f)]
		[InlineData(-1f, -1f, -1f)]
		[InlineData(1f, 1f, 0f)]
		[InlineData(-1f, 1f, 0f)]
		public void Triangle_ConstructorWithInvalidArguments_ThrowsArgumentOutOfRangeException(float sideA, float sideB, float sideC)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
		}
		[Theory, AutoData]
		public void Triangle_Heron_ReturnsCorrectArea(Triangle triangle)
		{
			float perimeter = triangle.SideA + triangle.SideB + triangle.SideC;
			float semiPerimeter = perimeter / 2;
			float expectedArea = (float)Math.Sqrt(
					semiPerimeter * (semiPerimeter - triangle.SideA) * (semiPerimeter - triangle.SideB) * (semiPerimeter * triangle.SideC)
					);

			float actualArea = Triangle.Heron(triangle.SideA, triangle.SideB, triangle.SideC);

			Assert.Equal(expectedArea, actualArea);
		}
		[Theory, AutoData]
		public void Triangle_GetArea_ReturnsCorrectArea(Triangle triangle)
		{
			float expectedArea = Triangle.Heron(triangle.SideA, triangle.SideB, triangle.SideC);
			float actualArea = triangle.GetArea();

			Assert.Equal(expectedArea, actualArea);
		}
		[Theory, AutoData]
		public void Triangle_Pythagorean_ReturnsCorrectHypotenuse(float legA, float legB)
		{
			float expectedHypotenuse = (float)Math.Sqrt(
				Math.Pow(legA, 2) + Math.Pow(legB, 2)
				);
			float actualHypotenuse = Triangle.Pythagorean(legA, legB);

			Assert.Equal(expectedHypotenuse, actualHypotenuse);
		}
		[Theory]
		[InlineData(3.5f, 2.1f, 2.8f)]
		public void Triangle_HasRightAngleWithRightAngledTriangle_IsTrue(float sideA, float sideB, float sideC)
		{
			Triangle triangle = new Triangle(sideA, sideB, sideC);
			Assert.True(triangle.HasRightAngle());
		}		
		[Theory]
		[InlineData(3.5f, 2.1f, 2f)]
		[InlineData(3.5f, 2.1f, 5f)]
		[InlineData(3.5f, 2.1f, 2.7f)]
		public void Triangle_HasRightAngleWithNotRightAngle_IsFalse(float sideA, float sideB, float sideC)
		{
			Triangle triangle = new Triangle(sideA, sideB, sideC);
			Assert.False(triangle.HasRightAngle());
		}
	}
}