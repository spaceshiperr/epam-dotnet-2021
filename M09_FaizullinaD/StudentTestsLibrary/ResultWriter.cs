using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace StudentTestsLibrary
{
    public class ResultWriter
    {
        private readonly string path;

        public ResultWriter(string path)
        {
            this.path = path;
        }
        
        public void Write(IEnumerable<TestResult> results)
        {
            using (var sw = new StreamWriter(File.Open(path, FileMode.Create, FileAccess.Write)))
            {
                var json = JsonSerializer.Serialize(results);
                sw.WriteLine(json);
            }
        }

        public void Append(TestResult result)
        {
            using (var sw = new StreamWriter(File.Open(path, FileMode.Append, FileAccess.Write)))
            {
                var json = JsonSerializer.Serialize(result);
                sw.WriteLine(json);
            }
        }
    }
}
