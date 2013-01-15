using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testFolder
{
    class Watcher
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        string sWatchPath = @"C:\Log On Log\";
        int iCounter = 0;
        //bool bWriteCompName;
        //string sPath = "";

        public Watcher()
        {
            //bWriteCompName = false;

            watcher.Path = sWatchPath;
            watcher.NotifyFilter = System.IO.NotifyFilters.DirectoryName | System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.Attributes | System.IO.NotifyFilters.LastAccess | System.IO.NotifyFilters.LastWrite;

            watcher.Changed += watcher_Changed;
            watcher.Created += watcher_Created;

            watcher.IncludeSubdirectories = true;

            try
            {
                watcher.EnableRaisingEvents = true;
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            while (true)
            {
                //if (bWriteCompName == true)
                //{
                //    doSomething(sPath);
                //    File.Copy(sPath
                //    //writeCompName();
                //    bWriteCompName = false;
                //}
            }

        }

        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath + " was created");
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (iCounter > 1)
            {
                iCounter = 0;
            }
            if (iCounter == 0)
            {
                Console.WriteLine(e.FullPath + " was changed");

                string[] aPath = e.FullPath.Split('\\');
                Console.WriteLine(aPath[3].ToString());

                //ReadFile(e.FullPath);

                //if (System.IO.Directory.Exists(@"C:\Log On Log\Temp\") == false)
                //{
                //    System.IO.Directory.CreateDirectory(@"C:\Log On Log\Temp\");
                //}
                //try
                //{
                //    File.Copy(e.FullPath, @"C:\Log On Log\Temp\" + aPath[3].ToString(), true);
                //}
                //catch (System.IO.IOException ioex)
                //{
                //    Console.WriteLine("Copy exception");
                //}


                FileReader reader = new FileReader(e.FullPath);
                string sComputerName = reader.GetComputerName();
                Console.WriteLine(sComputerName);
            }
            iCounter++;
        }

        public void ReadFile(string sPath)
        {
            string[] aTextLines = File.ReadAllLines(sPath);
            int iLastLinePos = aTextLines.Length - 1;
            string sLastLine = aTextLines[iLastLinePos].ToString();
            Console.WriteLine(sLastLine);
            
        }

    }
}
