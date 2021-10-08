using System;
using System.IO;
using System.Windows.Forms;

namespace MultiCompte2.Composants
{
    class Logger
    {
        private string logsPath = @"Logs\";
        private string newLine = Environment.NewLine;
        
        public Logger()
        {

        }

        public void WriteLog(string title, string message)
        {
            string file = logsPath + title + ".txt";
            try
            {
                if(!Directory.Exists(logsPath))
                {
                    Directory.CreateDirectory(logsPath);
                }
                if(File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    string content = "";
                    while(!sr.EndOfStream)
                    {
                        content += sr.ReadLine();
                    }
                    content += newLine;
                    sr.Close();
                    sr.Dispose();
                    StreamWriter sw = new StreamWriter(file);
                    sw.Write(content + message);
                    sw.Close();
                    sw.Dispose();
                }
                else
                {
                    File.WriteAllText(file, title);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Message :" + newLine + ex.Message + newLine + newLine + "StackTrace :" + newLine + ex.StackTrace, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
