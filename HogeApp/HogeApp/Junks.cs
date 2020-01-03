// Hoge
// 
// Copyright (c) 2019- Contoso. All Rights Reserved.
// 
// __PUBLICSTATEMENT__

#pragma warning disable CA2235 // Mark all non-serializable fields

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

namespace Contoso.Hoge.App
{
    public static partial class Commands
    {
        // X.509 証明書と秘密鍵を作成する
        [ConsoleCommand(
            "JunkSample command",
            "JunkSample [filename] /abc:def",
            "JunkSample command")]
        static int JunkSample(ConsoleService c, string cmdName, string str)
        {
            ConsoleParam[] args =
            {
                new ConsoleParam("[filename]", ConsoleService.Prompt, "filename: ", ConsoleService.EvalNotEmpty, null),
                new ConsoleParam("abc", ConsoleService.Prompt, "abc: ", ConsoleService.EvalNotEmpty, null),
            };
            ConsoleParamValueList vl = c.ParseCommandList(cmdName, str, args);

            return 0;
        }
    }
}
