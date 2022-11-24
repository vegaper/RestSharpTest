using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Models
{
    public class Board
    {
        
        public string? Id { get; set; }
        public string name { get;set; }
        


    }

    public class Boards
    {
        public List<Board> MemberBoards { get; set; }
    }
}
