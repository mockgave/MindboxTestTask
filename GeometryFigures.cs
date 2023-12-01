
namespace MindBoxTask 
{

    /// <summary>
    /// Интерфейс, который должны реализовывать все геометрические фигуры.
    /// </summary>
    public interface IFigure
    {

        /// <summary>
        /// Метод предназначен для получения площади фигуры.
        /// </summary>
        /// <param name="numberOfSignificantFigures">Количество значащих цифр после запятой.</param>
        /// <returns></returns>
        double GetArea(int numberOfSignificantFigures = 3);

    }


    /// <summary>
    /// Класс моделирует геометрическую фигуру "Круг".
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Радиус окружности.
        /// </summary>
        private double _radius;

        public double GetArea(int numberOfSignificantFigures = 3) {

            return Math.Round(Math.PI * Math.Pow(_radius, 2), numberOfSignificantFigures); 
        
        }

        public Circle(double radius) {
        
            if (Double.IsNegative(radius))
                throw new ArgumentOutOfRangeException(nameof(radius), "Радиус круга не может быть отрицательным!");

            _radius = radius;

        }

    }


    /// <summary>
    /// Класс моделирует геометрическую фигуру "Треугольник".
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// Длина меньшей стороны.
        /// </summary>
        private readonly double _firstSideLength;

        /// <summary>
        /// Длина средней стороны.
        /// </summary>
        private readonly double _secondSideLength;

        /// <summary>
        /// Длина большей стороны.
        /// </summary>
        private readonly double _thirdSideLength;

        /// <summary>
        /// Флаг "прямоугольности" треугольника.
        /// </summary>
        private readonly bool _isRigthTriangle;


        /// <summary>
        /// Треугольник является прямоугольным.
        /// </summary>
        public bool IsRigthTriangle => _isRigthTriangle; 


        public Triangle(double firstSideLength, double secondSideLength, double thirdSideLength) {
        
            if ( Double.IsNegative(firstSideLength) || Double.IsNegative(secondSideLength) || Double.IsNegative(thirdSideLength) )
                throw new ArgumentOutOfRangeException("Длина ни одной из сторон треугольника не может быть отрицательной!");

            if ( (firstSideLength + secondSideLength < thirdSideLength) || (firstSideLength + thirdSideLength < secondSideLength) || (secondSideLength + thirdSideLength < firstSideLength) )
                throw new ArgumentException("Треугольник с данными сторонами существовать не может!");
        
            List<double> inputLengths = new List<double>{ firstSideLength, secondSideLength, thirdSideLength};
            inputLengths.Sort(); 

            _firstSideLength  = inputLengths[0];
            _secondSideLength = inputLengths[1];
            _thirdSideLength  = inputLengths[2];

            if ( Math.Pow(inputLengths[0], 2) + Math.Pow(inputLengths[1], 2) == Math.Pow(inputLengths[2], 2) )
                _isRigthTriangle = true;
            else
                _isRigthTriangle = false;

        }

        public double GetArea(int numberOfSignificantFigures = 3) {
            
            if (_isRigthTriangle) // Для прямоугольного треугольника площадь вычисляется как половина площади прямоугольника, "построенного" на катетах.
                return Math.Round((_firstSideLength * _secondSideLength / 2), numberOfSignificantFigures);
            else { // Для непрямоугольного треугольника при расчете площади используетсяся формула Герона. 

                // Полупериметр треугольника.
                double semiperimeter = (_firstSideLength + _secondSideLength + _thirdSideLength) / 2;

                // Площадь треугольника.
                double area = Math.Sqrt(semiperimeter * (semiperimeter - _firstSideLength) * (semiperimeter - _secondSideLength) * (semiperimeter - _thirdSideLength));

                return Math.Round(area, numberOfSignificantFigures);

            }
            
        }

    }


    /// <summary>
    /// Класс предназначен для получения площадей фигур конкретного типа.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FigureAreaSolver<T> where T : IFigure
    {
        /// <summary>
        /// Метод предназначен для получения площади фигуры.
        /// </summary>
        /// <param name="figure">Фигура, площадь которой требуется получить.</param>
        /// <param name="numberOfSignificantFigures">Количество значащих цифр после запятой.</param>
        /// <returns>Площадь фигуры.</returns>
        public double GetFiguredArea(T figure, int numberOfSignificantFigures = 3) {
    
            return figure.GetArea(numberOfSignificantFigures);
        
        }

    }


}
