using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Model
{
    public static class StringManager
    {
	    public static string TakeFileName(string path)
	    {
		    return path.Split('\\').Last();
	    }
    }
}
