using CSharpCourseFileExercise.Entities;
using System.Globalization;

string sourcePath = @"D:\programming\C#\CSharpCourseFileExercise\CSharpCourseFileExercise\Files\sourcefile.csv";
string targetPath = @"D:\programming\C#\CSharpCourseFileExercise\CSharpCourseFileExercise\Files\summary.csv";
List<Product> products = new List<Product>();

try {
    using (FileStream fs = new FileStream(sourcePath, FileMode.Open)) {
        using (StreamReader sr = new StreamReader(fs)) {
            while (!sr.EndOfStream) {
                string[] line = sr.ReadLine().Split(',');
                Product product = new(line[0], double.Parse(line[1], CultureInfo.InvariantCulture), int.Parse(line[2]));
                products.Add(product);
            }
        }
    }
}
catch {
    Console.WriteLine("An error occured while reading file!");
}

try {
    using (StreamWriter sw = File.AppendText(targetPath)) {
        foreach (Product product in products) {
            sw.WriteLine($"{product.Name},{product.totalPrice()}");
        }
        Console.WriteLine("Success!");
    }
}
catch {
    Console.WriteLine("An error occured while writing to target file!");
}