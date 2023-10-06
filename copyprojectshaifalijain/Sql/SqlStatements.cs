using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copyprojectshaifalijain
{
    internal class SqlStatements
    {
        public static string ReferenceTableStatements1 =>
       @"
SELECT CategoryID,CategoryName FROM dbo.Categories;
SELECT ContactTypeIdentifier,ContactTitle FROM dbo.ContactType;
SELECT CountryIdentifier,[Name] FROM dbo.Countries;
        ";
    }
}
