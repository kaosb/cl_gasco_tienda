using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;

/// <summary>
/// Summary description for Log
/// </summary>
public class Log
{
	public static void Debug(String reg)
	{

        String startupPath = AppDomain.CurrentDomain.BaseDirectory;

        String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        string path = startupPath + "tiendagasco.log";
        if (!File.Exists(path))
        {
            File.Create(path);
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(fecha + " - " + reg);
            tw.Close();
        }
        else if (File.Exists(path))
        {
            using (var writer = File.AppendText(path))
            {
                writer.WriteLine(fecha + " - " + reg);
                writer.Close();
            } 
        }


	}
}