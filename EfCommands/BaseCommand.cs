using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class BaseCommand
    {
        protected Context Context { get; }
        public BaseCommand(Context context)
        {
            Context = context;
        }
    }
}
