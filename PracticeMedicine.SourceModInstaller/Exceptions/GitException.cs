using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMedicine.SourceModInstaller.Exceptions
{
    public class GitException : Exception
    {
        public GitException() { }
        public GitException(string message) : base(message) { }
        public GitException(string message, Exception innerException) : base(message, innerException) { }
    }
}
