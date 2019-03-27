using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetroTech.Service.Models.result
{
    public class ResultAPI<T>
    {
        public bool IsProcess { get; set; }

        public string Mess { get; set; }

        public string Class { get; set; }

        public T Data { get; set; }

        public IEnumerable<T> ListData { get; set; }
    }
}