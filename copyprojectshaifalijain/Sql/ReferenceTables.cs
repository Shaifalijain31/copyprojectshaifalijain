using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copyprojectshaifalijain.Sql
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public override string ToString() => CategoryName;
    }
    public class ContactType
    {
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }
        public override string ToString() => ContactTitle;
    }
    public class Countries
    {
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
    public  class ReferenceTables
    {
        public List<Categories> CategoriesList { get; set; } = new List<Categories>();
        public List<ContactType> ContactTypesList { get; set; } = new List<ContactType>();
        public List<Countries> CountriesList { get; set; } = new List<Countries>();
    }
}
