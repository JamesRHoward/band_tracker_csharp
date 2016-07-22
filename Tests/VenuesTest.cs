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
    public void Dispose()
    {
      // Venues.DeleteAll();
    }
  }
}
