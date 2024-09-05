using System.IO;
namespace GameData.MyScripts
{
    public class JsonFileHandler : IFileHandler
    {
        public void Save(string path, string data)
        {
            File.WriteAllText(path, data);
        }

        public string Load(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : null;
        }
    }
    [System.Serializable]
    public class BoolMatrix
    {
        public bool[] data;
        public BoolMatrix(int size)
        {
            data = new bool[size]; // Size should be 6 for a 2x3 matrix
        }
        public bool GetValue(int index)
        {
            return data[index];
        }
        public void SetValue(int index, bool value)
        {
            data[index] = value;
        }
    }
    public interface IFileHandler
    {
        void Save(string path, string data);
        string Load(string path);
    }
}