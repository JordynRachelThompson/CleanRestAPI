using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public static class FakeDb
    {
        public static int id = 1;
        public static readonly List<Customer> Customers = new List<Customer>();
    }
}
