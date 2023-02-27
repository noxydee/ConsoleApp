namespace ConsoleApp.Models
{
    using ConsoleApp.Utils;

    using System;
   
    internal class ImportedObject : ImportedBaseObject
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public int NumberOfChildren { get; set; }

        public ImportedObject(string[] values)
        {
            Type = values.GetValueOrDefault(0);
            Name = values.GetValueOrDefault(1);
            Schema = values.GetValueOrDefault(2);
            ParentName = values.GetValueOrDefault(3);
            ParentType = values.GetValueOrDefault(4);
            DataType = values.GetValueOrDefault(5);
            IsNullable = values.GetValueOrDefault(6);

            ClearAndCorrectData();
        }

        public void ClearAndCorrectData()
        {
            Type = Type.TrimAndReplaceNewLine();
            Name = Name.TrimAndReplaceNewLine();
            Schema = Schema.TrimAndReplaceNewLine();
            ParentName = ParentName.TrimAndReplaceNewLine();
            ParentType = ParentType.TrimAndReplaceNewLine();

            Type = Type != null ? Type.ToUpper() : Type;
        }

        public bool IsChildren(ImportedObject potentialChildren)
        {
            return Type == potentialChildren.ParentType && Name == potentialChildren.ParentName;
        }
    }
}
