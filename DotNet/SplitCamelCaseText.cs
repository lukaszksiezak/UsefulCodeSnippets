using System;

namespace RegexSamples {

	class Program{
		
		/*Function splits camelCaseStrings to string array:
		* Parameters: string - e.g. "camelCaseString"
		* Returns: string[] - e.g. ["camel", "Case", "String"]
		*/
		public static string[] SplitCamelCase(string input){
			return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim().Split(' ');
		}
	}
}
