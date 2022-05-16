using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoAgro
{
    public class LocalNotification
    {
        [PrimaryKey, AutoIncrement]
        public int nrNotificare { get; set; }
        public string titlu { get; set; }
        //public string subtitluCultura { get; set; }
        public string mesaj { get; set; }
        public DateTime oraNotificare { get; set; }

    }
}
