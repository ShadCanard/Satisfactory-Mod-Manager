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
        /// Loads an object from a file. Uses FilePath attribute to detect where to load
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>()
        {
            return Load<T>(typeof(T).GetFilePath());
        }

        /// <summary>
        /// Loads an object from a given file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path)
        {
            //Returns default if no file (Quickest way)
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return default;
            }
            //Open the file's stream in Read Mode
            using (var sr = new FileStream(path, FileMode.Open, FileAccess.Read))
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
        /// Save an object in a file. Uses FilePath attribute to detect where to save
        /// </summary>
        /// <param name="toSave"></param>
        public static void Save(object toSave)
        {
            Save(toSave, toSave.GetType().GetFilePath());
        }

        /// <summary>
        /// Saves an object in a file. Creates the save directory if it doesn't exist
        /// </summary>
        /// <param name="toSave">Object to save</param>
        /// <param name="filePath">File's path</param>
        public static void Save(object toSave, string path)
        {

            if (string.IsNullOrWhiteSpace(path)) return;
            //If the save directory doesn't exist, create one
            if (!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));

            //Open the file's stream we need to create in Write Mode
            using (var sr = new FileStream(path, FileMode.Create, FileAccess.Write))
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
