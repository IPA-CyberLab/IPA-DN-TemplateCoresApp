// Hoge
// 
// Copyright (c) 2019- Contoso. All Rights Reserved.
// 
// __PUBLICSTATEMENT__

#pragma warning disable CA2235 // Mark all non-serializable fields
#pragma warning disable CS0162

using System;
using System.Buffers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using IPA.Cores.Basic;
using IPA.Cores.Helper.Basic;
using static IPA.Cores.Globals.Basic;

using IPA.Cores.Codes;
using IPA.Cores.Helper.Codes;
using static IPA.Cores.Globals.Codes;

using Contoso.Hoge;
using Contoso.Hoge.App;

using System.Net;
using System.Net.NetworkInformation;

namespace Contoso.Hoge.App
{
    public static class TestClass
    {
        public static void Test(string args)
        {
            Con.WriteLine($"Test! args = '{args}'.");

            Con.WriteLine();

            Con.WriteLine("Resource Test 1:");
            Con.WriteLine(CoresRes["Test/HelloWorld.txt"].String);

            Con.WriteLine();

            Con.WriteLine("Resource Test 2:");
            Con.WriteLine(CodesRes["Test/200103Hello.txt"].String);
        }
    }

    public static partial class Commands
    {
        [ConsoleCommand(
            "Test command",
            "Test [arg]",
            "This is a test command.",
            "[arg]:You can specify an argument.")]
        static int Test(ConsoleService c, string cmdName, string str)
        {
            ConsoleParam[] args =
            {
                new ConsoleParam("[arg]", null, null, null, null),
            };

            ConsoleParamValueList vl = c.ParseCommandList(cmdName, str, args);

            TestClass.Test(vl.DefaultParam.StrValue);

            return 0;
        }
    }
}
