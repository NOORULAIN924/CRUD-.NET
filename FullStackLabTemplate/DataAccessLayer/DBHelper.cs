using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DataAccessLayer
{
    public class DBHelper
    {
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Host=aws-0-ap-northeast-2.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.zaakahtzulfshvnvesnu;Password=NNOORR@220055;SSL Mode=Require;Trust Server Certificate=true;Pooling=false;");
        }
    }
}

