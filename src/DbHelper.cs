﻿/*
 * Authors:
 *   喻星(Xing Yu) <491718907@qq.com>
 *
 * Copyright (C) 2015 Automao Network Co., Ltd. <http://www.zongsoft.com>
 *
 * This file is part of Automao.Data.
 *
 * Automao.Data is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Automao.Data is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Automao.Data; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Automao.Data
{
    internal class DbHelper
    {
        private Options.Configuration.DataOptionElement _option;
        private System.Data.Common.DbProviderFactory _dbProviderFactory;

        internal static DbHelper GetDBHelper(Options.Configuration.DataOptionElement option)
        {
            var dbHelper = new DbHelper();
            dbHelper._option = option;
            return dbHelper;
        }

        internal DbProviderFactory DbProviderFactory
        {
            get
            {
                if (_dbProviderFactory == null)
                    _dbProviderFactory = DbProviderFactories.GetFactory(_option.Provider);
                return _dbProviderFactory;
            }
        }

        internal DbConnection DbConnection
        {
            get
            {
                var conn = DbProviderFactory.CreateConnection();
                conn.ConnectionString = _option.ConnectionString;
                return conn;
            }
        }

        internal DbDataAdapter DbDataAdapter
        {
            get
            {
                var adapter = DbProviderFactory.CreateDataAdapter();
                return adapter;
            }
        }
    }
}
