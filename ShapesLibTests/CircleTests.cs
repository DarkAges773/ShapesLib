using AutoFixture.Xunit2;
using ShapesLib;

namespace ShapesLibTests
{
	public class CircleTests
	{
		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(-7f)]
		public void Circle_ConstructorWithInvalidArguments_ThrowsArgumentOutOfRangeException(float radius)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
		}
		[Theory, AutoData]
		public void Circle_CircleArea_ReturnsCorrectArea(float radius)
		{
			float expectedArea = (float)(Math.Pow(radius, 2) * Math.PI);
			float actualArea = Circle.CircleArea(radius);

			Assert.Equal(expectedArea, actualArea);
		}
		[Theory, AutoData]
		public void Circle_GetArea_ReturnsCorrectArea(float radius)
		{
			Circle circle = new Circle(radius);
			float expectedArea = Circle.CircleArea(radius);

			float actualArea = circle.GetArea();

			Assert.Equal(expectedArea, actualArea);
		}
	}
}
