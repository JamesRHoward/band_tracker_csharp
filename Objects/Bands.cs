using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Bands
  {
    private int _id;
    private string _band;

    public Bands(string bandName, int id = 0)
    {
      _id = id;
      _band = bandName;
    }

    public void SetBandName(string newBandName)
    {
      _band = newBandName;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetBand()
    {
      return _band;
    }

    public static List<Bands> GetAll()
    {
      List<Bands> allBands = new List<Bands>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        Bands newBand = new Bands(bandName, bandId);
        allBands.Add(newBand);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allBands;
    }

    public override bool Equals (System.Object otherBands)
    {
      if (otherBands is Bands)
      {
        Bands newBands = (Bands) otherBands;
        bool idEquality = (this.GetId() ==  newBands.GetId());
        bool bandEquality = (this.GetBand() == newBands.GetBand());
        return (idEquality && bandEquality);
      }
      else
      {
        return false;
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO bands (band) OUTPUT INSERTED.id VALUES (@BandName);", conn);
      SqlParameter bandParameter = new SqlParameter();
      bandParameter.ParameterName = "@BandName";
      bandParameter.Value = this.GetBand();
      cmd.Parameters.Add(bandParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();
    }

  }
}
