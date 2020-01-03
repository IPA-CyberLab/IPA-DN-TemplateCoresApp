// Hoge
// 
// Copyright (c) 2019- Contoso. All Rights Reserved.
// 
// __PUBLICSTATEMENT__

// Author: Daiyuu Nobori
// Daemon.cs によってデーモン化される HogeServerApp の本体の実装コード
// サーバー機能がない場合は削除して問題ありません。

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

namespace Contoso.Hoge
{
    public class HogeServerApp : AsyncService
    {
        public HogeServerApp()
        {
            try
            {
                Console.WriteLine("HogeServerApp instance created."); // Delete this line if unnecessary

                // ここに初期化処理を実装
            }
            catch
            {
                this._DisposeSafe();
                throw;
            }
        }

        protected override void DisposeImpl(Exception? ex)
        {
            try
            {
                Console.WriteLine("HogeServerApp instance disposed."); // Delete this line if unnecessary

                // ここに初期化処理を実装
            }
            finally
            {
                base.DisposeImpl(ex);
            }
        }
    }
}
