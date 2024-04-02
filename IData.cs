using Microsoft.VisualBasic.FileIO;

namespace MyInterface;

public interface IData
{

    public static string[][] CSVDataRead_Function(string filePath_String)
    {
    
        return GetDataCSVPrivate_Function(filePath_String);
    
    }

    public static int[] CastStringToInt_Function(string[][] initialData_StringArray2D, int column_Int)
    {

        return StringToIntPrivate_Function(initialData_StringArray2D, column_Int);
    
    }

    public static double[] Parse2Double_Function(string[][] csvData_StringArray2D, int columnNumber_Int)
    {

        return ParseCSV2DoublePrivate_Function(csvData_StringArray2D, columnNumber_Int);

    }

    public static int[] Parse2Int_Function(string[][] csvData_StringArray2D, int columnNumber_Int)
    {

        return ParseCSV2IntPrivate_Function(csvData_StringArray2D, columnNumber_Int);

    }

    private static double[] ParseCSV2DoublePrivate_Function(string[][] csvData_StringArray2D, int columnNumber_Int)
    {

        double[] targetColumn_StringArray = new double[csvData_StringArray2D.Length];

        for (int row_Int = 0; row_Int < csvData_StringArray2D.Length; row_Int++)
        {

            _ = double.TryParse(csvData_StringArray2D[row_Int][columnNumber_Int], out targetColumn_StringArray[row_Int]);
            
        }

        // double[] orderedTotalIncome_DoubleArray = incomePerMember_DoubleArray.Order().ToArray()[..tenth_Int];

        return targetColumn_StringArray;

    }

    private static int[] ParseCSV2IntPrivate_Function(string[][] csvData_StringArray2D, int columnNumber_Int)
    {

        int[] targetColumn_StringArray = new int[csvData_StringArray2D.Length];

        for (int row_Int = 0; row_Int < csvData_StringArray2D.Length; row_Int++)
        {

            _ = int.TryParse(csvData_StringArray2D[row_Int][columnNumber_Int], out targetColumn_StringArray[row_Int]);
            
        }

        return targetColumn_StringArray;

    }

    private static string[][] GetDataCSVPrivate_Function(string filePath_String)
    {

        //list version
        // try
        // {

        //     string[][] csvData_StringArray2D = [.. File.ReadAllLines("Khanevar92.csv")];

        // }
        // catch (System.Exception readCSV_Exception)
        // {
            
        //     System.Console.WriteLine(readCSV_Exception);

        // }

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

            string[]? readLine;

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

    private static int[] StringToIntPrivate_Function(string[][] initialData_StringArray2D, int column_Int)
    {

        int[] processedData_IntArray = new int[initialData_StringArray2D.Length];

        for (int rowCount_Int = 0; rowCount_Int < initialData_StringArray2D.Length; rowCount_Int++)
        {

            if(!int.TryParse(initialData_StringArray2D[rowCount_Int][column_Int], out processedData_IntArray[rowCount_Int]))
            {

                System.Console.WriteLine("Error While Parsing To Integer!");

                return [];

            }
            
        }

        return processedData_IntArray;
    
    }

} 