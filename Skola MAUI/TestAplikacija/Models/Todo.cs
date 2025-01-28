using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAplikacija.Models
{
    public class Todo
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Notes { get; set; }
        public short ItsDone { get; set; }
    }
}
