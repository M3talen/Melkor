﻿using System.Collections.Generic;
using Melkor_core_dbhandler;
using Microsoft.Build.Execution;

namespace Melkor_core_builder
{
    public class BuildItem
    {
        
        public BuildItem(string dir, bool status)
        {
            Dir = dir;
            Status = status;
        }

        public BuildItem(string name, string dir, bool status)
        {
            Dir = dir;
            Name = name;
            Status = status;
        }

        public string Dir { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<TestContext> Tests { get; set; }
    }
}