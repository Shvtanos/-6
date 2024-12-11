using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    internal class Fraction
    {
        // Числитель дроби
        public int Numerator { get; private set; }
        // Знаменатель дроби
        public int Denominator { get; private set; }

        // Конструктор для создания дроби с числителем и знаменателем
        public Fraction(int numerator, int denominator)
        {
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        // Переопределение метода ToString для текстового представления дроби
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        // Перегрузка оператора + для сложения дробей
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора - для вычитания дробей
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора * для умножения дробей
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Numerator;
            int newDenominator = f1.Denominator * f2.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора / для деления дробей
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.Numerator * f2.Denominator;
            int newDenominator = f1.Denominator * f2.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка оператора + для сложения дроби с целым числом
        public static Fraction operator +(Fraction f, int n)
        {
            return f + new Fraction(n, 1);
        }

        // Перегрузка оператора - для вычитания целого числа из дроби
        public static Fraction operator -(Fraction f, int n)
        {
            return f - new Fraction(n, 1);
        }

        // Перегрузка оператора * для умножения дроби на целое число
        public static Fraction operator *(Fraction f, int n)
        {
            return f * new Fraction(n, 1);
        }

        // Перегрузка оператора / для деления дроби на целое число
        public static Fraction operator /(Fraction f, int n)
        {
            return f / new Fraction(n, 1);
        }

        // Переопределение метода Equals для сравнения дробей
        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction other = (Fraction)obj;
                return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
            }
            return false;
        }

        // Переопределение метода GetHashCode для получения хэш-кода дроби
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        // Метод для клонирования дроби
        public object Clone()
        {
            return new Fraction(this.Numerator, this.Denominator);
        }

        // Метод для получения вещественного значения дроби
        public double GetRealValue()
        {
            return (double)Numerator / Denominator;
        }

        // Метод для установки числителя дроби
        public void SetNumerator(int numerator)
        {
            Numerator = numerator;
        }

        // Метод для установки знаменателя дроби
        public void SetDenominator(int denominator)
        {
            Denominator = denominator;
        }

        // Метод для сравнения двух дробей
        public int CompareTo(Fraction other)
        {
            if (other == null)
            {
                return 1;
            }

            // Приведение к общему знаменателю
            int commonDenominator = this.Denominator * other.Denominator;
            int thisNumerator = this.Numerator * other.Denominator;
            int otherNumerator = other.Numerator * this.Denominator;

            return thisNumerator.CompareTo(otherNumerator);
        }
    }
}
