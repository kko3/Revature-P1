using System.Collections.Generic;


namespace PizzaBox.Domain.Models
{
    public class PizzaMenu
    {

      public User UserBrowsingTheMenu { get; set; }
      public List<Crust> CrustsOnMenu { get; set; }
      public List<Size> SizesOnMenu { get; set; }
      public List<Topping> ToppingsOnMenu { get; set; }

    }
}