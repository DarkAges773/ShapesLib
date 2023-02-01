using AutoFixture;
using ShapesLib;
using System.Collections;

namespace ShapesLibTests
{
	public class IShapeTestDataGenerator : IEnumerable<object[]>
	{
		public IShapeTestDataGenerator()
		{
			Fixture fixture = new Fixture();
			var triangle = fixture.Create<Triangle>();
			var circle = fixture.Create<Circle>();

			_data = new List<object[]>
			{
				new object[] { triangle, triangle.GetArea() },
				new object[] { circle, circle.GetArea() }
			};
		}
		private readonly List<object[]> _data;
		public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	public class IShapeTests
	{
		[Theory]
		[ClassData(typeof(IShapeTestDataGenerator))]
		public void IShape_GetArea_ShouldReturnAreaOfTheShape(IShape shape, float expectedArea)
		{
			float actualArea = shape.GetArea();

			Assert.Equal(expectedArea, actualArea);
		}
	}
}
