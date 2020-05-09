using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Mod_Manager.Infrastructure
{
    /// <summary>
    /// Contains methods for serializing objects
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// Loads a file, returns default if file doesn't exist or an error occurs
        /// </summary>
        /// <typeparam name="T">Class of object to load</typeparam>
        /// <param name="filePath">File's path</param>
        /// <returns></returns>
        public static T Load<T>()
        {
            //Returns default if no file (Quickest way)
            if (string.IsNullOrWhiteSpace(typeof(T).GetFilePath()) || !File.Exists(typeof(T).GetFilePath()))
            {
                return default;
            }

            //Open the file's stream in Read Mode
            using (var sr = new FileStream(typeof(T).GetFilePath(), FileMode.Open,FileAccess.Read))
            {
                try
                {
                    //Return deserialized object from stream
                    return (T)new BinaryFormatter().Deserialize(sr);
                }
                catch (Exception)
                {
                    //Return default if an error occurs
                    return default;
                }

            }
        }

        /// <summary>
        /// Saves an object in a file. Creates the save directory if it doesn't exist
        /// </summary>
        /// <param name="toSave">Object to save</param>
        /// <param name="filePath">File's path</param>
        public static void Save(object toSave)
        {

            if(string.IsNullOrWhiteSpace(toSave.GetType().GetFilePath())) return;
            string filePath = toSave.GetType().GetFilePath();
            //If the save directory doesn't exist, create one
            if (!Directory.Exists(Path.GetDirectoryName(filePath))) Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            //Open the file's stream we need to create in Write Mode
            using (var sr = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    //Deserialize object into stream
                    new BinaryFormatter().Serialize(sr, toSave);
                }
                catch
                {
                }
            }
        }
    }
}
