using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Model
{
    public static class Config
    {
        private static int _isPublish = 0;

        public static int IsPublish
        {
            get { return _isPublish; }
        }

        public static string ConnectionString
        {
            get
            {
                string connectionString = @"Server=PC;Database=QuanLySanPham;Trusted_Connection=True;";
                if (_isPublish == 1) connectionString = @"";
                return connectionString;
            }
        }
    }
}
