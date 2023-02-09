using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
     class Square
    {
        private int size;

        // Создаем конструктор, чтобы создавать квадраты разных размеров
        // коснтурктор используется чтобы инициалицировать объекты

        public Square(int size)

        {
            this.size = size;
        }


        // Метод, чтобы узнавать размеры квадрата
        public int getSize()

        {
            return size;
        }

        // Метод, который в последствии позволит изменить размер квадрата

        public void setSize(int size)

        {
            this.size = size;
        }
        // getSize и setSize - методы аксессоры. в С# есть конструкция, кторая позволяет сократить пары методов. Можем определить пропети
    }
}
