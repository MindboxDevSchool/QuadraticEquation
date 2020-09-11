using System;

/*
 * Закончить приложение для решения квадратных уравнений.
 * Покрыть юнит-тестами всё, кроме ввода и вывода.
 * Результаты работы в виде пул-реквеста в репозиторий 
 */

namespace Week1Task1 {
    public static class QuadraticEquationSolver {
        
        public static (double x1, double x2) Solve(double a, double b, double c) {
            var discriminant = Math.Sqrt(Discriminant(a, b, c));
            var x1 = ( 1.0d * discriminant - b) / (2.0 * a);
            var x2 = (-1.0d * discriminant - b) / (2.0 * a);
            return (x1, x2);
        }

        private static double Discriminant(double a, double b, double c) {
            var discriminant = b * b - 4 * a * c;
            return discriminant < 0 ? double.NaN : discriminant;
        }
    }
}