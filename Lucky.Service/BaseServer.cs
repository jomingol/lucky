using System;
using System.Collections.Generic;
using System.Text;
using Lucky.Core;

namespace Lucky.Service
{
    public class BaseServer<T> : DbContext where T : class, new()
    {

    }
}
