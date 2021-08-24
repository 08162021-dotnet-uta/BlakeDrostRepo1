using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class FileAdapter
  {
    public List<Store> StoreReadFromFile()
    {
      //File path
      string path = @"~/revature/blake_code/data/Project_0.xml";
      //Open file
      var fileReader = new StreamReader(path);
      //Serialize(conversion) object
      var xml = new XmlSerializer(typeof(List<Store>));
      //Read from file
      var stores = xml.Deserialize(fileReader) as List<Store>;
      //Close file
      //fileReader.Close(); not needed -> closes for us
      return stores;
    }

    //Generic Example: Need to make a writetofile method using generics
    //When calling these funtions, the caller will need to put the path and the type of variable
    public T ReadFromFile<T>(string path) where T : class
    {
      if (File.Exists(path))
      {
        return null;
      }
      var fileReader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(T));
      var results = xml.Deserialize(fileReader) as T;
      return results;
    }

    public void WriteToFile<T>(string path, T data) where T : class
    {
      var fileReader = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(T));
      xml.Serialize(fileReader, data);
    }

    public void StoreWriteToFile(List<Store> stores)
    {
      //File path
      string path = @"~/revature/blake_code/data/Project_0.xml";
      //Open file
      var fileWriter = new StreamWriter(path);
      //Serialize(conversion) object
      var xml = new XmlSerializer(typeof(List<Store>));
      //Write to file
      xml.Serialize(fileWriter, stores);
      //Close file
      fileWriter.Close();
    }
  }
}