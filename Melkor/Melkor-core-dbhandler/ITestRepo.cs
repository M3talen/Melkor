﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melkor_core_dbhandler
{
    public interface ITestRepo
    {
        void Add(TestContext test);
        void Edit(Guid testId, TestContext test);
    }
}
