namespace ConsoleApp
{
    using ConsoleApp.Models;
    using ConsoleApp.Utils;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataReader
    {
        public void ImportAndPrintData(string fileToImport, bool printData = true)
        {
            List<ImportedObject> importedObjects = ImportData(fileToImport);

            foreach (ImportedObject imported in importedObjects)
            {
                int childrenCount = importedObjects.Where(x => imported.IsChildren(x)).Count();
                imported.NumberOfChildren = childrenCount;
            }

            if(printData) 
            {
                PrintData(importedObjects);
            }

            Console.ReadLine();
        }

        private List<ImportedObject> ImportData(string fileName)
        {
            List<ImportedObject> importedObjects = new List<ImportedObject>();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    string[] values = line.Split(';');
                    ImportedObject newImportedObject = new ImportedObject(values);

                    importedObjects.Add(newImportedObject);
                }
            }

            return importedObjects;
        }

        private void PrintData(List<ImportedObject> importedObjects)
        {
            foreach (ImportedObject database in importedObjects.Where(x => x.Type == ProjectConsts.Database))
            {
                Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");

                foreach (ImportedObject table in importedObjects.Where(x => x.ParentType.EqualsIgnoreCase(database.Type) && database.Name.EqualsIgnoreCase(x.ParentName)))
                {
                    Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");

                    foreach (ImportedObject column in importedObjects.Where(x => x.ParentType.EqualsIgnoreCase(table.Type) && x.ParentName == table.Name))
                    {
                        Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? ProjectConsts.AcceptsNulls : ProjectConsts.WithNoNulls)}");
                    }
                }
            }
        }
    }
}
