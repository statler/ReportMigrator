using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System;

namespace cpShared
{
    public abstract class AbstractConfiguration
    {
        public abstract string DefaultFilename
        {
            get;
        }

        public virtual string DefaultFilenameV10 => DefaultFilename;
    }
}
