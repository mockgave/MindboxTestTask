using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindBoxTask
{
    [TestClass]
    public class GeometryFiguresTests
    {
        
        [TestMethod("Тест ориентирован на проверку выбрасывания исключений при неверных входных значениях радиуса круга или сторон треугольника. ")]
        public void ExceptionGenerationTests() {

            Assert.ThrowsException<ArgumentOutOfRangeException>( () => _ = new Circle(-1));

            Assert.ThrowsException<ArgumentOutOfRangeException>( () => _ = new Triangle(-1, 2, 3));

            Assert.ThrowsException<ArgumentException>( () => _ = new Triangle(1, 1, 3));
        }

        [TestMethod("Тест ориентирован на проверку корректного вычисления площадей треугольника и круга.")]
        public void AreaCalculationTests() {
                        
            Circle firstCircle  = new(5);
            Circle secondCircle = new(2);

            Triangle firstTriangle  = new(3, 4, 5);
            Triangle secondTriangle = new(3, 3, 3);

            FigureAreaSolver<Circle>   circleAreaSolver   = new();
            FigureAreaSolver<Triangle> triangleAreaSolver = new();

            Assert.AreEqual(78.54, circleAreaSolver.GetFiguredArea(firstCircle, 2));
            Assert.AreEqual(12.6, circleAreaSolver.GetFiguredArea(secondCircle, 1));

            Assert.AreEqual(6, triangleAreaSolver.GetFiguredArea(firstTriangle));
            Assert.AreEqual(3.9, triangleAreaSolver.GetFiguredArea(secondTriangle, 1));
            
        }
    }
}
