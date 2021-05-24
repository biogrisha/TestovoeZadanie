﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.DataModels
{
    class ListViewItemContainer
    {
        public RegistryKey registryKey { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            if(Name != null)
            {
                return Name;
            }else
            {
                return "Name not assigned";
            }


        }
    }
}
