using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // The class that controls the activity log file, the writer can be easily disposed
    public class ActivityLog : IDisposable
    {
        private StreamWriter writer;
        private bool disposed = false;

        public ActivityLog(string path) 
        {
            if(string.IsNullOrEmpty(path)) { throw new ArgumentNullException("Path was null or empty"); }
            writer = new StreamWriter(Path.Combine(AppContext.BaseDirectory, path), false);
            writer.AutoFlush = true;
            writer.WriteLine("----- Log Opened ---");
            writer.WriteLine($"Time Opened: {DateTime.Now.ToString()}");
        }

        public string Log(ActivityRecord record)
        {
            if (disposed) { throw new ObjectDisposedException(nameof(ActivityLog)); }
            if (record is null) { throw new ArgumentNullException(nameof(record));}
            string line = record.ToString();
            writer.WriteLine(line);
            return line;
        }
        public void Dispose()
        {
            if (disposed) { return; }
            writer.WriteLine($"Time Closed: {DateTime.Now.ToString()}");
            writer.WriteLine("----- Log Close -----");
            writer.Dispose();
            disposed = true;
        }
    }
}
