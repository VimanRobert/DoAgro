using System;
using System.Collections.Generic;
using System.Text;

namespace DoAgro
{
    public interface NotificationService
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void localNotification(string titlu, string tubtitluCultura, string mesaj,  DateTime dataNotificare);
        void ReceiveNotification(string titlu, string mesaj);
        void StopNotification(string tubtitluCultura);
    }
}
