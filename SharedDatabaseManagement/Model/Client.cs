using System.Collections.Generic;

namespace VetOffice.SharedDatabase.Model
{
  public class Client
  {

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Salutation { get; set; }
    public string PreferredName { get; set; }

  }
}