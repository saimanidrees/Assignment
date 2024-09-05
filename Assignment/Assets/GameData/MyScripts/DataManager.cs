using System.IO;
using UnityEngine;
namespace GameData.MyScripts
{
    public class DataManager : MonoBehaviour
    {
        private BoolMatrix _boolArray;
        private IFileHandler _fileHandler;
        private const string FileName = "boolMatrix", Extension = ".json";
        public static DataManager Instance;
        private void Start()
        {
            Instance = this;
            _fileHandler = new JsonFileHandler();
        }
        public void ResetJson(int totalElements)
        {
            _boolArray = new BoolMatrix(totalElements);
            for (var i = 0; i < totalElements; i++)
            {
                _boolArray.SetValue(i, false);
            }
            SaveData();
            PlayerPrefsHandler.SetLevelStatePref(0);
        }
        public void SavePair(int index0, int index1)
        {
            _boolArray.SetValue(index0, true);
            _boolArray.SetValue(index1, true);
            SaveData();
            PlayerPrefsHandler.SetLevelStatePref(1);
        }
        private void SaveData()
        {
            var json = JsonUtility.ToJson(_boolArray);
            //Debug.Log("SaveData: " + json);
            var path = Path.Combine(Application.persistentDataPath, FileName + PlayerPrefs.GetInt(Constants.CurrentLevelString) + Extension);
            _fileHandler.Save(path, json);
        }
        public BoolMatrix GetData()
        {
            var path = Path.Combine(Application.persistentDataPath, FileName + PlayerPrefs.GetInt(Constants.CurrentLevelString) + Extension);
            var json = _fileHandler.Load(path);
            if (json != null)
            {
                _boolArray = JsonUtility.FromJson<BoolMatrix>(json);
                //Debug.Log("GetData: " + json);
                return _boolArray;
            }
            else
            {
                Debug.LogError("File not found!");
                return null;
            }
        }
    }
}