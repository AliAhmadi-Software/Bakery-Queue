using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery_Queue
{
   public class CellType
    {
        public int code;
        public CellType next;

        public CellType(int code)
        {
            this.code = code;
        }
	

    }
}
