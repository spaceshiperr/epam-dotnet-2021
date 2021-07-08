using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace StudentTestsLibrary
{
    public class ResultReader
    {
        private readonly string path;
        
        public ResultReader(string path)
        {
            this.path = path;
        }

        public IEnumerable<TestResult> Read()
        {
            using (var sr = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read)))
            {
                var json = sr.ReadToEnd();
                var results = JsonSerializer.Deserialize<IEnumerable<TestResult>>(json);
                return results;
            }
        }
    }
}
