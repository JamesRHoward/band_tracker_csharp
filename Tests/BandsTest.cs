using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class BandsTest : IDisposable
  {
    public BandsTest()
    {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_GetAll_DatabaseEmptyAtFirst()
    {
      int result = Bands.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_BoolOverride_SameEnteriesMatch()
    {
      Bands firstBands = new Bands("RR and family band");
      Bands secondBands = new Bands("RR and family band");

      Assert.Equal(firstBands, secondBands);
    }
    [Fact]
    public void Test_Save_SavesBandsToDatabase()
    {
      Bands testBand = new Bands("Joe Bonamassa");
      testBand.Save();

      Assert.Equal(1, Bands.GetAll().Count);
    }
    [Fact]
    public void Test_Find_FindsBandsId()
    {
      Bands testBand = new Bands("KISS");
      testBand.Save();
      Bands testBand2 = new Bands("AC/DC");
      testBand2.Save();
      int idToFind = testBand2.GetId();
      Bands resultBand = Bands.Find(idToFind);

      Assert.Equal(testBand2, resultBand);
    }
    public void Dispose()
    {
      Bands.DeleteAll();
    }
  }
}
