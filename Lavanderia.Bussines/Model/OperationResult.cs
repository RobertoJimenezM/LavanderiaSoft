using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Model
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public  string? SuccessMessage { get; set; }
        public  string? ErrorMessage { get; set; }
        public string? ExceptionError { get; set; }
        public  dynamic? Data { get; set; }




    }
}
