using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLAPI.Models
{
    public class BaseViewModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
