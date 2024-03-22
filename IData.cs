using Microsoft.VisualBasic.FileIO;

namespace MyInterface;

public interface IData
{

    public static string[][] CSVDataRead_Function(string filePath_String)
    {
    
        return GetDataCSVPrivate_Function(filePath_String);
    
    }

    private static string[][] GetDataCSVPrivate_Function(string filePath_String)
    {

        try
        {

            string[][] csvData_StringArray2D = [];

            if(!File.Exists(filePath_String))
            {

                System.Console.WriteLine("File Not Found!");

            }

            if(File.Exists("local.csv"))File.Delete("local.csv");

            File.Copy(filePath_String,"local.csv");

            TextFieldParser csvFileReader_TextFieldParser = new("local.csv");

            csvFileReader_TextFieldParser.SetDelimiters(",");

            int rowCount_Int = 0;

            string[]? readLine = csvFileReader_TextFieldParser.ReadFields();

            csvFileReader_TextFieldParser.ReadFields();

            while ((readLine = csvFileReader_TextFieldParser.ReadFields()) != null)
            {

                csvData_StringArray2D[rowCount_Int] = readLine;

                rowCount_Int++;
                
            }

            csvFileReader_TextFieldParser.Dispose();

            return csvData_StringArray2D;
            
        }
        catch (System.Exception fieldParser_Exception)
        {

            
            System.Console.WriteLine(fieldParser_Exception);

        }

        return [];

    }

}