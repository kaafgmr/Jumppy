using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    private static IDbConnection dbconn;

    public static DBManager Instance;

    public static int ID;
    public static int SavesAmount;

    public static int level;
    public static int checkPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
             Destroy(this.gameObject);   
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        string conn = "URI=file:" + Application.dataPath + "/Plugins/GameDatabase.db";
        CreateDB(conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        SavesCount();
    }

    public static void CloseDB()
    {
        dbconn.Close();
    }

    public void CreateDB(string DBName)
    {
        using (var connection = new SqliteConnection(DBName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS GameData (ID    INTEGER, CurrentLevel  INTEGER, CurrentCheckPoint INTEGER, PickedCherry  INTEGER, PickedPumpkin INTEGER, PickedBanana  INTEGER, PRIMARY KEY(ID));";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public static void SaveData()
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
       string query = "INSERT INTO GameData(CurrentLevel,CurrentCheckPoint,PickedCherry,PickedPumpkin,PickedBanana)" +
        " VALUES('" + LevelManager.Instance.GetCurrentLevel() + "', '" + CheckPointManager.Instance.GetCurrentCheckPoint() + "', " + ItemManager.CherryIsPicked + ", " + ItemManager.PumpkinIsPicked + ", " + ItemManager.BananaIsPicked + ")";
       
        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public static void NewGame()
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "INSERT INTO GameData(CurrentLevel,CurrentCheckPoint,PickedCherry,PickedPumpkin,PickedBanana) VALUES(0,0,0,0,0)";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public static void UpdateData()
    {
        IDbCommand dbcmd = dbconn.CreateCommand();

        string query = "UPDATE GameData SET CurrentLevel = " + LevelManager.Instance.GetCurrentLevel() + ", CurrentCheckPoint = " + CheckPointManager.Instance.GetCurrentCheckPoint() + ", PickedCherry = " + ItemManager.CherryIsPicked + ", PickedPumpkin = " + ItemManager.PumpkinIsPicked + ", PickedBanana = " + ItemManager.BananaIsPicked + " WHERE id = " + ID;
        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public  static void GetData(int id)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT * FROM GameData where id = " + id;
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            level = reader.GetInt32(1);
            checkPoint = reader.GetInt32(2);
            ItemManager.CherryIsPicked = reader.GetInt32(3);
            ItemManager.PumpkinIsPicked = reader.GetInt32(4);
            ItemManager.BananaIsPicked = reader.GetInt32(5);
        }
    }

    public static void SavesCount()
    {
        SavesAmount = 0;
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT * FROM GameData";
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            SavesAmount++;
        }
    }
}
