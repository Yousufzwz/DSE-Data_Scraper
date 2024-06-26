﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker;

public class WorkerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<StockDataService>().InstancePerLifetimeScope();
    }
}