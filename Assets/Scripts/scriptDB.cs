using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.SqliteClient;
using System.Data;
using System.IO;
using System;


public class scriptDB : MonoBehaviour
{
    private static string _sqlDBLocation = "";
    private const string SQL_DB_NAME = "WordsSQLite";
    public static string word;

    void Awake()
    {
        _sqlDBLocation = "URI=file:Assets/" + SQL_DB_NAME + ".db";
    }
    private void Start()
    {
        using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(_sqlDBLocation))
        {
            dbcon.Open(); 
            var sql = "SELECT COUNT(words) FROM Words"; 
            using (IDbCommand dbcmd = dbcon.CreateCommand()) 
            { 
                dbcmd.CommandText = sql;

                Debug.Log(dbcmd.ExecuteScalar());
                int random = UnityEngine.Random.Range(1, Convert.ToInt32(dbcmd.ExecuteScalar())+1);
                

                var sqlId = "SELECT words FROM Words WHERE _id=" + random;
                dbcmd.CommandText = sqlId;
                word = dbcmd.ExecuteScalar().ToString().ToLower();
                Debug.Log(dbcmd.ExecuteScalar());
                  
            }
             dbcon.Close(); 
            
        }
    }

    public static string ErrorWord(string cellToWords)
    {
        string result = null;
        using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(_sqlDBLocation))
        {
            dbcon.Open();
            var sql = "SELECT words FROM Words WHERE words = " + "'" + cellToWords.ToString() + "'";
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                dbcmd.CommandText = sql;

                if(dbcmd.ExecuteScalar() !=null)
                result = dbcmd.ExecuteScalar().ToString();

                Debug.Log(dbcmd.ExecuteScalar());

            }
            dbcon.Close();

        }

        return result;
  
    }
       
}
