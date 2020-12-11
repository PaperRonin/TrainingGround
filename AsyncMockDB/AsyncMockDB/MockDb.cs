using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMockDB
{
    public class MockDb
    {
        public async Task Connect()
        {
            await Task.Delay(5000);
        }

        public async Task Disconnect()
        {
            await Task.Delay(2000);
        }

    }
}
