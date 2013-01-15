using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testFolder
{

    class FileReader
    {
        private string sPath;
        private static int COMPUTER_NAME_POS = 2;

        public FileReader(string sPath)
        {
            this.sPath = sPath;
            
        }

        public string GetComputerName()
        {
            string sComputer = "nothing";
            try
            {
                FileStream fStream = File.Open(sPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                //StreamReader reader = File.OpenText(sPath);
                StreamReader reader = new StreamReader(fStream);

                string sPrevLine = "";
                string sCurLine;

                do
                {
                    sCurLine = reader.ReadLine();
                    if (sCurLine != null)
                    {
                        sPrevLine = sCurLine;
                    }
                } while (sCurLine != null);

                fStream.Close();
                fStream.Dispose();
                reader.Close();
                reader.Dispose();

                string[] aLine = sPrevLine.Split(' ');
                sComputer = aLine[COMPUTER_NAME_POS].ToString();

            }
            catch (System.IO.IOException ioex)
            {
                Console.WriteLine("reader error");
            }
           return sComputer;

        }
        
    }
}
