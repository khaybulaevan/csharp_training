﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = false;
        protected ApplicationManager app;


        [SetUp]
        // Метод для инициализации
        public void SetupApplicationManager()
        {
            // Инициализируем ApplicationManager
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("administrator", "root"));

        }

        // Генератор псевдослучайных чисел
        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            // Число от 0 до max
            int l = Convert.ToInt32(rnd.NextDouble()*max);
            // Генерация строки
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                // Генерация случайных символов. 223  + 32  - Коды символов в соответсвии с таблицей ASCII и все символы меньше 32 непечатные
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));

            }
            return builder.ToString();

        }

    }
}
