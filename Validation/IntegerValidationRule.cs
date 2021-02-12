using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ltimer.Validation
{
	public class IntegerValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			int res = 0;
			if (int.TryParse(value.ToString(), out res))
			{
				return new ValidationResult(true, null);
			}
			else
			{
				return new ValidationResult(false, "the value is not integer");
			}
		}
	}
}
