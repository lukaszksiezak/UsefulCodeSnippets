using System;
using System.Diagnostics;
using System.IO;

///Simple and useful - removes all whitespaces from string and replaces them with commas. 
//Useful for converting data to csv format

namespace CatchOutputStream
{
    class Program
    {
        static void Main(string[] args)
        {
		using (StreamReader sr = new StreamReader(HstPath + fileName + txtExtension)) {
  			String line = await sr.ReadToEndAsync();
  			const string reduceMultiSpace = @"[ ]{1,}";
                    	var csvOutput = Regex.Replace(line.Replace("\t", " "), reduceMultiSpace, ",");     
		}
        }
    }
}
