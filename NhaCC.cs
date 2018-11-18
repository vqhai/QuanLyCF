using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyCF
{
    class NhaCC
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //constructor
        public NhaCC(string id, string name, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }
    }
}
