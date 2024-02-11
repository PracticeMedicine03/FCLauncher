using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Lambdagon.FCLauncher.Core.Functions
{
    public class FCLauncherLuaBindings
    {
        public static Lua lua;
        public FCLauncherLuaBindings() 
        { 
            lua = new Lua();
            lua.DoString("");
        }

        public static FCLauncherLuaBindings BindFCLauncherLuaFiles() { return new FCLauncherLuaBindings(); }
    }
}
