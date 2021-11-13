using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/*
 * Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку –
 * температуру (целое число в диапазоне от -50 до +50),
 * направление ветра (строка),
 * скорость ветра (целое число),
 * наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег.
 * Можно использовать целочисленное значение, либо создать перечисление enum). Свойство «температура» преобразовать в свойство зависимости.
 */

namespace Zadanie_6_Wpf
{
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperProperty;
        private string windRoute;
        private int windSpeed;
        private int weather;

        public WeatherControl(int temper, string windRoute, int windSpeed, int weather)
        {
            this.Temper = temper;
            this.WindRoute = windRoute;
            this.WindSpeed = windSpeed;
            this.Weather = weather;
        }

        public string WindRoute
        {
            get => windRoute;
            set => windRoute = value;
        }

        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }

        public int Weather
        {
            get => weather;
            set
            {
                if (value>=0 && value<=3)
                {
                    weather = value;
                }
            }
        }

        public int Temper
        {
            get => (int)GetValue(TemperProperty);

            set => SetValue(TemperProperty, value);
        }

        static WeatherControl()
        {
            TemperProperty = DependencyProperty.Register(
                nameof(Temper),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemper)),
                new ValidateValueCallback(ValidateTemper));
        }


        private static bool ValidateTemper(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemper(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }

    }
}
