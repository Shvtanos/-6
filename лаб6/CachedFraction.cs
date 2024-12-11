using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    internal class CachedFraction : Fraction
    {
        // Кэшированное вещественное значение дроби
        private double? cachedRealValue;

        // Конструктор для создания кэшированной дроби с числителем и знаменателем
        public CachedFraction(int numerator, int denominator) : base(numerator, denominator)
        {
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
        public new void SetNumerator(int numerator)
        {
            base.SetNumerator(numerator);
            cachedRealValue = null;
        }

        // Переопределение метода SetDenominator для установки знаменателя дроби и сброса кэша
        public new void SetDenominator(int denominator)
        {
            base.SetDenominator(denominator);
            cachedRealValue = null;
        }
    }
}
