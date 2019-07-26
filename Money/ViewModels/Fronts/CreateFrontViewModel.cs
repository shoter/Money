using Money.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.ViewModels.Fronts
{
    public class CreateFrontViewModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        public CreateFrontViewModel() { }

        public CreateFrontViewModel(CompanyListItemViewModel item)
        {
            CompanyName = item.Name;
            CompanyID = item.ID;
        }
    }
}
