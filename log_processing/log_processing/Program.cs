using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace log_processing
{
    class Program
    {
        private static void Main(string[] args)
        {
            // measuring time of perfomance - Start
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // processing arguments
            string path_log = String.Empty;
            bool arg_all = false;
            if (args.Length > 2) { throw new ArgumentException("Too many arguments. Try \"-h\" for help."); }
            foreach (string arg in args)
            {
                if (arg == "-h") { Console.Write("Log processing v1.0\nProgramme for log file processing.\nUSAGE: log_processing.exe PATH_TO_LOG_FILE   (output is 5 methotds which lasts longest)\n*OR* log_processing.exe PATH_TO_LOG_FILE -a (all)   (output of methods and stats)\n*OR* log_processing.exe -h (help)\n\nby Vincent Orlovsky"); return; }
                else if (arg == "-a") { arg_all = true; }
                else { path_log = arg; }
            }
            if (String.IsNullOrEmpty(path_log)) { throw new ArgumentException("Missing argument! $ ./log_processing.exe PATH_TO_LOG_FILE ..."); }
        
            // basic nums
            int num_of_max_logs = 5;
            int num_of_logs = 0;
            
            // creating dictionary for storing methods and its time of duration
            Dictionary<string,int> Logs = new Dictionary<string, int>();
            // Dictionary<string, long> logs = new Dictionary<string, int>();

            // reading log file by lines
            using (StreamReader sr = File.OpenText(path_log))
            {
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    num_of_logs += 1;

                    List<string> temp = line.Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                    // checking if is line "leaving" log
                    if (temp.Count < 8) { continue; }
                    else if (temp[3] == "**]")
                    {
                        // taking method
                        string met = (temp[5].Contains("::")) ? temp[5].Split("::")[1] : temp[5];
                        int met_i = 6;
                        while (!temp[met_i].Contains("->"))
                        {
                            met = met + " " + temp[met_i];
                            met_i += 1;
                        }

                        // taking duration   (may change int->long)
                        int dur = Convert.ToInt32(temp[temp.Count - 2].Split("=")[1]);
                        // long dur = Convert.ToInt64(temp[-2].Split("=")[1]);

                        // conversion of duration to us
                        if(temp[temp.Count - 1] == "ms") { dur *= 1000; }
                        else if (temp[temp.Count - 1] == "s") { dur *= 1000000; }

                        // adding method and duration to dictionary or updating duration
                        if (Logs.ContainsKey(met)) { Logs[met] += dur; }
                        else { Logs.Add(met, dur); }

                    }
                }
            }

            // sorting values in dictionary
            var sortedDict = from entry in Logs orderby entry.Value descending select entry;
            
            //foreach (int value in Enumerable.Range(0, 5)) { Console.WriteLine("{0}. {1}", value + 1, sortedDict[value])}
            int l = num_of_max_logs;
            foreach (KeyValuePair<string, int> entry in sortedDict) 
            {
                if (!(l > 0)){ break; }
                l -= 1;
                Console.WriteLine("{0}. {1} {2} us", num_of_max_logs-l,entry.Key, entry.Value);               
            }

            // measuring time of perfomance - Stop
            stopwatch.Stop();

            // perfomance state - output
            if (arg_all) { Console.WriteLine("------------------------\nProcessed logs: {0}\nFound methods: {1}\nTime of perfomance: {2} ms", num_of_logs, Logs.Count, stopwatch.ElapsedMilliseconds); }
        }
    }
}
