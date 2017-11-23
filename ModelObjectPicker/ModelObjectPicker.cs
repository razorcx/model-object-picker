using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace ModelObjectPicker
{
	public static class ModelObjectPicker
	{
		private static Picker Picker => new Picker();

		public static ModelObject PickModelObject()
		{
			return Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, 
				"Pick One Object");
		}

		public static Part PickPart()
		{
			return Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, 
				"Pick One Part") as Part;
		}

		public static Beam PickBeam()
		{
			return Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, 
				"Pick One Beam") as Beam;
		}

		public static ContourPlate PickContourPlate()
		{
			return Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, 
				"Pick One Contour Plate") as ContourPlate;
		}

		public static BoltGroup PickBoltGroup()
		{
			return Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_BOLTGROUP, 
				"Pick One Bolt Group") as BoltGroup;
		}

		public static List<ModelObject> PickModelObjects()
		{
			return Picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, 
				"Pick Model Objects").ToList();
		}

		public static List<Part> PickParts()
		{
			return Picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, 
				"Pick Parts").ToList()
				.OfType<Part>()
				.ToList();
		}

		public static List<Beam> PickBeams()
		{
			return Picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, 
				"Pick Beams").ToList()
				.OfType<Beam>()
				.ToList();
		}

		public static List<ContourPlate> PickContourPlates()
		{
			return Picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, 
				"Pick Contour Plates").ToList()
				.OfType<ContourPlate>()
				.ToList();
		}

		public static List<BoltGroup> PickBoltGroups()
		{
			return Picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, 
				"Pick Bolt Groups").ToList()
				.OfType<BoltGroup>()
				.ToList();
		}

		public static LineSegment PickLine()
		{
			var arrayList = Picker.PickLine("Pick Line");
			if (arrayList == null) return null;
			
			return new LineSegment(arrayList[0] as Point, arrayList[1] as Point);
		}
	}
}