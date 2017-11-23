using System;
using System.Linq;
using Tekla.Structures.Model;

namespace ModelObjectPicker
{
	public class PickerExample
	{
		public void Run()
		{
			//model objects
			Console.WriteLine("Pick Model Objects");
			var modelObjects = ModelObjectPicker.PickModelObjects()
				.OrderBy(m => m.GetType().Name)
				.ToList();

			Console.WriteLine($"Model Objects: {modelObjects.Count}");

			modelObjects.ForEach(p =>
			{
				var partMark = string.Empty;
				p.GetReportProperty("ASSEMBLY_POS", ref partMark);

				var name = string.Empty;
				p.GetReportProperty("NAME", ref name);

				var material = string.Empty;
				p.GetReportProperty("MATERIAL", ref material);

				Console.WriteLine($" - {p.GetType().Name}, {partMark}, " +
				                  $"{name}, {material}");
			});

			//parts
			Console.WriteLine("Pick Parts");
			var parts = ModelObjectPicker.PickParts()
				.OrderBy(m => m.GetType().Name)
				.ToList();

			Console.WriteLine($"Parts: {parts.Count}");
			parts.ForEach(PartWriteLine);

			//beams
			Console.WriteLine("Pick Beams");
			var beams = ModelObjectPicker.PickBeams()
				.OrderBy(m => m.Name)
				.ToList();

			Console.WriteLine($"Beams: {beams.Count}");
			beams.ForEach(PartWriteLine);

			//contour plates
			Console.WriteLine("Contour Plates");
			var contourPlates = ModelObjectPicker.PickContourPlates()
				.OrderBy(m => m.Name)
				.ToList();

			Console.WriteLine($"Contour Plates: {contourPlates.Count}");
			contourPlates.ForEach(PartWriteLine);

			//bolt groups
			Console.WriteLine("Bolt Groups");
			var boltGroups = ModelObjectPicker.PickBoltGroups()
				.OrderBy(m => m.BoltStandard)
				.ToList();

			Console.WriteLine($"Bolt Groups: {boltGroups.Count}");
			boltGroups.ForEach(p =>
				Console.WriteLine($" - {p.GetType().Name}, {p.BoltSize}, " +
				                  $"{p.BoltStandard}, {p.BoltType}"));

			Console.WriteLine("Press Any Key To Quit");
			Console.ReadKey();
		}

		private void PartWriteLine(Part p)
		{
			Console.WriteLine($" - {p.GetType().Name}, {p.GetPartMark()}, " +
			                  $"{p.Name}, {p.Material.MaterialString}");
		}
	}
}