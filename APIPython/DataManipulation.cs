using System;
using System.Data;
using System.Diagnostics;


namespace APIPython
{
   public class DataManipulation
    {
       

        public DataTable ExecuteCommand(string Command)
        {
           // Console.WriteLine("Command", Command);
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            try
            {

                using (Process = Process.Start(ProcessInfo))
                {
                    //Process.WaitForExit();
                }
            }
            catch
            {
            }

            DataTable dt = new DataTable();

            string[] csvRows = System.IO.File.ReadAllLines("CurrentMonth.txt");

            //Console.WriteLine("JP3", csvRows);

            dt = TransferCSVToTable(csvRows);

           // Console.WriteLine("Inside ExecuteCommand");

           // Console.WriteLine("JP",dt);

            return dt;

        }

        public DataTable TransferCSVToTable(string[] data)
        {
            DataTable dt = new DataTable();

            string[] fields = null;
            int i = 0;
            foreach (string csvRow in data)
            {
                fields = csvRow.Split('~');

                for (; i < fields.Length; i++)
                {
                    dt.Columns.Add(fields[i], typeof(string));
                }

                DataRow row = dt.NewRow();
                row.ItemArray = fields;
                dt.Rows.Add(row);
            }

           // Console.WriteLine("Inside TransferCSVToTable");
           // Console.WriteLine("JP2", dt);

            return dt;
        }
    }
}

