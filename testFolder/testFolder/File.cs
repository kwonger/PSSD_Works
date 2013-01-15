using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace testFolder
{
    class File
    {

        public File()
        {
            XDocument doc = XDocument.Load(@"C:\\Log On Log\\test.xml");
            WriteOut();
        }

        public void WriteOut()
        {

        }
    }
}
