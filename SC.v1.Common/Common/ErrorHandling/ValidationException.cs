using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Utils.Common.ErrorHandling
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException() { }

        public ValidationException(string name)
            : base(name)
        {

        }
    }
}
