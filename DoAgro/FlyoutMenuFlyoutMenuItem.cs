using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAgro
{
    public class FlyoutMenuFlyoutMenuItem
    {
        public FlyoutMenuFlyoutMenuItem()
        {
            Point = typeof(FlyoutMenuFlyoutMenuItem);
        }
        //public int Id { get; set; }
        public string Title { get; set; }

        public Type Point { get; set; }
    }
}