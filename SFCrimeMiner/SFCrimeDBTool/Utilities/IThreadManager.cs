using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SFCrimeDBTool.Utilities
{
    public interface IThreadManager
    {
        Thread CreateNewThread(ThreadBundle bundle, object o, MethodInfo method);

        void WatchThread(Thread thread);

        void KillAllWatchedThreads();
    }
}
