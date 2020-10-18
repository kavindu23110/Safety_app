using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.DependancyServices
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
