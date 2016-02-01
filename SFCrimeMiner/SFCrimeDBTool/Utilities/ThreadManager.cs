using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SFCrimeDBTool.Utilities
{
    public class ThreadManager : IThreadManager
    {
        private readonly Thread _monitor;
        private readonly List<Thread> _threadPool;
        private static readonly object locker = new object();

        public ThreadManager()
        {
            _threadPool = new List<Thread>();
        } 

        public Thread CreateNewThread(ThreadBundle bundle, object o, MethodInfo method)
        {
            return new Thread(() => method.Invoke(o, BindingFlags.InvokeMethod, null, new []{bundle}, CultureInfo.DefaultThreadCurrentCulture));
        }

        public void WatchThread(Thread thread)
        {
            throw new NotImplementedException();
        }

        public void KillAllWatchedThreads()
        {
            throw new NotImplementedException();
        }


    }
}
