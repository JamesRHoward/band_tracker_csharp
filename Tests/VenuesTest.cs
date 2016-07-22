using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class VenuesTest : IDisposable
  {
    public VenuesTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_GetAll_DatabaseEmptyAtFirst()
    {
      int result = Venues.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_BoolOverride_SameEnteriesMatch()
    {
      Venues firstVenue = new Venues("Pub house");
      Venues secondVenue = new Venues("Pub house");

      Assert.Equal(firstVenue, secondVenue);
    }
    [Fact]
    public void Test_Save_SavesVenuesToDatabase()
    {
      Venues testVenue = new Venues("pizza palace");
      testVenue.Save();

      Assert.Equal(1, Venues.GetAll().Count);
    }
    [Fact]
    public void Test_Find_FindsVenuesId()
    {
      Venues testVenue = new Venues("crab shack");
      testVenue.Save();
      Venues testVenue2 = new Venues("bobs rock shop");
      testVenue2.Save();
      int idToFind = testVenue2.GetId();
      Venues resultVenue = Venues.Find(idToFind);

      Assert.Equal(testVenue2, resultVenue);
    }
    [Fact]
    public void Test_DeleteThis_RemovesSelectedVenueFromDatabase()
    {
      Venues testVenue = new Venues("Rocking ricks");
      testVenue.Save();
      Venues testVenue2 = new Venues("Dancing daves");
      testVenue2.Save();
      int countAfterSaves = Venues.GetAll().Count;
      testVenue.DeleteThis();
      int countAfterDeleteThis = Venues.GetAll().Count;
      int[] expected = {2, 1};
      int[] result = {countAfterSaves, countAfterDeleteThis};

      Assert.Equal(expected, result);
    }
    [Fact]
    public void Test_Update_UpdateVenueInDatabase()
    {
      string venue = "Rocket barr";
      Venues testVenue = new Venues(venue);
      testVenue.Save();
      string newVenueName = "Rocket bar";

      testVenue.Update(newVenueName);

      string result = testVenue.GetVenue();

      Assert.Equal(newVenueName, result);
    }
    public void Dispose()
    {
      Venues.DeleteAll();
    }
  }
}
