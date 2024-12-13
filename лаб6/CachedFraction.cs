using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    public class CachedFraction : IFractionOperations
    {
        public int Numerator;
        public int Denominator;

        // Кэшированное вещественного значение дроби
        private double? cachedRealValue;

        // Конструктор для создания кэшированной дроби с числителем и знаменателем //Конструктор устанавливает значения числителя и знаменателя напрямую
        public CachedFraction(int numerator, int denominator) //: base(numerator, denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        // Переопределение метода GetRealValue для получения кэшированного вещественного значения дроби
        public new double GetRealValue()
        {
            if (!cachedRealValue.HasValue)
            {
                cachedRealValue = (double)Numerator / Denominator;
            }
            return cachedRealValue.Value;
        }

        // Переопределение метода SetNumerator для установки числителя дроби и сброса кэша
        public new void SetNumerator(int newNumerator)
        {
            Numerator = newNumerator;
            //base.SetNumerator(numerator);
            cachedRealValue = null;
        }

        // Переопределение метода SetDenominator для установки знаменателя дроби и сброса кэша
        public new void SetDenominator(int newDenominator)
        {
            //base.SetDenominator(denominator);
            if (newDenominator != 0)
            {
                Denominator = newDenominator;
                cachedRealValue = null;
            }
            else
            {
                Console.WriteLine("Знаменатель не может быть равен нулю");
            }
        }
    }
}
