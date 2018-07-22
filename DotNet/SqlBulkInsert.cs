using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using System.Data.SqlClient;
using System.Data;

public static object lockConnection = new object();

/// Useful code snippet which can be used as an extension method to EF context in order to 
/// insert large amount od data to SQL server faster than traditional SaveContext();
/// Drawback: not preserving relations between tables in the way EF does.

public int SqlBulkInsert<T>(IEnumerable<T> dataCollection, string sqlTableName, string connString) {
    try {
        var table = dataCollection.ToDataTable();
        lock (lockConnection) {
            var conn = new SqlConnection(connString);                    
            conn.Open();
            var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.FireTriggers, null) {
                DestinationTableName = sqlTableName
                };
            bulkCopy.WriteToServer(table);
            conn.Close();
            }
        return 0;
        }
    catch (Exception ex) {
        throw ex;
        }
    }