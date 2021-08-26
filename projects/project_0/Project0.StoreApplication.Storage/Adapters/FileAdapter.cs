using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class FileAdapter
  {
    //Generic Example: Need to make a writetofile method using generics
    //When calling these funtions, the caller will need to put the path and the type of variable
    /// <summary>
    /// Takes in a file path
    /// Returns a List of Objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public List<T> ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }
      var fileReader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<T>));
      var results = xml.Deserialize(fileReader) as List<T>;
      return results;
    }

    /// <summary>
    /// Takes in a file path, Takes a List of objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void WriteToFile<T>(string path, List<T> data) where T : class
    {
      var fileReader = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<T>));
      xml.Serialize(fileReader, data);
    }
  }
}