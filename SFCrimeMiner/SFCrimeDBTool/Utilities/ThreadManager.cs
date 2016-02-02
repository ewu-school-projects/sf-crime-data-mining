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
        private static readonly object locker = new object(), waiter = new object();

        public ThreadManager()
        {
            _threadPool = new List<Thread>();
            _monitor = new Thread(MonitorThreadPool);
            _monitor.Start();
        } 

        public Thread CreateNewThread(ThreadBundle bundle, object o, MethodInfo method)
        {
            return new Thread(() => method.Invoke(o, BindingFlags.InvokeMethod, null, new []{bundle}, CultureInfo.DefaultThreadCurrentCulture));
        }

        public void WatchThread(Thread thread)
        {
            lock (locker)
            {
                var callPulse = _threadPool.Count == 0;
                _threadPool.Add(thread);

                if (callPulse)
                    Monitor.Pulse(locker);
            }
        }

        public void KillAllWatchedThreads()
        {
            _monitor.Abort();

            foreach (var thread in _threadPool.Where(x => !x.IsAlive))
            {
                thread.Abort();
            }

            _threadPool.RemoveAll(x => true);
        }

        public void JoinAll()
        {
            _monitor.Abort();

            while (_threadPool.Count > 0)
            {
                var finishedThread = _threadPool.SingleOrDefault(x => !x.IsAlive);
                if (finishedThread == null)
                {
                    Thread.Sleep(10*1000);
                    continue;
                }

                _threadPool.Remove(finishedThread);
                finishedThread.Join();
            }
        }

        private void MonitorThreadPool()
        {
            while (true)
            {
                lock (locker)
                {
                    if (_threadPool.Count == 0)
                    {
                        Monitor.Wait(locker);
                    }
                    var deadThreads = _threadPool.Where(x => !x.IsAlive).ToList();
                    foreach (var thread in deadThreads)
                    {
                        thread.Join();
                        _threadPool.Remove(thread);
                    }
                }

                Thread.Sleep(10*1000);
            }
        }
    }
}
