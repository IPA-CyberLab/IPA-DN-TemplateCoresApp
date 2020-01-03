// Hoge
// 
// Copyright (c) 2019- Contoso. All Rights Reserved.
// 
// __PUBLICSTATEMENT__

// Author: Daiyuu Nobori
// デーモンサービスの実装
// デーモン機能がない場合は削除して問題ありません。
// 複数のデーモン機能を併存させることも可能です。

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
    // デーモンを起動するためのコマンドのコード
    public partial class Commands
    {
        [ConsoleCommand(
            "Start or stop the HogeServerDaemon daemon",
            "HogeServerDaemon [command]",
            "Start or stop the HogeServerDaemon daemon",
            @"[command]:The control command.

[UNIX / Windows common commands]
start        - Start the daemon in the background mode.
stop         - Stop the running daemon in the background mode.
show         - Show the real-time log by the background daemon.
test         - Start the daemon in the foreground testing mode.

[Windows specific commands]
winstart     - Start the daemon as a Windows service.
winstop      - Stop the running daemon as a Windows service.
wininstall   - Install the daemon as a Windows service.
winuninstall - Uninstall the daemon as a Windows service.")]
        static int HogeServerDaemon(ConsoleService c, string cmdName, string str)
        {
            return DaemonCmdLineTool.EntryPoint(c, cmdName, str, new HogeServerDaemon(), new DaemonSettings());
        }
    }

    // デーモン定義コード
    public class HogeServerDaemon : Daemon
    {
        HogeServerApp? app = null;

        public HogeServerDaemon() : base(new DaemonOptions("HogeServer", "HogeServer Service", true))
        {
        }

        protected override async Task StartImplAsync(DaemonStartupMode startupMode, object? param)
        {
            Con.WriteLine("HogeServerDaemon: Starting...");

            app = new HogeServerApp();

            await Task.CompletedTask;

            Con.WriteLine("HogeServerDaemon: Started.");
        }

        protected override async Task StopImplAsync(object? param)
        {
            Con.WriteLine("HogeServerDaemon: Stopping...");

            if (app != null)
            {
                await app.DisposeWithCleanupAsync();

                app = null;
            }

            Con.WriteLine("HogeServerDaemon: Stopped.");
        }
    }
}
