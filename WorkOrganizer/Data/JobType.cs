using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public enum JobType
    {
        None = 0,
        Windows = 1,
        FramesWhiten = 2,
        //windows + frames = 3
        GutterClear = 4,
        GutterClean = 8,
        FacshClean = 16,
        Caravan = 32

    }
}
