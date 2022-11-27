using System.ComponentModel.DataAnnotations;
using Contacts.Core.Common.Extensions;

namespace Contacts.Core.Common.ValidationAttributes;

public class ValidSouthAfricanMobileNumber : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value != null && value.ToString().IsValidSouthAfricanMobileNumber();
    }
}