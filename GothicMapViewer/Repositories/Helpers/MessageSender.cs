using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothicMapViewer.Repositories.Helpers
{
    public static class MessageSender
    {
        public static void Send<T>(T message)
        {
            Messenger.Default.Send<T>(message);
        }
    }
}
