using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public enum TableName
    {
        Product,
        Order,
        Role,
        User
    }
    internal class AppData
    {
        public static baza7Entities db = new baza7Entities();
    }
}
