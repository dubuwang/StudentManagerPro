using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 考勤表类
    /// </summary>
    [Serializable]
    public class Attendance
    {
        int Id { get; set; }

        string CardNo { get; set; }

        DateTime DTime { get; set; }
        
    }
}
