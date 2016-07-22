using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venues
  {
    private int _id;
    private string _venue;

    public Venues(string venueName, int id = 0)
    {
      _id = id;
      _venue = venueName;
    }

    public void SetVenueName(string newVenueName)
    {
      _venue = newVenueName;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetVenue()
    {
      return _venue;
    }

    public static List<Venues> GetAll()
    {
      List<Venues> allVenues = new List<Venues>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int venuesId = rdr.GetInt32(0);
        string venuesName = rdr.GetString(1);
        Venues newVenue = new Venues(venuesName, venuesId);
        allVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues;
    }

    public override bool Equals (System.Object otherVenues)
    {
      if (otherVenues is Venues)
      {
        Venues newVenues = (Venues) otherVenues;
        bool idEquality = (this.GetId() ==  newVenues.GetId());
        bool venueEquality = (this.GetVenue() == newVenues.GetVenue());
        return (idEquality && venueEquality);
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
      SqlCommand cmd = new SqlCommand("INSERT INTO venues (venue) OUTPUT INSERTED.id VALUES (@VenueName);", conn);
      SqlParameter venueParameter = new SqlParameter();
      venueParameter.ParameterName = "@VenueName";
      venueParameter.Value = this.GetVenue();
      cmd.Parameters.Add(venueParameter);
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

    public static Venues Find(int queryVenuesId)
    {
      List<Venues> allVenues = new List<Venues>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
      SqlParameter venueParameter = new SqlParameter();
      venueParameter.ParameterName = "@VenueId";
      venueParameter.Value = queryVenuesId;
      cmd.Parameters.Add(venueParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string venue = rdr.GetString(1);
        Venues newVenues = new Venues (venue, id);
        allVenues.Add(newVenues);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues[0];
    }

    public void DeleteThis()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues WHERE id = @VenuesId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@VenuesId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();
    }

  }
}
