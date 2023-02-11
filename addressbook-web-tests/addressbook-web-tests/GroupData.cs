﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    // Класс содержит инфомацию об имени
    class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        // Конструктор
        // Один коструктор останется для обратной совместимости, чтобы старый код не сломался 
        public GroupData(string name)

        {
            this.name = name;
        }

        // Свойство
        public string Name


        {
            get {

                return name;
            }
            set

            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }

        }
        public string Footer 
        {
            get 
            {
                return footer;
            }
            set 
            {
                footer = value;
            }
            
        }

    }
 }

    
