using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ => {
        List<Venues> allVenues = Venues.GetAll();
        return View["index.cshtml", allVenues];
      };
      Post["/venue/add"] = _ => {
        Venues newVenue = new Venues(Request.Form["venue_name"]);
        newVenue.Save();
        List<Venues> allVenues = Venues.GetAll();
        return View["index.cshtml", allVenues];
      };
      Get["/venue/{id}"]= parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venues SelectedVenues = Venues.Find(parameter.id);
        List<Bands> VenueBands = SelectedVenues.GetBands();
        List<Bands> AllBands = Bands.GetAll();
        model.Add("venues", SelectedVenues);
        model.Add("venueBands", VenueBands);
        model.Add("bands", AllBands);
        return View["venue_bands.cshtml", model];
      };Get["/band"]= _ => {
        List<Bands> allBands = Bands.GetAll();
        return View["index.cshtml", allBands];
      };
      Post["/band/add"] = _ => {
        Bands newBand = new Bands(Request.Form["band_name"]);
        newBand.Save();
        List<Bands> allBands = Bands.GetAll();
        return View["bands.cshtml", allBands];
      };
    }
  }
}
