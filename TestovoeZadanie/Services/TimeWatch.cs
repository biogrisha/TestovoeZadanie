using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestovoeZadanie.Services
{
    class TimeWatch
    {

        public async Task<string> timeTicker()
        {

            Thread.Sleep(1000);
            return DateTime.Now.ToString();
        }
    }
}
