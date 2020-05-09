using Satisfactory_Mod_Manager.Infrastructure.Exceptions;
using Satisfactory_Mod_Manager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Satisfactory_Mod_Manager.Infrastructure
{
    public class Instance
    {

        private static Instance _instance;
        private Parameters _parameters;
        #region Lists
        private List<Window> _windows;
        private List<UserControl> _fragments;
        #endregion

        #region Repositories

        #endregion

        /// <summary>
        /// Singleton of Instance
        /// </summary>
        /// <returns></returns>
        public static Instance GetInstance()
        {
            if (_instance == null) _instance = new Instance();
            return _instance;
        }

        /// <summary>
        /// Returns a window. If the window doesn't exist, creates it. If the window contains args, recreates it with args.
        /// </summary>
        /// <typeparam name="T">Class of Window</typeparam>
        /// <param name="args">Args for window constructor</param>
        /// <returns></returns>
        public T GetWindow<T>(params object[] args) where T : Window
        {
            if (_windows == null) _windows = new List<Window>();
            if (args != null && args.Length > 0 && args[0] != null)
            {
                T toDelete = _windows.SingleOrDefault(w => w.GetType() == typeof(T)) as T;
                if (toDelete != null) _windows.Remove(toDelete);
            }
            if (_windows.SingleOrDefault(w => w.GetType() == typeof(T)) == null) _windows.Add(Activator.CreateInstance(typeof(T), args) as T);
            return _windows.Single(w => w.GetType() == typeof(T)) as T;
        }

        /// <summary>
        /// Properly shuts down the Application
        /// </summary>
        internal void ShutdownApp()
        {
            _windows = null;
            _fragments = null;
            GetParameters().Save();
            App.Current.Shutdown(0);
        }

        /// <summary>
        /// Returns a fragment. If the fragment doesn't exist, creates it. If the fragment contains args, recreates it with args.
        /// </summary>
        /// <typeparam name="T">Class of Fragment</typeparam>
        /// <param name="args">Args for fragment constructor</param>
        /// <returns></returns>
        public T GetFragment<T>(params object[] args) where T : UserControl
        {
            if (_fragments == null) _fragments = new List<UserControl>();
            if (args != null && args.Length > 0 && args[0] != null)
            {
                T toDelete = _fragments.SingleOrDefault(frag => frag.GetType() == typeof(T)) as T;
                if (toDelete != null) _fragments.Remove(toDelete);
            }
            if (_fragments.SingleOrDefault(frag => frag.GetType() == typeof(T)) == null) _fragments.Add(Activator.CreateInstance(typeof(T), args) as T);
            return _fragments.Single(frag => frag.GetType() == typeof(T)) as T;
        }

        /// <summary>
        /// Sets main window. Throw an exception if window is already initialized.
        /// </summary>
        /// <param name="win"></param>
        public void SetMainWindow(MainWindow win)
        {
            if (_windows == null) _windows = new List<Window>();
            if (_windows.SingleOrDefault(w => w.GetType() == typeof(MainWindow)) != null) throw new TechnicalException("MainWindow already exists !");
        }

        /// <summary>
        /// Returns App's Parameters
        /// </summary>
        /// <returns></returns>
        public Parameters GetParameters()
        {
            if (_parameters == null) _parameters = Parameters.Load();
            if (_parameters == null) _parameters = new Parameters();
            return _parameters;
        }
    }
}
