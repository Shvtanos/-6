using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб6
{
    internal interface IFractionOperations
    {
        // Метод для получения вещественного значения дроби
        double GetRealValue();
        // Метод для установки числителя дроби
        void SetNumerator(int numerator);
        // Метод для установки знаменателя дроби
        void SetDenominator(int denominator);
    }
}
