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

    private static string[][] GetDataCSVPrivate_Function(string filePath_String)
    {

        
        // List<string> data_StringList = []; this seems way better, but managing is harder

        // try
        // {

        //     data_StringList = [.. File.ReadAllLines("Khanevar92.csv").Skip(1)];

        // }
        // catch (System.Exception readCSV_Exception)
        // {
            
        //     System.Console.WriteLine(readCSV_Exception);

        // }

        // double[] familySize_DoubleArray = new double[data_StringList.Count];

        // double[] totalIncome_DoubleArray = new double[data_StringList.Count];

        // double[] incomePerMember_DoubleArray = new double[data_StringList.Count];

        // for (int row_Int = 0; row_Int < data_StringList.Count; row_Int++)
        // {

        //     _ = double.TryParse(data_StringList[row_Int].Split(",")[14], out familySize_DoubleArray[row_Int]);

        //     _ = double.TryParse(data_StringList[row_Int].Split(",")[16], out totalIncome_DoubleArray[row_Int]);

        //     incomePerMember_DoubleArray[row_Int] = totalIncome_DoubleArray[row_Int]/familySize_DoubleArray[row_Int];
            
        // }

        // int tenth_Int = incomePerMember_DoubleArray.Length/10;

        // double[] orderedTotalIncome_DoubleArray = incomePerMember_DoubleArray.Order().ToArray()[..tenth_Int];

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