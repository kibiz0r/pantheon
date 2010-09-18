using System;

namespace Pantheon
{
    public class ControllerTest<ControllerType> where ControllerType : Controller, new()
    {
        public ControllerType Controller { get; set; }

        public ControllerTest()
        {
            Controller = new ControllerType();
        }
    }
}

